using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.Users.Product.APIs.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "product");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 250, nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 250, nullable: false),
                    LastName = table.Column<string>(maxLength: 250, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "product",
                table: "Products",
                columns: new[] { "ProductId", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { new Guid("f1d035d6-ab42-45a7-9eca-b6d8f62a6ad3"), "Samsung Galaxy s20", 20 },
                    { new Guid("db12837b-acd8-489d-aaa0-88afba3aaac4"), "Samsung Galaxy s10", 20 },
                    { new Guid("fe1ce873-e25c-4d4c-a0a4-1cee847947a1"), "Samsung Galaxy Note 10+", 15 },
                    { new Guid("7900152b-8c9d-4fb0-8982-85374984f9bb"), "Samsung Galaxy Note 9+", 10 },
                    { new Guid("5d81e588-e9e5-48f3-af8a-4f9f2f8ba4e7"), "OnePlus7T prp", 15 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "product");

            migrationBuilder.DropTable(
                name: "User",
                schema: "product");
        }
    }
}
