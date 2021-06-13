﻿// <auto-generated />
using System;
using Diginovasi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diginovasi.Data.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20210613111118_ChangeSeveralEntityColumns")]
    partial class ChangeSeveralEntityColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Diginovasi.BusinessObjects.Masters.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("NoCustomer")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("NoKontak")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Diginovasi.BusinessObjects.Masters.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Deskripsi")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<decimal>("Harga")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Kode")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("SatuanId")
                        .HasColumnType("int");

                    b.Property<string>("UrlGambar")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("SatuanId");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("Diginovasi.BusinessObjects.Masters.Satuan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Deskripsi")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Kode")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Satuan");
                });

            modelBuilder.Entity("Diginovasi.BusinessObjects.Sales.SalesOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("NoSalesOrder")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("SalesOrder");
                });

            modelBuilder.Entity("Diginovasi.BusinessObjects.Sales.SalesOrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Jumlah")
                        .HasColumnType("int");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int?>("SalesOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("SalesOrderId");

                    b.ToTable("SalesOrderItems");
                });

            modelBuilder.Entity("Diginovasi.BusinessObjects.Masters.Material", b =>
                {
                    b.HasOne("Diginovasi.BusinessObjects.Masters.Satuan", "Satuan")
                        .WithMany("Materials")
                        .HasForeignKey("SatuanId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Diginovasi.BusinessObjects.Sales.SalesOrder", b =>
                {
                    b.HasOne("Diginovasi.BusinessObjects.Masters.Customer", "Customer")
                        .WithMany("SalesOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diginovasi.BusinessObjects.Sales.SalesOrderItem", b =>
                {
                    b.HasOne("Diginovasi.BusinessObjects.Masters.Material", "Material")
                        .WithMany("SalesOrderItems")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Diginovasi.BusinessObjects.Sales.SalesOrder", "SalesOrder")
                        .WithMany("SalesOrderItems")
                        .HasForeignKey("SalesOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
