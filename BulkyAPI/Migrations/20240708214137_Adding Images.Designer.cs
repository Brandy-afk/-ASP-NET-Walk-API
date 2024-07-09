﻿// <auto-generated />
using System;
using BulkyAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BulkyAPI.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    [Migration("20240708214137_Adding Images")]
    partial class AddingImages
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BulkyAPI.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("896b448c-5cf9-4a82-ae3b-01fd46edac99"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("aa6fb312-9fb1-4c9c-913a-12a4edf35b00"),
                            Name = "Moderate"
                        },
                        new
                        {
                            Id = new Guid("efddc1a2-d94c-495b-9189-64c8d6834d53"),
                            Name = "Difficult"
                        },
                        new
                        {
                            Id = new Guid("6e3f2077-2e44-47c7-9c6e-53612cbb7ba6"),
                            Name = "Extreme"
                        });
                });

            modelBuilder.Entity("BulkyAPI.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FileDescription")
                        .HasColumnType("text");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("BulkyAPI.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dfedcad8-2660-4f5c-b0af-8b42043544fc"),
                            Code = "NA",
                            Name = "North America",
                            RegionImageUrl = "https://example.com/northamerica.jpg"
                        },
                        new
                        {
                            Id = new Guid("1f697779-3046-443b-b26e-13dcc9da939e"),
                            Code = "EU",
                            Name = "Europe",
                            RegionImageUrl = "https://example.com/europe.jpg"
                        },
                        new
                        {
                            Id = new Guid("26fd3ddf-172d-41f3-8ea9-3a7e883323f5"),
                            Code = "AS",
                            Name = "Asia",
                            RegionImageUrl = "https://example.com/asia.jpg"
                        },
                        new
                        {
                            Id = new Guid("94aa9313-4299-413a-965e-a2aca0eb54cd"),
                            Code = "AF",
                            Name = "Africa",
                            RegionImageUrl = "https://example.com/africa.jpg"
                        },
                        new
                        {
                            Id = new Guid("0bb2032d-0ad2-4798-8b71-29660805951f"),
                            Code = "SA",
                            Name = "South America",
                            RegionImageUrl = "https://example.com/southamerica.jpg"
                        });
                });

            modelBuilder.Entity("BulkyAPI.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DifficultyID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ImageID")
                        .HasColumnType("uuid");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RegionID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyID");

                    b.HasIndex("ImageID");

                    b.HasIndex("RegionID");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("BulkyAPI.Models.Domain.Walk", b =>
                {
                    b.HasOne("BulkyAPI.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BulkyAPI.Models.Domain.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageID");

                    b.HasOne("BulkyAPI.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Image");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
