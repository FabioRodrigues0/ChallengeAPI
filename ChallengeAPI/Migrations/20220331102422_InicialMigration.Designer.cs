﻿// <auto-generated />
using System;
using ChallengeAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChallengeAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220331102422_InicialMigration")]
    partial class InicialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChallengeAPI.Models.DataInserted", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid?>("VeryBigSumId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VeryBigSumId");

                    b.ToTable("Inputs");
                });

            modelBuilder.Entity("ChallengeAPI.Models.VeryBigSum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("Output")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Sums");
                });

            modelBuilder.Entity("ChallengeAPI.Models.DataInserted", b =>
                {
                    b.HasOne("ChallengeAPI.Models.VeryBigSum", null)
                        .WithMany("Input")
                        .HasForeignKey("VeryBigSumId");
                });

            modelBuilder.Entity("ChallengeAPI.Models.VeryBigSum", b =>
                {
                    b.Navigation("Input");
                });
#pragma warning restore 612, 618
        }
    }
}