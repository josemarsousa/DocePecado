﻿// <auto-generated />
using System;
using DocePecado.Persistence;
using DocePecado.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DocePecado.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("DocePecado.Domain.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("DistrictId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("DocePecado.Domain.District", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<decimal>("PriceDelivery")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("DocePecado.Domain.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateDelivery")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateOrder")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Status")
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DocePecado.Domain.OrderProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("DocePecado.Domain.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DocePecado.Domain.Client", b =>
                {
                    b.HasOne("DocePecado.Domain.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");

                    b.Navigation("District");
                });

            modelBuilder.Entity("DocePecado.Domain.Order", b =>
                {
                    b.HasOne("DocePecado.Domain.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("DocePecado.Domain.OrderProduct", b =>
                {
                    b.HasOne("DocePecado.Domain.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId");

                    b.HasOne("DocePecado.Domain.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DocePecado.Domain.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DocePecado.Domain.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("DocePecado.Domain.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
