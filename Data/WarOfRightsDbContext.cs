using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WarOfRightsWeb.Data
{
    public class WarOfRightsDbContext : DbContext
    {
        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Regiment> Regiments { get; set; }

        public DbSet<Map> Maps { get; set; }

        public WarOfRightsDbContext(DbContextOptions<WarOfRightsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MapRegiment>()
                .HasKey(x => new { x.ID });

            modelBuilder.Entity<MapRegiment>()
                .HasIndex(x => new { x.MapID, x.RegimentID }).IsUnique();

            modelBuilder.Entity<MapRegiment>()
                .HasOne(x => x.Map)
                .WithMany(x => x.MapRegiments)
                .HasForeignKey(x => x.MapID);

            modelBuilder.Entity<MapRegiment>()
                .HasOne(x => x.Regiment)
                .WithMany(x => x.MapRegiments)
                .HasForeignKey(x => x.RegimentID);


            modelBuilder.Entity<MapRegimentWeapon>()
                .HasKey(x => new { x.ID });

            modelBuilder.Entity<MapRegimentWeapon>()
                .HasIndex(x => new { x.MapRegimentID, x.WeaponID }).IsUnique();

            modelBuilder.Entity<MapRegimentWeapon>()
                .HasOne(x => x.MapRegiment)
                .WithMany(x => x.MapRegimentWeapons)
                .HasForeignKey(x => x.MapRegimentID);

            modelBuilder.Entity<MapRegimentWeapon>()
                .HasOne(x => x.Weapon)
                .WithMany(x => x.MapRegimentWeapons)
                .HasForeignKey(x => x.WeaponID);
        }
    }
}
