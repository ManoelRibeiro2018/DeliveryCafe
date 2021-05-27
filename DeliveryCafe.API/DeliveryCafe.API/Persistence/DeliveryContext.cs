using DeliveryCafe.API.Models;
using DeliveryCafe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Usuario
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Pedidos)
                .WithOne(p => p.Usuario);

            //Endereço
            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Enderecos);

            //Pedido
            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.Produtos)
                .WithMany(p => p.Pedidos);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.Total)
                .HasColumnType("decimal");

            //Produto
            modelBuilder.Entity<Produto>()
                .HasMany(p => p.Pedidos)
                .WithMany(p => p.Produtos);

            modelBuilder.Entity<Produto>()
               .Property(p => p.Preco)
               .HasColumnType("decimal");

        }

    }
}
