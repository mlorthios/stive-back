using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;
using stive_back.Models;

namespace stive_back.Helpers
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        
        public DbSet<Product>? Product { get; set; }
        public DbSet<Category>? Category { get; set; }
        public DbSet<ProductImage>? ProductImages { get; set; }
        public DbSet<Stock>? Stock { get; set; }
        
        public class MysqlEntityFrameworkDesignTimeServices : IDesignTimeServices
        {
            public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
            {
                serviceCollection.AddEntityFrameworkMySQL();
                new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
                    .TryAddCoreServices();
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>()
                .HasOne(p => p.Product)
                .WithMany(b => b.ProductImages)
                .HasForeignKey(p => p.ProductId);
        }
        
        public override int SaveChanges()
        {
            AddTimestampsProduct();
            AddTimestampsProductImage();
            AddTimestampsCategory();
            AddTimestampsStock();
            return base.SaveChanges();
        }
        
        private void AddTimestampsProduct()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is Product && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((Product)entity.Entity).CreatedAt = now;
                }
                ((Product)entity.Entity).UpdatedAt = now;
            }
        }
        
        private void AddTimestampsProductImage()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is ProductImage && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((ProductImage)entity.Entity).CreatedAt = now;
                }
                ((ProductImage)entity.Entity).UpdatedAt = now;
            }
        }
        
        private void AddTimestampsCategory()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is Category && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((Category)entity.Entity).CreatedAt = now;
                }
                ((Category)entity.Entity).UpdatedAt = now;
            }
        }
        
        private void AddTimestampsStock()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is Stock && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((Stock)entity.Entity).CreatedAt = now;
                }
                ((Stock)entity.Entity).UpdatedAt = now;
            }
        }

    }
}

