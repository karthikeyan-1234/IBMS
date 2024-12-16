using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using SalesProject.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Infrastructure.Contexts
{
    public class SalesContext: DbContext
    {
        IConfiguration configuration;

        public SalesContext(DbContextOptions<SalesContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConn"));

        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().ToTable("Materials");
            modelBuilder.Entity<MaterialCategory>().ToTable("MaterialCategories");
            modelBuilder.Entity<Sale>().ToTable("Sales");
        }
    }
}
