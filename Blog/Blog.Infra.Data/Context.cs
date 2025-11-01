using Blog.Infra.Data.Entity;
using Blog.Infra.Data.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Data
{
    public class Context : DbContext
    {
        public DbSet<BlogPostEntity> BlogPosts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("BlogDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             
            modelBuilder.Entity<BlogPostEntity>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Id).ValueGeneratedOnAdd();
                entity.Property(b => b.Title)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(b => b.Content)
                    .IsRequired()
                    .HasMaxLength(5000);
                 
                entity.HasMany(b => b.Comments)
                    .WithOne(c => c.BlogPost)
                    .HasForeignKey(c => c.BlogPostId)
                    .OnDelete(DeleteBehavior.Cascade);
            }); 

            modelBuilder.Entity<CommentEntity>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Content)
                    .IsRequired()
                    .HasMaxLength(1000);
                entity.Property(c => c.BlogPostId).IsRequired();
            });

            // Aplicar seed de dados
            modelBuilder.SeedData();
        }
    }
}
