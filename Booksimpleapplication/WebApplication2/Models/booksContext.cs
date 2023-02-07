using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class booksContext : DbContext
    {
        public booksContext()
        {
        }

        public booksContext(DbContextOptions<booksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasMaxLength(30)
                    .HasColumnName("author")
                    .IsFixedLength();

                entity.Property(e => e.Class)
                    .HasMaxLength(20)
                    .HasColumnName("class")
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .HasMaxLength(30)
                    .HasColumnName("title")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
