using MaterialMaster.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMaster.Infrastructure.Contexts
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

        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().ToTable("Materials");
            modelBuilder.Entity<MaterialCategory>().ToTable("MaterialCategories");
        }
    }
}
