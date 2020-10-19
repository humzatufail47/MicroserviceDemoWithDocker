using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Users.Data.Models.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public  void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Age).IsRequired();
            builder.Property(t => t.FirstName).HasMaxLength(250).IsRequired();
            builder.Property(t => t.LastName).HasMaxLength(250).IsRequired();
            builder.Property(t => t.Gender).HasMaxLength(30);
        }
    }
}
