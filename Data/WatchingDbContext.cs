using Microsoft.EntityFrameworkCore;
using WatchingOrchestrator.Models;

namespace WatchingOrchestrator.Data
{
    public class WatchingDbContext : DbContext{

        public virtual DbSet<Contents> Contents { get; set; }
        public virtual DbSet<Elements> Elements { get; set; }
        public virtual DbSet<States> States { get; set; }
        public WatchingDbContext(DbContextOptions<WatchingDbContext> opt): base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
           modelBuilder
            .Entity<States>()
            .HasMany(e => e.ElementsList)
            .WithOne(s => s.Stato)
            .HasForeignKey(e => e.StatesId);

            modelBuilder
            .Entity<Contents>()
            .HasMany(e => e.ElementsList)
            .WithOne(c => c.Categoria)
            .HasForeignKey(e => e.ContentsId);
            */
            modelBuilder
            .Entity<Elements>()
            .HasOne(e => e.Categoria)
            .WithMany(c => c.ElementsList)
            .HasForeignKey(e => e.ContentsId);

            modelBuilder
            .Entity<Elements>()
            .HasOne(e => e.Stato)
            .WithMany(s => s.ElementsList)
            .HasForeignKey(e => e.StatesId);
        }
    }
}