using MicroService.Users.Data.DataContext.Interface;
using MicroService.Users.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Users.Data.DataContext.Impl
{
    public class ProductDbContext : DbContext, IProductDbContext
    {

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("product");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Product>().HasData(
              new Product { ProductName = "Samsung Galaxy s20", Quantity = 20, ProductId = Guid.NewGuid() },
              new Product { ProductName = "Samsung Galaxy s10", Quantity = 20, ProductId = Guid.NewGuid() },
              new Product { ProductName = "Samsung Galaxy Note 10+", Quantity = 15, ProductId = Guid.NewGuid() },
              new Product { ProductName = "Samsung Galaxy Note 9+", Quantity = 10, ProductId = Guid.NewGuid() },
              new Product { ProductName = "OnePlus7T prp", Quantity = 15, ProductId = Guid.NewGuid() }
          );
            base.OnModelCreating(builder);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync(new System.Threading.CancellationToken());
        }
    }
}
