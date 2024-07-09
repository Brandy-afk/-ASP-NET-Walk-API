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
    [Migration("20240708150224_Seeding")]
    partial class Seeding
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
                            Id = new Guid("17e417cf-9ed9-415c-a5dc-3ba9d3711e95"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("7dc01279-5319-4799-9001-66b3c59abb84"),
                            Name = "Moderate"
                        },
                        new
                        {
                            Id = new Guid("bf4f135a-54ba-4d09-aba4-f128d3b3fbe2"),
                            Name = "Difficult"
                        },
                        new
                        {
                            Id = new Guid("92e2814e-7410-402b-a365-86ae9dd00865"),
                            Name = "Extreme"
                        });
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
                            Id = new Guid("0115a2b7-069a-4178-9854-d74c67198d68"),
                            Code = "NA",
                            Name = "North America",
                            RegionImageUrl = "https://example.com/northamerica.jpg"
                        },
                        new
                        {
                            Id = new Guid("bd59c495-71f4-4c52-b616-5cafa2a9feff"),
                            Code = "EU",
                            Name = "Europe",
                            RegionImageUrl = "https://example.com/europe.jpg"
                        },
                        new
                        {
                            Id = new Guid("f35513a5-4835-4d35-8f44-b4f99f94f555"),
                            Code = "AS",
                            Name = "Asia",
                            RegionImageUrl = "https://example.com/asia.jpg"
                        },
                        new
                        {
                            Id = new Guid("69e40f4a-3676-4fe5-88db-0890cfcd4316"),
                            Code = "AF",
                            Name = "Africa",
                            RegionImageUrl = "https://example.com/africa.jpg"
                        },
                        new
                        {
                            Id = new Guid("0b5ab2da-4c9f-453a-89d2-08ff9ee06323"),
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

                    b.Property<double>("LengthInKm")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RegionID")
                        .HasColumnType("uuid");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyID");

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

                    b.HasOne("BulkyAPI.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
