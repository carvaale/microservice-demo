﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using catalog_svc.Data;

#nullable disable

namespace catalog_svc.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    [Migration("20240409144302_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("catalog_svc.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CatalogBrands");
                });

            modelBuilder.Entity("catalog_svc.Models.CatalogItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AvailableStock")
                        .HasColumnType("integer");

                    b.Property<Guid>("CatalogBrandId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MaxStockThreshold")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("OnReorder")
                        .HasColumnType("boolean");

                    b.Property<string>("PictureFileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureUri")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("RestockThreshold")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CatalogBrandId");

                    b.ToTable("CatalogItems");
                });

            modelBuilder.Entity("catalog_svc.Models.CatalogItem", b =>
                {
                    b.HasOne("catalog_svc.Models.Brand", "CatalogBrand")
                        .WithMany("CatalogItems")
                        .HasForeignKey("CatalogBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogBrand");
                });

            modelBuilder.Entity("catalog_svc.Models.Brand", b =>
                {
                    b.Navigation("CatalogItems");
                });
#pragma warning restore 612, 618
        }
    }
}
