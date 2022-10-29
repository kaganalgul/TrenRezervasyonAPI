using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrenRezervasyon.ApplicationCore.Entities.Concrete;

namespace TrenRezervasyon.Infrastructure.Data
{
    public class TrenRezervasyonAPIDbContext : DbContext
    {
        public TrenRezervasyonAPIDbContext(DbContextOptions<TrenRezervasyonAPIDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        
        public DbSet<Tren> Trenler { get; set; }
        public DbSet<Vagon> Vagonlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tren>()
               .HasData(
                    new Tren() { Id = 1, Ad = "Başkent Ekspres" }
                );
            modelBuilder.Entity<Vagon>()
               .HasData(
                    new Vagon() { Id = 1, Ad = "Vagon 1", TrenId = 1, Kapasite = 100, DoluKoltukAdet = 68 },
                    new Vagon() { Id = 2, Ad = "Vagon 2", TrenId = 1, Kapasite = 90, DoluKoltukAdet = 50 },
                    new Vagon() { Id = 3, Ad = "Vagon 3", TrenId = 1, Kapasite = 80, DoluKoltukAdet = 80 }
                );
        }

        
    }
}
