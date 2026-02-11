using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CadastroProdutos.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Estoque", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, 15, "Notebook Dell Inspiron", 3499.99m },
                    { 2, 50, "Mouse Logitech MX Master", 349.90m },
                    { 3, 30, "Teclado Mecânico Keychron", 599.00m },
                    { 4, 12, "Monitor LG 27 UltraWide", 1899.00m },
                    { 5, 25, "Headset HyperX Cloud II", 459.99m },
                    { 6, 40, "SSD Samsung 1TB", 499.00m },
                    { 7, 18, "Webcam Logitech C920", 389.90m },
                    { 8, 8, "Cadeira Gamer DT3 Sports", 1299.00m },
                    { 9, 10, "Mesa Digitalizadora Wacom", 899.00m },
                    { 10, 35, "Hub USB-C 7 em 1", 199.90m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
