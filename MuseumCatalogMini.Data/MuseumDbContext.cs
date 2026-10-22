using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using MuseumCatalogMini.Data.Entities;

namespace MuseumCatalogMini.Data
{
    public class MuseumDbContext : DbContext
    {
        public MuseumDbContext(DbContextOptions<MuseumDbContext> options) : base(options)
        {
        }

        public DbSet<Museum> Museums => Set<Museum>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Museum>(entity =>
            {
                entity.HasKey(e => e.Name);
                entity.Property(e => e.Region);
                entity.Property(e => e.Type);
                entity.Property(e => e.EntryTax);
                entity.Property(e => e.Description);
            });
        }
    }
}
