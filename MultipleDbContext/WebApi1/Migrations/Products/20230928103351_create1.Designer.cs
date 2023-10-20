﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi1.Products;

#nullable disable

namespace WebApi1.Migrations.Products
{
    [DbContext(typeof(ProductsDbContext))]
    [Migration("20230928103351_create1")]
    partial class create1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("products")
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi1.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products", "products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("059e78ff-5bec-4097-b0b2-13222491bf77"),
                            Name = "Product #1",
                            Price = 100m
                        },
                        new
                        {
                            Id = new Guid("b3b19829-7250-4342-a41b-c31aee4eb14b"),
                            Name = "Product #2",
                            Price = 200m
                        },
                        new
                        {
                            Id = new Guid("2c7fdb56-6319-4d23-a9aa-b1f41fe2716a"),
                            Name = "Product #3",
                            Price = 300m
                        },
                        new
                        {
                            Id = new Guid("c01dd0e8-8236-4d22-a525-fb2a3d0e13fb"),
                            Name = "Product #4",
                            Price = 400m
                        },
                        new
                        {
                            Id = new Guid("c7c45dee-2f06-4aa8-8b44-28a9132ee9ac"),
                            Name = "Product #5",
                            Price = 500m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
