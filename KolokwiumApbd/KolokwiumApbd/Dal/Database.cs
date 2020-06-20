using Microsoft.EntityFrameworkCore;

namespace KolokwiumApbd.Models
{
    public class Database : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistEvent> ArtistEvents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        
        public Database()
        { }

        public Database(DbContextOptions<Database> options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtistEvent>().HasKey(sc => new { sc.ArtistId, sc.EventId });
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}