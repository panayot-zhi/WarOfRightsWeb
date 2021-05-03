﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarOfRightsWeb.Data;

namespace WarOfRightsWeb.Data.Migrations
{
    [DbContext(typeof(WarOfRightsDbContext))]
    [Migration("20210503134802_RegimentOrder")]
    partial class RegimentOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WarOfRightsWeb.Data.Map", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("AreaName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<decimal?>("CaptureSpeed")
                        .HasColumnType("DECIMAL(6,4)");

                    b.Property<string>("DateTimeDescription")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("DefendingTeam")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FinalPushTime")
                        .HasColumnType("int");

                    b.Property<string>("LoadingImagePath")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<decimal?>("NeutralizeSpeed")
                        .HasColumnType("DECIMAL(6,4)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int?>("RoundTime")
                        .HasColumnType("int");

                    b.Property<string>("SkirmishImagePath")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("SpawnImagePath")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int?>("TicketsCSA")
                        .HasColumnType("int");

                    b.Property<int?>("TicketsUSA")
                        .HasColumnType("int");

                    b.Property<decimal?>("TransferOnDeath")
                        .HasColumnType("DECIMAL(6,4)");

                    b.Property<int?>("WaveTime")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("WarOfRightsWeb.Data.MapRegiment", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("MapID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("RegimentID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("RegimentID");

                    b.HasIndex("MapID", "RegimentID")
                        .IsUnique();

                    b.ToTable("MapRegiment");
                });

            modelBuilder.Entity("WarOfRightsWeb.Data.MapRegimentWeapon", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<string>("MapRegimentID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int?>("Percent")
                        .HasColumnType("int");

                    b.Property<string>("WeaponID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("WeaponID");

                    b.HasIndex("MapRegimentID", "WeaponID")
                        .IsUnique();

                    b.ToTable("MapRegimentWeapon");
                });

            modelBuilder.Entity("WarOfRightsWeb.Data.Regiment", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Faction")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Number")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("State")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.HasKey("ID");

                    b.ToTable("Regiments");
                });

            modelBuilder.Entity("WarOfRightsWeb.Data.Weapon", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("ParametersDescription")
                        .HasColumnType("varchar(512) CHARACTER SET utf8mb4")
                        .HasMaxLength(512);

                    b.HasKey("ID");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("WarOfRightsWeb.Data.MapRegiment", b =>
                {
                    b.HasOne("WarOfRightsWeb.Data.Map", "Map")
                        .WithMany("MapRegiments")
                        .HasForeignKey("MapID");

                    b.HasOne("WarOfRightsWeb.Data.Regiment", "Regiment")
                        .WithMany("MapRegiments")
                        .HasForeignKey("RegimentID");
                });

            modelBuilder.Entity("WarOfRightsWeb.Data.MapRegimentWeapon", b =>
                {
                    b.HasOne("WarOfRightsWeb.Data.MapRegiment", "MapRegiment")
                        .WithMany("MapRegimentWeapons")
                        .HasForeignKey("MapRegimentID");

                    b.HasOne("WarOfRightsWeb.Data.Weapon", "Weapon")
                        .WithMany("MapRegimentWeapons")
                        .HasForeignKey("WeaponID");
                });
#pragma warning restore 612, 618
        }
    }
}
