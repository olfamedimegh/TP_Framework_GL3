using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TP2_DbFirst.Models;

public partial class Tp2FrameworkContext : DbContext
{
    public Tp2FrameworkContext()
    {
    }

    public Tp2FrameworkContext(DbContextOptions<Tp2FrameworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-AJJTCAU6;Initial Catalog=TP2_Framework;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genres");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("movies");

            entity.HasIndex(e => e.GenreId, "IX_movies_GenreId");

            entity.HasIndex(e => e.Name, "IX_movies_Name");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Genre).WithMany(p => p.Movies).HasForeignKey(d => d.GenreId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
