﻿// <auto-generated />
using System;
using Enki.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Enki.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220926025925_SecureBoot")]
    partial class SecureBoot
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Enki.Domain.Models.Pilgrimage", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("ShrineId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "ShrineId");

                    b.HasIndex("ShrineId");

                    b.ToTable("Pilgrimages");

                    b.HasData(
                        new
                        {
                            UserId = 4L,
                            ShrineId = 1L
                        },
                        new
                        {
                            UserId = 4L,
                            ShrineId = 2L
                        },
                        new
                        {
                            UserId = 3L,
                            ShrineId = 1L
                        },
                        new
                        {
                            UserId = 2L,
                            ShrineId = 3L
                        },
                        new
                        {
                            UserId = 2L,
                            ShrineId = 2L
                        },
                        new
                        {
                            UserId = 1L,
                            ShrineId = 2L
                        });
                });

            modelBuilder.Entity("Enki.Domain.Models.Shrine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("ConstructionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShrineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shrines");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ConstructionDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeityName = "Poseidon",
                            ShrineName = "Ruin of Atlantis"
                        },
                        new
                        {
                            Id = 2L,
                            ConstructionDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeityName = "Odin",
                            ShrineName = "Valhalla"
                        },
                        new
                        {
                            Id = 3L,
                            ConstructionDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeityName = "Jesus",
                            ShrineName = "Nazareth"
                        });
                });

            modelBuilder.Entity("Enki.Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Order")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Email = "max.mcmann@mail.com",
                            Name = "Max",
                            Order = "Attorney",
                            Password = "6niXyt4vhoOWhG6N/Rje0e4wGrGndK0eSbahkJdu7kk=",
                            RegisteredOn = new DateTime(2022, 9, 26, 4, 59, 25, 450, DateTimeKind.Local).AddTicks(8861),
                            Surname = "McMann"
                        },
                        new
                        {
                            Id = 2L,
                            Email = "s.armstrong@mail.com",
                            Name = "S.",
                            Order = "Senator",
                            Password = "svbCoMlwN1Uv4JbSj4B7OzI2T/euRF+zJAnIRhP2gWI=",
                            RegisteredOn = new DateTime(2022, 9, 26, 4, 59, 25, 457, DateTimeKind.Local).AddTicks(7791),
                            Surname = "Armstrong"
                        },
                        new
                        {
                            Id = 3L,
                            Email = "claire.redfield@mail.com",
                            Name = "Jill",
                            Order = "S.T.A.R.S",
                            Password = "6niXyt4vhoOWhG6N/Rje0e4wGrGndK0eSbahkJdu7kk=",
                            RegisteredOn = new DateTime(2022, 9, 26, 4, 59, 25, 464, DateTimeKind.Local).AddTicks(7153),
                            Surname = "Valentine"
                        },
                        new
                        {
                            Id = 4L,
                            Email = "gura.gawr@mail.com",
                            Name = "Gura",
                            Order = "Shark Girl Idol",
                            Password = "m2BvrMF5k4zIxPCduBv2IWQO+EPwcQOkyxC9VjpJ1HE=",
                            RegisteredOn = new DateTime(2022, 9, 26, 4, 59, 25, 471, DateTimeKind.Local).AddTicks(5379),
                            Surname = "Gawr"
                        });
                });

            modelBuilder.Entity("Enki.Domain.Models.Pilgrimage", b =>
                {
                    b.HasOne("Enki.Domain.Models.Shrine", "Shrine")
                        .WithMany()
                        .HasForeignKey("ShrineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Enki.Domain.Models.User", "User")
                        .WithMany("Pilgrimages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shrine");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Enki.Domain.Models.User", b =>
                {
                    b.Navigation("Pilgrimages");
                });
#pragma warning restore 612, 618
        }
    }
}
