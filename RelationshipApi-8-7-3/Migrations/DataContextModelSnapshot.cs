﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelationshipApi_8_7_3.Data;

#nullable disable

namespace RelationshipApi_8_7_3.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RelationshipApi_8_7_3.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarRego")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarYear")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("RelationshipApi_8_7_3.Models.CarMake", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "MakeId");

                    b.HasIndex("MakeId");

                    b.ToTable("CarMakes");
                });

            modelBuilder.Entity("RelationshipApi_8_7_3.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("RelationshipApi_8_7_3.Models.Make", b =>
                {
                    b.Property<int>("MakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MakeId"));

                    b.Property<string>("MakeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MakeId");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("RelationshipApi_8_7_3.Models.Car", b =>
                {
                    b.HasOne("RelationshipApi_8_7_3.Models.Customer", "Customer")
                        .WithMany("Car")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RelationshipApi_8_7_3.Models.CarMake", b =>
                {
                    b.HasOne("RelationshipApi_8_7_3.Models.Car", "Car")
                        .WithMany("CarMake")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RelationshipApi_8_7_3.Models.Make", "Make")
                        .WithMany("CarMake")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Make");
                });

            modelBuilder.Entity("RelationshipApi_8_7_3.Models.Car", b =>
                {
                    b.Navigation("CarMake");
                });

            modelBuilder.Entity("RelationshipApi_8_7_3.Models.Customer", b =>
                {
                    b.Navigation("Car");
                });

            modelBuilder.Entity("RelationshipApi_8_7_3.Models.Make", b =>
                {
                    b.Navigation("CarMake");
                });
#pragma warning restore 612, 618
        }
    }
}
