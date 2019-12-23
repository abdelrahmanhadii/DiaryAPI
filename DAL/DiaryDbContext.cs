using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL
{
    public class DiaryDbContext : DbContext
    {
        public DiaryDbContext(DbContextOptions<DiaryDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diary>(entity =>
            {
                entity.HasKey(s => new { s.Id });
                entity.Property(a => a.Title).IsRequired().HasMaxLength(20);
                entity.Property(a => a.Description).HasMaxLength(200);
                entity.Property(a => a.EnteredBy).IsRequired();
                entity.Property(a => a.EnteredDate).IsRequired();
                entity.Property(a => a.UserId).IsRequired();
            });
        }
        public DbSet<Diary> Diaries { get; set; }
    }
}
