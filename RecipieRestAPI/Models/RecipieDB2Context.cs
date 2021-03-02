using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RecipieRestAPI.Models
{
    public partial class RecipieDB2Context : DbContext
    {
        public RecipieDB2Context()
        {
        }

        public RecipieDB2Context(DbContextOptions<RecipieDB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Connect> Connect { get; set; }
        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<Ingridients> Ingridients { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-EG688GDO\\SQLEXPRESS;Database=RecipieDB2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Connect>(entity =>
            {
                entity.ToTable("connect");
            });

            modelBuilder.Entity<Dishes>(entity =>
            {
                entity.ToTable("dishes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Directions1).IsUnicode(false);

                entity.Property(e => e.Directions2).IsUnicode(false);

                entity.Property(e => e.Directions3).IsUnicode(false);

                entity.Property(e => e.Directions4).IsUnicode(false);

                entity.Property(e => e.IngridientsList).IsUnicode(false);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PictUrl)
                    .HasColumnName("PictURL")
                    .IsUnicode(false);

                entity.Property(e => e.Video)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingridients>(entity =>
            {
                entity.ToTable("ingridients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.ToTable("logs");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
