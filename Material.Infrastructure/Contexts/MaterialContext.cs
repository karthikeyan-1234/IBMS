using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material.Infrastructure.Contexts
{
    public class MaterialContext: DbContext
    {
        IConfiguration configuration;

        public MaterialContext(DbContextOptions<MaterialContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConn"));

        public DbSet<Material.Domain.Models.Material> Materials { get; set; }
        public DbSet<Material.Domain.Models.MaterialCategory> MaterialCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material.Domain.Models.Material>().ToTable("Materials");
            modelBuilder.Entity<Material.Domain.Models.MaterialCategory>().ToTable("MaterialCategories");
        }
    }
}
