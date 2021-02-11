using CleanArchExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchExample.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produtos");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Price).HasPrecision(10, 2);

            builder.HasData(
                new Product {Id=3, Name = "Panela", Description = "Uma ótima para de pressão", Price = 80.20M },
                new Product { Id=1, Name = "Sofá", Description = "Um confortável sofá para você e sua família", Price = 800.80M },
                new Product { Id=2, Name = "Cama Casal", Description = "Um confortável cama com eláticos e molas", Price = 1400.50M }
                );
        }
    }
}
