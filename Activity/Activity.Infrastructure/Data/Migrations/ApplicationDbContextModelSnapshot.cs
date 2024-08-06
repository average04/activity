﻿// <auto-generated />
using System;
using Activity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Activity.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Activity.Domain.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnOrder(0);

                    b.Property<double>("AveragePace")
                        .HasColumnType("double")
                        .HasColumnOrder(7);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<double>("Distance")
                        .HasColumnType("double")
                        .HasColumnOrder(5);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time(6)")
                        .HasColumnOrder(6);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnOrder(4);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnOrder(3);

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Activity.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnOrder(0);

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnOrder(5);

                    b.Property<decimal>("BMI")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)")
                        .HasColumnOrder(6);

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnOrder(4);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Height")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(1);

                    b.Property<decimal>("Weight")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Activity.Domain.Activity", b =>
                {
                    b.HasOne("Activity.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
