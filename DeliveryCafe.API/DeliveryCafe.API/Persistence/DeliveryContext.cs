using DeliveryCafe.API.Models;
using DeliveryCafe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Persistence
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options ) : base(options)
        {
                
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<CarrinhoCompra> CarrinhoCompras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
