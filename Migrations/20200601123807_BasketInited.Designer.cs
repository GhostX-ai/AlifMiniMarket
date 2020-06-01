﻿// <auto-generated />
using System;
using AlifAdminMiniMarketV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlifAdminMiniMarketV2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200601123807_BasketInited")]
    partial class BasketInited
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("AlifAdminMiniMarketV2.Models.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeliverTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Numbers")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("AlifAdminMiniMarketV2.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int?>("ProductCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AlifAdminMiniMarketV2.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Фрукты"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Овощи"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Мясо"
                        });
                });

            modelBuilder.Entity("AlifAdminMiniMarketV2.Models.Basket", b =>
                {
                    b.HasOne("AlifAdminMiniMarketV2.Models.Product", "Product")
                        .WithMany("Basket")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("AlifAdminMiniMarketV2.Models.Product", b =>
                {
                    b.HasOne("AlifAdminMiniMarketV2.Models.ProductCategory", "ProductCategory")
                        .WithMany("Product")
                        .HasForeignKey("ProductCategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}