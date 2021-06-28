﻿using DeliveryCafe.API.Models;
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
        public DbSet<CarrinhoCompra> CarrinhoCompras { get; set; }

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
                .HasMany(p => p.CarrinhoCompras)
                .WithOne(c => c.Pedido);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.Total)
                .HasColumnType("decimal");

            modelBuilder.Entity<Produto>()
               .Property(p => p.Preco)
               .HasColumnType("decimal");

            modelBuilder.Entity<CarrinhoCompra>()
                .HasOne(c => c.Produto);

            modelBuilder.Entity<CarrinhoCompra>()
             .Property(c => c.Total)
             .HasColumnType("decimal");
        }
    }
}
