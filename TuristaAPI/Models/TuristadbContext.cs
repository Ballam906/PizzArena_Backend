using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TuristaAPI.Models;

public partial class TuristadbContext : DbContext
{
    public TuristadbContext()
    {
    }

    public TuristadbContext(DbContextOptions<TuristadbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Nehezseg> Nehezsegs { get; set; }

    public virtual DbSet<Tura> Turas { get; set; }

    public virtual DbSet<Turavezeto> Turavezetos { get; set; }

    public virtual DbSet<Utvonal> Utvonals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=turistadb;USER=root;PASSWORD=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nehezseg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("nehezseg");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Jelzes)
                .HasMaxLength(1)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("jelzes");
            entity.Property(e => e.Leiras)
                .HasMaxLength(128)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("leiras");
        });

        modelBuilder.Entity<Tura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tura");

            entity.HasIndex(e => e.TuravezetoId, "turavezetoID");

            entity.HasIndex(e => e.UtvonalId, "utvonalID");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Idopont)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("idopont");
            entity.Property(e => e.Koltseg)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("koltseg");
            entity.Property(e => e.Maxletszam)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("maxletszam");
            entity.Property(e => e.TuravezetoId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("turavezetoID");
            entity.Property(e => e.UtvonalId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("utvonalID");

            entity.HasOne(d => d.Turavezeto).WithMany(p => p.Turas)
                .HasForeignKey(d => d.TuravezetoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("tura_ibfk_2");

            entity.HasOne(d => d.Utvonal).WithMany(p => p.Turas)
                .HasForeignKey(d => d.UtvonalId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("tura_ibfk_1");
        });

        modelBuilder.Entity<Turavezeto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("turavezeto");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Email)
                .HasMaxLength(32)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("email");
            entity.Property(e => e.Minosites)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(8)")
                .HasColumnName("minosites");
            entity.Property(e => e.Nev)
                .HasMaxLength(64)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Telefon)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Utvonal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("utvonal");

            entity.HasIndex(e => e.NehezsegId, "nehezsegID");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Allomasok)
                .HasMaxLength(256)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("allomasok");
            entity.Property(e => e.NehezsegId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("nehezsegID");
            entity.Property(e => e.Szint)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("szint");
            entity.Property(e => e.Tav)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("tav");

            entity.HasOne(d => d.Nehezseg).WithMany(p => p.Utvonals)
                .HasForeignKey(d => d.NehezsegId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("utvonal_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
