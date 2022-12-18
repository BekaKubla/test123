﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication5.Data;

namespace WebApplication5.Migrations
{
    [DbContext(typeof(ScrapperDbContext))]
    partial class ScrapperDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApplication5.Models.ScrapperLinkModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<short>("PageCount")
                        .HasColumnType("smallint");

                    b.Property<string>("ScrapperUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteType")
                        .HasColumnType("int");

                    b.Property<int>("StatementType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ScrapperLink");
                });

            modelBuilder.Entity("WebApplication5.Models.ScrapperModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsideMethodTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("JobCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PriceInUsd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceOneSquareMeter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SquareMeter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatementType")
                        .HasColumnType("int");

                    b.Property<string>("WebSiteName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Scrapper");
                });
#pragma warning restore 612, 618
        }
    }
}
