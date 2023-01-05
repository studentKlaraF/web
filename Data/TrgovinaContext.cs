using SeminarskaNaloga.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SeminarskaNaloga.Data
{   
    public class TrgovinaContext : IdentityDbContext<AppUser>
    {
        public TrgovinaContext(DbContextOptions<TrgovinaContext> options) : base(options)
        {
        }

        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Narocilo> Narocilo { get; set; }
        public DbSet<Lastnik> Lastnik { get; set; }
        public DbSet<Trgovina> Trgovina { get; set; }
        public DbSet<vrstaArtikla> vrstaArtikla { get; set; }
        public DbSet<Ocena> Ocena { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Artikel>().ToTable("Artikel");
            modelBuilder.Entity<Narocilo>().ToTable("Narocilo");
            modelBuilder.Entity<Lastnik>().ToTable("Lastnik");
            modelBuilder.Entity<Trgovina>().ToTable("Trgovina");
            modelBuilder.Entity<Ocena>().ToTable("Ocena");
            modelBuilder.Entity<vrstaArtikla>().ToTable("vrstaArtikla");
        }
    }
}