using DeliveryCafe.API.Especification;
using DeliveryCafe.API.Filters;
using DeliveryCafe.API.Interface.Auth;
using DeliveryCafe.API.Interface.Domain;
using DeliveryCafe.API.Interface.DTO;
using DeliveryCafe.API.Interface.Especification;
using DeliveryCafe.API.Models;
using DeliveryCafe.API.Persistence;
using DeliveryCafe.API.Repository;
using DeliveryCafe.API.Services;
using DeliveryCafe.API.Validator;
using DeliveryCafe.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace DeliveryCafe.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UsuarioValidator>(lifetime: ServiceLifetime.Scoped));
           
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEnderecoInterface, EnderecoRepository>();
            services.AddScoped<IProdutoInterface, ProdutoRepository>();
            services.AddScoped<IPedidoInterface, PedidoRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEnderecoDTOInterface, EnderecoService>();
            services.AddScoped<IProdutoDTOInterface, ProdutoService>();
            services.AddScoped<IRepositoryGenerics<Endereco>, EnderecoRepository>();
            services.AddScoped<ISpecification<EnderecoDTO>, EnderecoEspecification>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddDbContext<DeliveryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Conexao")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeliveryCafe.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header usando esquema Bearer."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,

                      ValidIssuer = Configuration["Jwt:Issuer"],
                      ValidAudience = Configuration["Jwt:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey
                      (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                  };
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeliveryCafe.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
