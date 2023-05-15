﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VkParser.Data;

#nullable disable

namespace VkParser.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230515184451_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VkParser.Models.PostInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int[]>("Counters")
                        .HasColumnType("integer[]");

                    b.Property<char[]>("Letters")
                        .HasColumnType("character(1)[]");

                    b.Property<string>("VkDomain")
                        .HasColumnType("text");

                    b.Property<string>("VkUsername")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PostInfos");
                });
#pragma warning restore 612, 618
        }
    }
}