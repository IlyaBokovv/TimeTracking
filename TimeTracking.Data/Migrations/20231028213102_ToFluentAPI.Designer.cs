﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TimeTracking.Data;

#nullable disable

namespace TimeTracking.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231028213102_ToFluentAPI")]
    partial class ToFluentAPI
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TimeTracking.Data.Models.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ReportId");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("WorkedHours")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");

                    b.HasData(
                        new
                        {
                            Id = new Guid("db0abfe7-bf93-41fa-a537-396e76faaced"),
                            Date = new DateOnly(2023, 9, 15),
                            Description = "Regular job",
                            UserId = new Guid("da9d87e1-f84a-484a-997d-bea07b6fa9ea"),
                            WorkedHours = 8
                        },
                        new
                        {
                            Id = new Guid("33502293-c17a-4ef8-ac61-75c62ecde637"),
                            Date = new DateOnly(2023, 9, 15),
                            Description = "Extra hours",
                            UserId = new Guid("da9d87e1-f84a-484a-997d-bea07b6fa9ea"),
                            WorkedHours = 3
                        },
                        new
                        {
                            Id = new Guid("b541ca9d-7257-47be-b812-5bbdbb588216"),
                            Date = new DateOnly(2023, 9, 15),
                            Description = "Regular job",
                            UserId = new Guid("20da4841-4a17-42e6-bd69-6a7025160082"),
                            WorkedHours = 8
                        });
                });

            modelBuilder.Entity("TimeTracking.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("20da4841-4a17-42e6-bd69-6a7025160082"),
                            Email = "testmail@mail.ru",
                            FirstName = "Elon",
                            LastName = "Musk",
                            MiddleName = "Viktorovich"
                        },
                        new
                        {
                            Id = new Guid("da9d87e1-f84a-484a-997d-bea07b6fa9ea"),
                            Email = "testmail@yandex.ru",
                            FirstName = "Vladimir",
                            LastName = "Lenin",
                            MiddleName = "Ilyich"
                        });
                });

            modelBuilder.Entity("TimeTracking.Data.Models.Report", b =>
                {
                    b.HasOne("TimeTracking.Data.Models.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TimeTracking.Data.Models.User", b =>
                {
                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
