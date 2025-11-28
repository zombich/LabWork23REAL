using System;
using System.Collections.Generic;
using DatabaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary.Contexts;

public partial class GamesDbContext : DbContext
{
    public GamesDbContext()
    {
    }

    public GamesDbContext(DbContextOptions<GamesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GamesLw23> GamesLw23s { get; set; }

    public virtual DbSet<ScreenshotsLw23> ScreenshotsLw23s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=mssql;Initial Catalog=ispp3104;Persist Security Info=True;User ID=ispp3104;Password=3104;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GamesLw23>(entity =>
        {
            entity.HasKey(e => e.IdGame).HasName("PK__GamesLW2__A304AD9BD2388664");

            entity.ToTable("GamesLW23");

            entity.Property(e => e.IdGame).HasColumnName("idGame");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.LogoFile)
                .HasMaxLength(120)
                .HasColumnName("logoFile");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<ScreenshotsLw23>(entity =>
        {
            entity.HasKey(e => e.ScreenshotId);

            entity.ToTable("ScreenshotsLW23");

            entity.Property(e => e.FileName).HasMaxLength(50);

            entity.HasOne(d => d.Game).WithMany(p => p.ScreenshotsLw23s)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ScreenshotsLW23_GamesLW23");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
