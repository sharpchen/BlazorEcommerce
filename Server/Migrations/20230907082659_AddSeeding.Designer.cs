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
    [Migration("20230907082659_AddSeeding")]
    partial class AddSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorEcommerce.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "33kVbtpYUle1JYG",
                            ImageUrl = "https://movingimage.us/wp-content/uploads/2022/02/JMTH-Stills_1.9.1-600x300.jpg",
                            Price = 7m,
                            Title = "us+qy"
                        },
                        new
                        {
                            Id = 2,
                            Description = "t/SRnOlxRaDSZzB",
                            ImageUrl = "https://movingimage.us/wp-content/uploads/2022/09/Armageddon_1-600x300.jpg",
                            Price = 97m,
                            Title = "kJyuQ"
                        },
                        new
                        {
                            Id = 3,
                            Description = "HvmenOT0u0TxwfP",
                            ImageUrl = "https://movingimage.us/wp-content/uploads/2023/01/All-the-Beauty-600x300.jpg",
                            Price = 25m,
                            Title = "FAsaM"
                        },
                        new
                        {
                            Id = 4,
                            Description = "c7Y6TXA/t5QYF1G",
                            ImageUrl = "https://movingimage.us/wp-content/uploads/2022/11/the-rehearsal-600x300.jpg",
                            Price = 16m,
                            Title = "Fx7Fm"
                        },
                        new
                        {
                            Id = 5,
                            Description = "OuNxYL+U+fbYrAt",
                            ImageUrl = "https://movingimage.us/wp-content/uploads/2022/12/lastflight-600x300.jpg",
                            Price = 84m,
                            Title = "39KGy"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
