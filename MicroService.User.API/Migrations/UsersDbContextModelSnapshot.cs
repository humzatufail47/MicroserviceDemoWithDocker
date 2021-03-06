﻿// <auto-generated />
using System;
using MicroService.Users.Data.DataContext.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MicroService.User.API.Migrations
{
    [DbContext(typeof(UsersDbContext))]
    partial class UsersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("users")
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MicroService.Users.Data.Models.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MicroService.Users.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("db9f63c1-0c79-4613-83fc-6b19290c13a0"),
                            Age = 25,
                            FirstName = "Humza",
                            Gender = "Male",
                            LastName = "Tufail"
                        },
                        new
                        {
                            Id = new Guid("3617ee5c-9c6d-406e-b724-2129563bb767"),
                            Age = 25,
                            FirstName = "Salman",
                            Gender = "Male",
                            LastName = "AK"
                        },
                        new
                        {
                            Id = new Guid("8bc775eb-ffa0-4a21-b223-ce3c102a2297"),
                            Age = 25,
                            FirstName = "Hadid",
                            Gender = "Male",
                            LastName = "Ali"
                        },
                        new
                        {
                            Id = new Guid("3b0b55eb-7c17-45eb-86f1-28dfbd9e521d"),
                            Age = 25,
                            FirstName = "Zeeshan",
                            Gender = "Male",
                            LastName = "Khan"
                        },
                        new
                        {
                            Id = new Guid("eb6f882b-f54d-45ea-a922-b3f3adf2bc8b"),
                            Age = 25,
                            FirstName = "Amaid",
                            Gender = "Male",
                            LastName = "Haider"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
