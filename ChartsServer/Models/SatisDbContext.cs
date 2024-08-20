using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChartsServer.Models;

public partial class SatisDbContext : DbContext
{
    public SatisDbContext()
    {
    }

    public SatisDbContext(DbContextOptions<SatisDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Personeller> Personellers { get; set; }

    public virtual DbSet<Satislar> Satislars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=SatisDB;User Id=sa;Password=YourStrongPassword123;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personeller>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Personeller");

            entity.Property(e => e.Adi).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Soyadi).HasMaxLength(100);
        });

        modelBuilder.Entity<Satislar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Satislar");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
