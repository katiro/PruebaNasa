using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NasaApolo.Models.Entities;

namespace NasaApolo.Data;

public partial class NasaTestContext : DbContext
{
    public NasaTestContext()
    {
    }

    public NasaTestContext(DbContextOptions<NasaTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NasaImage> NasaImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NasaImage>(entity =>
        {
            entity.HasKey(e => e.IdNasaImage).HasName("nasa_image_pkey");

            entity.ToTable("nasa_image");

            entity.Property(e => e.IdNasaImage).HasColumnName("id_nasa_image");
            entity.Property(e => e.Center)
                .HasMaxLength(50)
                .HasColumnName("center");
            entity.Property(e => e.Createdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdate");
            entity.Property(e => e.Href)
                .HasMaxLength(500)
                .HasColumnName("href");
            entity.Property(e => e.NasaId)
                .HasMaxLength(500)
                .HasColumnName("nasa_id");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
