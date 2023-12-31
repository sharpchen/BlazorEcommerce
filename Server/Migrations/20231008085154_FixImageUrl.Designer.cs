﻿// <auto-generated />
using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231008085154_FixImageUrl")]
    partial class FixImageUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorEcommerce.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Movies",
                            Url = "movies"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Books",
                            Url = "books"
                        },
                        new
                        {
                            Id = 3,
                            Name = "VideoGames",
                            Url = "video-games"
                        });
                });

            modelBuilder.Entity("BlazorEcommerce.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "The Philadelphia Story is a 1940 American romantic comedy film directed by George Cukor, starring Cary Grant, Katharine Hepburn, James Stewart, and Ruth Hussey. Based on the 1939 Broadway play of the same name by Philip Barry,[4] the film is about a socialite whose wedding plans are complicated by the simultaneous arrival of her ex-husband and a tabloid magazine journalist. The socialite character of the play—performed by Hepburn in the film—was inspired by Helen Hope Montgomery Scott (1904–1995), a Philadelphia socialite known for her hijinks, who married a friend of playwright Barry.",
                            ImageUrl = "https://img2.doubanio.com/view/photo/l/public/p740274403.webp",
                            Price = 32.92m,
                            Title = "The Philadelphia Story"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Seven Samurai (Japanese: 七人の侍, Hepburn: Shichinin no Samurai) is a 1954 Japanese epic samurai film co-written, edited, and directed by Akira Kurosawa. Taking place in 1586[a] in the Sengoku period of Japanese history, it follows the story of a village of desperate farmers who seek to hire rōnin (masterless samurai) to combat bandits who will return after the harvest to steal their crops.\r\n\r\nAt the time, the film was the most expensive film made in Japan. It took a year to shoot and faced many difficulties. It was the second-highest-grossing domestic film in Japan in 1954. Many reviews compared the film to westerns.",
                            ImageUrl = "https://img9.doubanio.com/view/photo/l/public/p2215886505.webp",
                            Price = 63.36m,
                            Title = "Seven Samurai"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Singin' in the Rain is a 1952 American musical romantic comedy film directed and choreographed by Gene Kelly and Stanley Donen, starring Kelly, Donald O'Connor, and Debbie Reynolds and featuring Jean Hagen, Millard Mitchell and Cyd Charisse. It offers a lighthearted depiction of Hollywood in the late 1920s, with the three stars portraying performers caught up in the transition from silent films to \"talkies\".",
                            ImageUrl = "https://img9.doubanio.com/view/photo/l/public/p1612355875.webp",
                            Price = 82.26m,
                            Title = "Singin' in the Rain"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "Throne of Blood (Japanese: 蜘蛛巣城, Hepburn: Kumonosu-jō, lit. 'The Castle of Spider's Web') is a 1957 Japanese jidaigeki film co-written, produced, edited, and directed by Akira Kurosawa, with special effects by Eiji Tsuburaya. The film transposes the plot of William Shakespeare's play Macbeth from Medieval Scotland to feudal Japan, with stylistic elements drawn from Noh drama. The film stars Toshiro Mifune and Isuzu Yamada in the lead roles, modelled on the characters Macbeth and Lady Macbeth.\r\n\r\nAs with the play, the film tells the story of a warrior who assassinates his sovereign at the urging of his ambitious wife. Kurosawa was a fan of the play and intended to make his own adaptation for several years, delaying it after learning of Orson Welles' Macbeth (1948). Among his changes was the ending, which required archers to fire arrows around Mifune. The film was shot around Mount Fuji and Izu Peninsula.",
                            ImageUrl = "https://img2.doubanio.com/view/photo/l/public/p2640721072.webp",
                            Price = 46.81m,
                            Title = "Throne of Blood"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "2001: A Space Odyssey is a 1968 epic science fiction film produced and directed by Stanley Kubrick. The screenplay was written by Kubrick and science fiction author Arthur C. Clarke, and was inspired by Clarke's 1951 short story \"The Sentinel\" and other short stories by Clarke. Clarke also published a novelisation of the film, in part written concurrently with the screenplay, after the film's release. The film stars Keir Dullea, Gary Lockwood, William Sylvester, and Douglas Rain and follows a voyage by astronauts, scientists, and the sentient supercomputer HAL to Jupiter to investigate an alien monolith.\r\n\r\nThe film is noted for its scientifically accurate depiction of space flight, pioneering special effects, and ambiguous imagery. Kubrick avoided conventional cinematic and narrative techniques; dialogue is used sparingly, and there are long sequences accompanied only by music. The soundtrack incorporates numerous works of classical music, including pieces by composers such as Richard Strauss, Johann Strauss II, Aram Khachaturian, and György Ligeti.",
                            ImageUrl = "https://img9.doubanio.com/view/photo/l/public/p2560717825.webp",
                            Price = 86.24m,
                            Title = "2001: A Space Odyssey"
                        });
                });

            modelBuilder.Entity("BlazorEcommerce.Shared.Product", b =>
                {
                    b.HasOne("BlazorEcommerce.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
