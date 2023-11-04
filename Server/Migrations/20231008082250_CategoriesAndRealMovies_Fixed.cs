using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorEcommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesAndRealMovies_Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Movies", "movies" },
                    { 2, "Books", "books" },
                    { 3, "VideoGames", "video-games" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "The Philadelphia Story is a 1940 American romantic comedy film directed by George Cukor, starring Cary Grant, Katharine Hepburn, James Stewart, and Ruth Hussey. Based on the 1939 Broadway play of the same name by Philip Barry,[4] the film is about a socialite whose wedding plans are complicated by the simultaneous arrival of her ex-husband and a tabloid magazine journalist. The socialite character of the play—performed by Hepburn in the film—was inspired by Helen Hope Montgomery Scott (1904–1995), a Philadelphia socialite known for her hijinks, who married a friend of playwright Barry.", "https://movie.douban.com/photos/photo/740274403/", 101.31m, "The Philadelphia Story" },
                    { 2, 1, "Seven Samurai (Japanese: 七人の侍, Hepburn: Shichinin no Samurai) is a 1954 Japanese epic samurai film co-written, edited, and directed by Akira Kurosawa. Taking place in 1586[a] in the Sengoku period of Japanese history, it follows the story of a village of desperate farmers who seek to hire rōnin (masterless samurai) to combat bandits who will return after the harvest to steal their crops.\r\n\r\nAt the time, the film was the most expensive film made in Japan. It took a year to shoot and faced many difficulties. It was the second-highest-grossing domestic film in Japan in 1954. Many reviews compared the film to westerns.", "https://movie.douban.com/photos/photo/2215886505/", 31.05m, "Seven Samurai" },
                    { 3, 1, "Singin' in the Rain is a 1952 American musical romantic comedy film directed and choreographed by Gene Kelly and Stanley Donen, starring Kelly, Donald O'Connor, and Debbie Reynolds and featuring Jean Hagen, Millard Mitchell and Cyd Charisse. It offers a lighthearted depiction of Hollywood in the late 1920s, with the three stars portraying performers caught up in the transition from silent films to \"talkies\".", "https://movie.douban.com/photos/photo/1612355875/", 79.12m, "Singin' in the Rain" },
                    { 4, 1, "Throne of Blood (Japanese: 蜘蛛巣城, Hepburn: Kumonosu-jō, lit. 'The Castle of Spider's Web') is a 1957 Japanese jidaigeki film co-written, produced, edited, and directed by Akira Kurosawa, with special effects by Eiji Tsuburaya. The film transposes the plot of William Shakespeare's play Macbeth from Medieval Scotland to feudal Japan, with stylistic elements drawn from Noh drama. The film stars Toshiro Mifune and Isuzu Yamada in the lead roles, modelled on the characters Macbeth and Lady Macbeth.\r\n\r\nAs with the play, the film tells the story of a warrior who assassinates his sovereign at the urging of his ambitious wife. Kurosawa was a fan of the play and intended to make his own adaptation for several years, delaying it after learning of Orson Welles' Macbeth (1948). Among his changes was the ending, which required archers to fire arrows around Mifune. The film was shot around Mount Fuji and Izu Peninsula.", "https://movie.douban.com/photos/photo/2640721072/", 58.62m, "Throne of Blood" },
                    { 5, 1, "2001: A Space Odyssey is a 1968 epic science fiction film produced and directed by Stanley Kubrick. The screenplay was written by Kubrick and science fiction author Arthur C. Clarke, and was inspired by Clarke's 1951 short story \"The Sentinel\" and other short stories by Clarke. Clarke also published a novelisation of the film, in part written concurrently with the screenplay, after the film's release. The film stars Keir Dullea, Gary Lockwood, William Sylvester, and Douglas Rain and follows a voyage by astronauts, scientists, and the sentient supercomputer HAL to Jupiter to investigate an alien monolith.\r\n\r\nThe film is noted for its scientifically accurate depiction of space flight, pioneering special effects, and ambiguous imagery. Kubrick avoided conventional cinematic and narrative techniques; dialogue is used sparingly, and there are long sequences accompanied only by music. The soundtrack incorporates numerous works of classical music, including pieces by composers such as Richard Strauss, Johann Strauss II, Aram Khachaturian, and György Ligeti.", "https://movie.douban.com/photos/photo/2560717825/", 41.1m, "2001: A Space Odyssey" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");
        }
    }
}
