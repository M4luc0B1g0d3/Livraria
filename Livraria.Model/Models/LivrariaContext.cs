﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Model.Models;

public partial class LivrariaContext : DbContext
{
    public LivrariaContext()
    {
    }

    public LivrariaContext(DbContextOptions<LivrariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admin { get; set; }

    public virtual DbSet<Alugado> Alugado { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<ItemAlugado> ItemAlugado { get; set; }

    public virtual DbSet<Livro> Livro { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Localhost\\SQLEXPRESS;Initial Catalog=Livraria;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ADMIN");
        });

        modelBuilder.Entity<Alugado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ALUGADO");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Alugado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Alugado_fk0");

            entity.HasOne(d => d.IdLivroNavigation).WithMany(p => p.Alugado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Alugado_fk1");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CLIENTE");
        });

        modelBuilder.Entity<ItemAlugado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemAlug__3213E83F33C9DFB1");

            entity.HasOne(d => d.Alugado).WithMany(p => p.ItemAlugado).HasConstraintName("FK__ItemAluga__aluga__5EBF139D");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ItemAlugado).HasConstraintName("FK__ItemAluga__idCli__5DCAEF64");

            entity.HasOne(d => d.IdLivroNavigation).WithMany(p => p.ItemAlugado).HasConstraintName("FK__ItemAluga__idLiv__5CD6CB2B");
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LIVRO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}