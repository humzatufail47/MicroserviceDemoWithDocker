using MicroService.Users.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Users.Data.DataContext.Interface
{
   public interface IOrderContext
    {
        public DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync();
    }
}
