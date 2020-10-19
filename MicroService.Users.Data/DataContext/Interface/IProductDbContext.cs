using MicroService.Users.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Users.Data.DataContext.Interface
{
    public interface IProductDbContext
    {
        public DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync();
    }
}
