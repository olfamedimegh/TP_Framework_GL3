﻿using Microsoft.EntityFrameworkCore;

namespace TP_2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Movie>? movies { get; set; }
        public DbSet<Genre>? genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de la relation
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);
        }
    }
}
