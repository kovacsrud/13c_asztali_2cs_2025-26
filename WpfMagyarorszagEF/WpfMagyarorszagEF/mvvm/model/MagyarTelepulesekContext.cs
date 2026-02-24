using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WpfMagyarorszagEF.mvvm.model;

public partial class MagyarTelepulesekContext : DbContext
{
    public MagyarTelepulesekContext()
    {
    }

    public MagyarTelepulesekContext(DbContextOptions<MagyarTelepulesekContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Jogalla> Jogallas { get; set; }

    public virtual DbSet<Megyek> Megyeks { get; set; }

    public virtual DbSet<Telepulesek> Telepuleseks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=magyar_telepulesek", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Jogalla>(entity =>
        {
            entity.HasKey(e => e.Suly).HasName("PRIMARY");

            entity.ToTable("jogallas");

            entity.Property(e => e.Suly)
                .HasColumnType("int(11)")
                .HasColumnName("suly");
            entity.Property(e => e.Jogallas)
                .HasMaxLength(255)
                .HasColumnName("jogallas");
        });

        modelBuilder.Entity<Megyek>(entity =>
        {
            entity.HasKey(e => e.Kod).HasName("PRIMARY");

            entity.ToTable("megyek");

            entity.Property(e => e.Kod).HasColumnName("kod");
            entity.Property(e => e.Nev)
                .HasMaxLength(255)
                .HasColumnName("nev");
        });

        modelBuilder.Entity<Telepulesek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("telepulesek");

            entity.HasIndex(e => e.Jogallas, "FK_telepulesek_jogallas");

            entity.HasIndex(e => e.Megyekod, "FK_telepulesek_megyekod");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Irszam)
                .HasColumnType("int(11)")
                .HasColumnName("irszam");
            entity.Property(e => e.Jogallas)
                .HasColumnType("int(11)")
                .HasColumnName("jogallas");
            entity.Property(e => e.Kshkod)
                .HasMaxLength(255)
                .HasColumnName("kshkod");
            entity.Property(e => e.Lakasok)
                .HasColumnType("int(11)")
                .HasColumnName("lakasok");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Long).HasColumnName("long");
            entity.Property(e => e.Megyekod).HasColumnName("megyekod");
            entity.Property(e => e.Nepesseg)
                .HasColumnType("int(11)")
                .HasColumnName("nepesseg");
            entity.Property(e => e.Nev)
                .HasMaxLength(255)
                .HasColumnName("nev");
            entity.Property(e => e.Terulet)
                .HasColumnType("int(11)")
                .HasColumnName("terulet");

            entity.HasOne(d => d.JogallasNavigation).WithMany(p => p.Telepuleseks)
                .HasForeignKey(d => d.Jogallas)
                .HasConstraintName("FK_telepulesek_jogallas");

            entity.HasOne(d => d.MegyekodNavigation).WithMany(p => p.Telepuleseks)
                .HasForeignKey(d => d.Megyekod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_telepulesek_megyekod");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
