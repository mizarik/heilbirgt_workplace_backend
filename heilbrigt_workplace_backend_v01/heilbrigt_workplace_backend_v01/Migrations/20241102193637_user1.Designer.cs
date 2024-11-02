﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using heilbrigt_workplace_backend_v01.EntityFramework.Context;

#nullable disable

namespace heilbrigt_workplace_backend_v01.Migrations
{
    [DbContext(typeof(HeilbrigtContext))]
    [Migration("20241102193637_user1")]
    partial class user1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("heilbrigt_workplace_backend_v01.EntityFramework.Models.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("userAddDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("userFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("userInternalId")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("varchar(17)");

                    b.Property<bool>("userIsActiveated")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("userLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("userMail")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("varchar(125)");

                    b.Property<string>("userPasswordHash")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("varchar(350)");

                    b.Property<string>("userSessionId")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}