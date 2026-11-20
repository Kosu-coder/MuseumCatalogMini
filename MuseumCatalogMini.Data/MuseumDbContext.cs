using Microsoft.EntityFrameworkCore;
using MuseumCatalogMini.Data.Entities;
using MuseumCatalogMini.Data.Enums;

namespace MuseumCatalogMini.Data;

public class MuseumDbContext : DbContext
{
    public MuseumDbContext(DbContextOptions<MuseumDbContext> options)
        : base(options)
    {
    }

    public DbSet<Museum> Museums => Set<Museum>();
    public DbSet<Exhibit> Exhibits => Set<Exhibit>();
    public DbSet<Curator> Curators => Set<Curator>();
    public DbSet<Exhibition> Exhibitions => Set<Exhibition>();
    public DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Museum>(entity =>
        {
            entity.HasKey(m => m.MuseumId);
            entity.Property(m => m.Name).IsRequired().HasMaxLength(150);
            entity.Property(m => m.Region).IsRequired().HasMaxLength(100);
            entity.Property(m => m.Type).IsRequired().HasMaxLength(80);
            entity.Property(m => m.EntryTax).HasPrecision(10, 2);
            entity.Property(m => m.Description).HasMaxLength(1000);
        });

        modelBuilder.Entity<Exhibit>(entity =>
        {
            entity.HasKey(e => e.ExhibitId);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Period).HasMaxLength(80);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Category).HasConversion<int>().HasDefaultValue(ExhibitCategory.Other);

            entity.HasOne(e => e.Museum)
                .WithMany(m => m.Exhibits)
                .HasForeignKey(e => e.MuseumId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Exhibition)
                .WithMany(ex => ex.Exhibits)
                .HasForeignKey(e => e.ExhibitionId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.Department)
                .WithMany(d => d.Exhibits)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Curator>(entity =>
        {
            entity.HasKey(c => c.CuratorId);
            entity.Property(c => c.FullName).IsRequired().HasMaxLength(120);
            entity.Property(c => c.Position).HasMaxLength(100);
            entity.Property(c => c.Email).HasMaxLength(150);
            entity.HasOne(c => c.Museum).WithMany(m => m.Curators)
                .HasForeignKey(c => c.MuseumId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Exhibition>(entity =>
        {
            entity.HasKey(e => e.ExhibitionId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.HasOne(e => e.Museum).WithMany(m => m.Exhibitions)
                .HasForeignKey(e => e.MuseumId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(d => d.DepartmentId);
            entity.Property(d => d.Name).IsRequired().HasMaxLength(100);
            entity.Property(d => d.Description).HasMaxLength(500);
            entity.HasOne(d => d.Museum).WithMany(m => m.Departments)
                .HasForeignKey(d => d.MuseumId).OnDelete(DeleteBehavior.Cascade);
        });
    }
}
