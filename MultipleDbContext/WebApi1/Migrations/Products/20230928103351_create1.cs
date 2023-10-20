using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi1.Migrations.Products
{
    /// <inheritdoc />
    public partial class create1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "products");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "products",
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("059e78ff-5bec-4097-b0b2-13222491bf77"), "Product #1", 100m },
                    { new Guid("2c7fdb56-6319-4d23-a9aa-b1f41fe2716a"), "Product #3", 300m },
                    { new Guid("b3b19829-7250-4342-a41b-c31aee4eb14b"), "Product #2", 200m },
                    { new Guid("c01dd0e8-8236-4d22-a525-fb2a3d0e13fb"), "Product #4", 400m },
                    { new Guid("c7c45dee-2f06-4aa8-8b44-28a9132ee9ac"), "Product #5", 500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "products");
        }
    }
}
