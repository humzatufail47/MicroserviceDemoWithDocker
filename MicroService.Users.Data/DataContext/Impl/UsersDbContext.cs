using MicroService.Users.Data.DataContext.Interface;
using MicroService.Users.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace MicroService.Users.Data.DataContext.Impl
{
    public class UsersDbContext:DbContext,IUsersDbConext
    {

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("users");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<User>().HasData(
               new User { FirstName = "Humza", LastName = "Tufail", Age = 25, Gender = "Male", Id = Guid.NewGuid() },
               new User { FirstName = "Salman", LastName = "AK", Age = 25, Gender = "Male", Id = Guid.NewGuid() },
               new User { FirstName = "Hadid", LastName = "Ali", Age = 25, Gender = "Male", Id = Guid.NewGuid() },
               new User { FirstName = "Zeeshan", LastName = "Khan", Age = 25, Gender = "Male", Id = Guid.NewGuid() },
               new User { FirstName = "Amaid", LastName = "Haider", Age = 25, Gender = "Male", Id = Guid.NewGuid() }

           );
            base.OnModelCreating(builder);
        }
        public  Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync(new System.Threading.CancellationToken());
        }

    }
}
