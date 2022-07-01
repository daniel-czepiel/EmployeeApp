﻿// <auto-generated />
using System;
using EmployeeApp.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeApp.Data.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    partial class EmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.5.22302.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeApp.Data.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EmployeeApp.Data.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("LiderId")
                        .HasColumnType("int");

                    b.Property<int?>("LiderId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LiderId");

                    b.HasIndex("LiderId1");

                    b.ToTable("EmailAdressess");
                });

            modelBuilder.Entity("EmployeeApp.Data.Models.PersonBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PersonBase");
                });

            modelBuilder.Entity("EmployeeApp.Data.Models.Employee", b =>
                {
                    b.HasBaseType("EmployeeApp.Data.Models.PersonBase");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("EmployeeApp.Data.Models.Lider", b =>
                {
                    b.HasBaseType("EmployeeApp.Data.Models.PersonBase");

                    b.HasDiscriminator().HasValue("Lider");
                });

            modelBuilder.Entity("EmployeeApp.Data.Models.Email", b =>
                {
                    b.HasOne("EmployeeApp.Data.Models.Employee", null)
                        .WithMany("EmailAdressess")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("EmployeeApp.Data.Models.Lider", null)
                        .WithMany("EmailAdressess")
                        .HasForeignKey("LiderId");

                    b.HasOne("EmployeeApp.Data.Models.Lider", null)
                        .WithMany("Employees")
                        .HasForeignKey("LiderId1");
                });

            modelBuilder.Entity("EmployeeApp.Data.Models.Employee", b =>
                {
                    b.Navigation("EmailAdressess");
                });

            modelBuilder.Entity("EmployeeApp.Data.Models.Lider", b =>
                {
                    b.Navigation("EmailAdressess");

                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
