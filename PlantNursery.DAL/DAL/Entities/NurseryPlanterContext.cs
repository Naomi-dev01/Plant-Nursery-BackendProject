using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PlantNursery.DAL.DAL.Entities;

public partial class NurseryPlanterContext : DbContext
{
    public NurseryPlanterContext()
    {
    }

    public NurseryPlanterContext(DbContextOptions<NurseryPlanterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MAKEIT\\SQLEXPRESS02;Database=NurseryPlanter;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Color).HasMaxLength(100);
            entity.Property(e => e.Height).HasMaxLength(50);
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .HasColumnName("image");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
