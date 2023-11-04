using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorEcommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesAndRealMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "33kVbtpYUle1JYG", "https://movingimage.us/wp-content/uploads/2022/02/JMTH-Stills_1.9.1-600x300.jpg", 7m, "us+qy" },
                    { 2, "t/SRnOlxRaDSZzB", "https://movingimage.us/wp-content/uploads/2022/09/Armageddon_1-600x300.jpg", 97m, "kJyuQ" },
                    { 3, "HvmenOT0u0TxwfP", "https://movingimage.us/wp-content/uploads/2023/01/All-the-Beauty-600x300.jpg", 25m, "FAsaM" },
                    { 4, "c7Y6TXA/t5QYF1G", "https://movingimage.us/wp-content/uploads/2022/11/the-rehearsal-600x300.jpg", 16m, "Fx7Fm" },
                    { 5, "OuNxYL+U+fbYrAt", "https://movingimage.us/wp-content/uploads/2022/12/lastflight-600x300.jpg", 84m, "39KGy" }
                });
        }
    }
}
