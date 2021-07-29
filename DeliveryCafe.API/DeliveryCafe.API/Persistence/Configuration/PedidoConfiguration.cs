using DeliveryCafe.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Persistence.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder
                   .HasMany(p => p.CarrinhoCompras)
                   .WithOne(c => c.Pedido);
            builder
                .Property(p => p.Total)
                .HasColumnType("decimal");

        }
    }
}
