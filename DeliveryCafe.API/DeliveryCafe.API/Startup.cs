using DeliveryCafe.API.Interface.Domain;
using DeliveryCafe.API.Interface.DTO;
using DeliveryCafe.API.Persistence;
using DeliveryCafe.API.Repository;
using DeliveryCafe.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

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

            services.AddControllers();
            services.AddScoped<IUsuarioInterface, UsuarioRepository>();
            services.AddScoped<IEnderecoInterface, EnderecoRepository>();
            services.AddScoped<IProdutoInterface, ProdutoRepository>();
            services.AddScoped<IUsuarioDTOInterface, UsuarioService>();
            services.AddScoped<IEnderecoDTOInterface, EnderecoService>();
            services.AddScoped<IProdutoDTOInterface, ProdutoService>();
            services.AddDbContext<DeliveryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Conexao")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeliveryCafe.API", Version = "v1" });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
