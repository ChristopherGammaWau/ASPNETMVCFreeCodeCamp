using System;
using System.Collections.Generic;
using DBFirstProj.Models;
using Microsoft.EntityFrameworkCore;

namespace DBFirstProj.Data;

public partial class ProjEmbarkxShortnerContext : DbContext
{
    public ProjEmbarkxShortnerContext()
    {
    }

    public ProjEmbarkxShortnerContext(DbContextOptions<ProjEmbarkxShortnerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClickEvent> ClickEvents { get; set; }

    public virtual DbSet<UrlMapping> UrlMappings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Username=postgres;Password=root;Host=localhost;Port=5432;Database=proj_embarkx_shortner;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClickEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("click_event_pkey");

            entity.HasOne(d => d.UrlMapping).WithMany(p => p.ClickEvents).HasConstraintName("fk569i4rsslbjh08ffdc4iumly2");
        });

        modelBuilder.Entity<UrlMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("url_mapping_pkey");

            entity.HasOne(d => d.User).WithMany(p => p.UrlMappings).HasConstraintName("fkpd4vqdk4o6lis35i2b1vo96v0");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
