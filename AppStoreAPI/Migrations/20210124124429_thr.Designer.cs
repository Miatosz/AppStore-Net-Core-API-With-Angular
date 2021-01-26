﻿// <auto-generated />
using System;
using AppStoreAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppStoreAPI.Migrations
{
    [DbContext(typeof(AppStoreDbContext))]
    [Migration("20210124124429_thr")]
    partial class thr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AppStoreAPI.Models.AgeClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgeClassifications");
                });

            modelBuilder.Entity("AppStoreAPI.Models.App", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AgeClassificationId")
                        .HasColumnType("int");

                    b.Property<string>("DateOfLastUpdate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfUpload")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfDownloads")
                        .HasColumnType("int");

                    b.Property<int?>("PlatformId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgeClassificationId");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("PlatformId");

                    b.HasIndex("UserId");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("AppStoreAPI.Models.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("AppStoreAPI.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("AppStoreAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AppStoreAPI.Models.App", b =>
                {
                    b.HasOne("AppStoreAPI.Models.AgeClassification", "AgeClassification")
                        .WithMany()
                        .HasForeignKey("AgeClassificationId");

                    b.HasOne("AppStoreAPI.Models.Developer", "Developer")
                        .WithMany("Apps")
                        .HasForeignKey("DeveloperId");

                    b.HasOne("AppStoreAPI.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId");

                    b.HasOne("AppStoreAPI.Models.User", null)
                        .WithMany("Apps")
                        .HasForeignKey("UserId");

                    b.Navigation("AgeClassification");

                    b.Navigation("Developer");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("AppStoreAPI.Models.Developer", b =>
                {
                    b.Navigation("Apps");
                });

            modelBuilder.Entity("AppStoreAPI.Models.User", b =>
                {
                    b.Navigation("Apps");
                });
#pragma warning restore 612, 618
        }
    }
}
