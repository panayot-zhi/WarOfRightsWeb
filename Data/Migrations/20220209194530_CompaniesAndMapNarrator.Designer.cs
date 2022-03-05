﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarOfRightsWeb.Data;

namespace WarOfRightsWeb.Migrations
{
    [DbContext(typeof(WarOfRightsDbContext))]
    [Migration("20220209194530_CompaniesAndMapNarrator")]
    partial class CompaniesAndMapNarrator
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
                        .HasColumnName("id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("AreaName")
                        .HasColumnName("area_name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<decimal?>("CaptureSpeed")
                        .HasColumnName("capture_speed")
                        .HasColumnType("DECIMAL(6,4)");

                    b.Property<string>("DateTimeDescription")
                        .HasColumnName("date_time_description")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("DefendingTeam")
                        .HasColumnName("defending_team")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FinalPushTime")
                        .HasColumnName("final_push_time")
                        .HasColumnType("int");

                    b.Property<string>("LoadingImagePath")
                        .HasColumnName("loading_image_path")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("NarratorInfo")
                        .HasColumnName("narrator_info")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("NeutralizeSpeed")
                        .HasColumnName("neutralize_speed")
                        .HasColumnType("DECIMAL(6,4)");

                    b.Property<int>("Order")
                        .HasColumnName("order")
                        .HasColumnType("int");

                    b.Property<int?>("RoundTime")
                        .HasColumnName("round_time")
                        .HasColumnType("int");

                    b.Property<string>("SkirmishImagePath")
                        .HasColumnName("skirmish_image_path")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("SpawnImagePath")
                        .HasColumnName("spawn_image_path")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int?>("TicketsCSA")
                        .HasColumnName("tickets_csa")
                        .HasColumnType("int");

                    b.Property<int?>("TicketsUSA")
                        .HasColumnName("tickets_usa")
                        .HasColumnType("int");

                    b.Property<decimal?>("TransferOnDeath")
                        .HasColumnName("transfer_on_death")
                        .HasColumnType("DECIMAL(6,4)");

                    b.Property<int?>("WaveTime")
                        .HasColumnName("wave_time")
                        .HasColumnType("int");

                    b.HasKey("ID")
                        .HasName("pk_maps");

                    b.ToTable("maps");
                });

            modelBuilder.Entity("WarOfRightsWeb.Data.MapRegiment", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnName("id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("MapID")
                        .HasColumnName("map_id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("Order")
                        .HasColumnName("order")
                        .HasColumnType("int");

                    b.Property<string>("RegimentID")
                        .HasColumnName("regiment_id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("ID")
                        .HasName("pk_map_regiment");

                    b.HasIndex("RegimentID")
                        .HasName("ix_map_regiment_regiment_id");

                    b.HasIndex("MapID", "RegimentID")
                        .IsUnique()
                        .HasName("ix_map_regiment_map_id_regiment_id");

                    b.ToTable("map_regiment");
                });

            modelBuilder.Entity("WarOfRightsWeb.Data.MapRegimentWeapon", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnName("id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int?>("Count")
                        .HasColumnName("count")
                        .HasColumnType("int");

                    b.Property<string>("MapRegimentID")
                        .HasColumnName("map_regiment_id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int?>("Percent")
                        .HasColumnName("percent")
                        .HasColumnType("int");

                    b.Property<string>("WeaponID")
                        .HasColumnName("weapon_id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("ID")
                        .HasName("pk_map_regiment_weapon");

                    b.HasIndex("WeaponID")
                        .HasName("ix_map_regiment_weapon_weapon_id");

                    b.HasIndex("MapRegimentID", "WeaponID")
                        .IsUnique()
                        .HasName("ix_map_regiment_weapon_map_regiment_id_weapon_id");

                    b.ToTable("map_regiment_weapon");
                });

            modelBuilder.Entity("WarOfRightsWeb.Data.Regiment", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnName("id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Companies")
                        .HasColumnName("companies")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Faction")
                        .HasColumnName("faction")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Number")
                        .HasColumnName("number")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("type")
                        .HasColumnType("varchar(127) CHARACTER SET utf8mb4")
                        .HasMaxLength(127);

                    b.HasKey("ID")
                        .HasName("pk_regiments");

                    b.ToTable("regiments");
                });

            modelBuilder.Entity("WarOfRightsWeb.Data.Weapon", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnName("id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("ParametersDescription")
                        .HasColumnName("parameters_description")
                        .HasColumnType("varchar(512) CHARACTER SET utf8mb4")
                        .HasMaxLength(512);

                    b.HasKey("ID")
                        .HasName("pk_weapons");

                    b.ToTable("weapons");
                });

            modelBuilder.Entity("WarOfRightsWeb.Data.MapRegiment", b =>
                {
                    b.HasOne("WarOfRightsWeb.Data.Map", "Map")
                        .WithMany("MapRegiments")
                        .HasForeignKey("MapID")
                        .HasConstraintName("fk_map_regiment_maps_map_id");

                    b.HasOne("WarOfRightsWeb.Data.Regiment", "Regiment")
                        .WithMany("MapRegiments")
                        .HasForeignKey("RegimentID")
                        .HasConstraintName("fk_map_regiment_regiments_regiment_id");
                });

            modelBuilder.Entity("WarOfRightsWeb.Data.MapRegimentWeapon", b =>
                {
                    b.HasOne("WarOfRightsWeb.Data.MapRegiment", "MapRegiment")
                        .WithMany("MapRegimentWeapons")
                        .HasForeignKey("MapRegimentID")
                        .HasConstraintName("fk_map_regiment_weapon_map_regiment_map_regiment_id");

                    b.HasOne("WarOfRightsWeb.Data.Weapon", "Weapon")
                        .WithMany("MapRegimentWeapons")
                        .HasForeignKey("WeaponID")
                        .HasConstraintName("fk_map_regiment_weapon_weapons_weapon_id");
                });
#pragma warning restore 612, 618
        }
    }
}
