using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.Users.Order.APIs.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "order");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "order",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "order",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 250, nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "order",
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
                schema: "order",
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "ProductId" },
                values: new object[] { new Guid("4836f1ba-2ec3-44c1-9d10-7d88805d92c9"), new Guid("db9f63c1-0c79-4613-83fc-6b19290c13a0"), new Guid("f1d035d6-ab42-45a7-9eca-b6d8f62a6ad3") });

            migrationBuilder.InsertData(
                schema: "order",
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "ProductId" },
                values: new object[] { new Guid("652d29b9-a617-484a-bc35-80f2a74964d6"), new Guid("8bc775eb-ffa0-4a21-b223-ce3c102a2297"), new Guid("7900152b-8c9d-4fb0-8982-85374984f9bb") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders",
                schema: "order");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "order");

            migrationBuilder.DropTable(
                name: "User",
                schema: "order");
        }
    }
}
