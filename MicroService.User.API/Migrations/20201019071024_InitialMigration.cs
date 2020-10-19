using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.User.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "users",
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "users",
                table: "Users",
                columns: new[] { "Id", "Age", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { new Guid("db9f63c1-0c79-4613-83fc-6b19290c13a0"), 25, "Humza", "Male", "Tufail" },
                    { new Guid("3617ee5c-9c6d-406e-b724-2129563bb767"), 25, "Salman", "Male", "AK" },
                    { new Guid("8bc775eb-ffa0-4a21-b223-ce3c102a2297"), 25, "Hadid", "Male", "Ali" },
                    { new Guid("3b0b55eb-7c17-45eb-86f1-28dfbd9e521d"), 25, "Zeeshan", "Male", "Khan" },
                    { new Guid("eb6f882b-f54d-45ea-a922-b3f3adf2bc8b"), 25, "Amaid", "Male", "Haider" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Users",
                schema: "users");
        }
    }
}
