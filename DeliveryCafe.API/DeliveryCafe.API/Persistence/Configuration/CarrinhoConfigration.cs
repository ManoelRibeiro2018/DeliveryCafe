using DeliveryCafe.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Persistence.Configuration
{
    public class CarrinhoConfigration : IEntityTypeConfiguration<CarrinhoCompra>
    {
        public void Configure(EntityTypeBuilder<CarrinhoCompra> builder)
        {
            builder
                    .HasOne(c => c.Produto);
            builder
             .Property(c => c.Total)
             .HasColumnType("decimal");
        }
    }
}
