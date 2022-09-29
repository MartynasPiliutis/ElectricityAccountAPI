﻿// <auto-generated />
using System;
using ElectricityAccountAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElectricityAccountAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElectricityAccountAPI.Models.AggregatedData", b =>
                {
                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    b.Property<string>("ObjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjectType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PowerConsume")
                        .HasColumnType("float");

                    b.Property<double>("PowerDifference")
                        .HasColumnType("float");

                    b.Property<double>("PowerGenerate")
                        .HasColumnType("float");

                    b.Property<string>("PowerGrid")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("AggregatedDatas");
                });
#pragma warning restore 612, 618
        }
    }
}