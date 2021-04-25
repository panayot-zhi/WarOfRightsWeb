using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarOfRightsWeb.Common;

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

            SetUpMapTable(modelBuilder.Entity<Map>());
            SetUpWeaponTable(modelBuilder.Entity<Weapon>());
            SetUpRegimentTable(modelBuilder.Entity<Regiment>());
            SetUpMapRegimentTable(modelBuilder.Entity<MapRegiment>());
            SetUpMapRegimentWeaponTable(modelBuilder.Entity<MapRegimentWeapon>());
        }

        private static void SetUpRegimentTable(EntityTypeBuilder<Regiment> tableBuilder)
        {
            tableBuilder.Property(x => x.Type)
                .HasConversion(new EnumToStringConverter<RegimentType>());
        }

        private static void SetUpWeaponTable(EntityTypeBuilder<Weapon> tableBuilder)
        {

        }

        private static void SetUpMapTable(EntityTypeBuilder<Map> tableBuilder)
        {

        }

        private static void SetUpMapRegimentTable(EntityTypeBuilder<MapRegiment> tableBuilder)
        {
            tableBuilder
                .HasIndex(x => new { x.MapID, x.RegimentID }).IsUnique();

            tableBuilder
                .HasOne(x => x.Map)
                .WithMany(x => x.MapRegiments)
                .HasForeignKey(x => x.MapID);

            tableBuilder
                .HasOne(x => x.Regiment)
                .WithMany(x => x.MapRegiments)
                .HasForeignKey(x => x.RegimentID);
        }

        private static void SetUpMapRegimentWeaponTable(EntityTypeBuilder<MapRegimentWeapon> tableBuilder)
        {
            tableBuilder
                .HasIndex(x => new { x.MapRegimentID, x.WeaponID }).IsUnique();

            tableBuilder
                .HasOne(x => x.MapRegiment)
                .WithMany(x => x.MapRegimentWeapons)
                .HasForeignKey(x => x.MapRegimentID);

            tableBuilder
                .HasOne(x => x.Weapon)
                .WithMany(x => x.MapRegimentWeapons)
                .HasForeignKey(x => x.WeaponID);
        }
    }
}
