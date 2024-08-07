﻿using Microsoft.EntityFrameworkCore;
using WebGraph.Models;

namespace WebGraph.Data
{
    public class AppContex : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        //private readonly string _dbConnectionString;

        public AppContex(DbContextOptions<AppContex> dbContext) : base(dbContext) { }

       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_dbConnectionString).UseLazyLoadingProxies().LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductGroup>(entity =>
            {

                entity.HasKey(pg => pg.Id)
                      .HasName("product_group_pk");

                entity.Property(pg => pg.Name)
                      .HasColumnName("name")
                      .HasMaxLength(255);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id)
                      .HasName("product_pk");

                entity.Property(p => p.Name)
                      .HasColumnName("name")
                      .HasMaxLength(255);

                entity.HasOne(p => p.ProductGroup).WithMany(p => p.Products).HasForeignKey(p => p.ProductGroupId);
            });
            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasKey(s => s.Id)
                      .HasName("storage_pk");

                entity.HasOne(s => s.Product).WithMany(p => p.Storages).HasForeignKey(p => p.ProductId);
            });

        }
    }
}
