using InventoryProject.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Infrastructure.Contexts
{
    public class InventoryContext: DbContext
    {
        IConfiguration configuration;

        public InventoryContext(DbContextOptions<InventoryContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConn"));

        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().ToTable("Materials");
            modelBuilder.Entity<MaterialCategory>().ToTable("MaterialCategories");
            modelBuilder.Entity<Inventory>().ToTable("Inventories");
        }
    }
}
