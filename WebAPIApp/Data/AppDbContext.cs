using Microsoft.EntityFrameworkCore;
using WebAPIApp.Models;

namespace WebAPIApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SettingItem> SettingItems { get; set; }
        public DbSet<DataVariant> DataVariants { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 関連付け設定（Cascade Deleteを有効化）
            modelBuilder.Entity<Maintenance>()
                .HasMany(m => m.Settings)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Setting>()
                .HasMany(s => s.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SettingItem>()
                .HasMany(i => i.DataVariants)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
