using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Users.Data.Models.Configurations
{
   public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(t => t.ProductId).ValueGeneratedOnAdd();
            builder.Property(t => t.Quantity).IsRequired();
            builder.Property(t => t.ProductName).HasMaxLength(250).IsRequired();
        }
    }
}
