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
    public class OrderDbContext : DbContext, IOrderContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("order");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Order>().HasData(
              new Order { CustomerId = new Guid("db9f63c1-0c79-4613-83fc-6b19290c13a0"), ProductId = new Guid("f1d035d6-ab42-45a7-9eca-b6d8f62a6ad3"), OrderId = Guid.NewGuid() },
              new Order { CustomerId = new Guid("8bc775eb-ffa0-4a21-b223-ce3c102a2297"), ProductId = new Guid("7900152b-8c9d-4fb0-8982-85374984f9bb"), OrderId = Guid.NewGuid() }
          );
            base.OnModelCreating(builder);
        }



        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync(new System.Threading.CancellationToken());
        }
    }
}
