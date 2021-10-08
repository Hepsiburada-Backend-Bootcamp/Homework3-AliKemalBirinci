using CampaignApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CampaignApi.Models.Context
{
    public class CampaignDbContext : DbContext
    {
        public CampaignDbContext(DbContextOptions<CampaignDbContext> options) : base(options)
        {

        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductGroup>().HasData(
                  new ProductGroup() { Id = 1, Name = "Monitors" },
                  new ProductGroup() { Id = 2, Name = "Others" });

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Apple iPad", Price = 1000, ProductGroupId = 1 },
                new Product() { Id = 2, Name = "Samsung Smart TV", Price = 1500, ProductGroupId = 1 },
                new Product() { Id = 3, Name = "Nokia 130", Price = 1200, ProductGroupId = 1 },
                new Product() { Id = 4, Name = "Dell Monitor", Price = 800, ProductGroupId = 2 },
                new Product() { Id = 5, Name = "Samsung Monitor", Price = 1000, ProductGroupId = 2 });

            modelBuilder.Entity<Campaign>().HasData(
                  new Campaign() { Id = 1, Name = "Monitor Kampanya", Description = "Ikinci ürün yüzde elli indirimli.", IsActive = true, EndDate = new DateTime(2022, 1, 12), StartDate = new DateTime(2021, 1, 12) },
                  new Campaign() { Id = 2, Name = "Others Kampanya", Description = "Ikinci ürün yüzde yirmi indirimli.", IsActive = true, EndDate = new DateTime(2022, 9, 14), StartDate = new DateTime(2021, 9, 14) });

            modelBuilder.Entity<Store>().HasData(
                  new Store() { Id = 1, City = "Ankara", Name = "AnkaMall" },
                  new Store() { Id = 2, City = "Istanbul", Name = "Akasya" },
                  new Store() { Id = 3, City = "Istanbul", Name = "Mall Of Ist" });

        }
    }
}
