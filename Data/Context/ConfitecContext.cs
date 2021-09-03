using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Business.Models;

namespace Data.Context
{
    public class ConfitecContext : DbContext
    {
      private IConfiguration _config;

      public ConfitecContext(DbContextOptions<ConfitecContext> options, IConfiguration config) : base(options)
      {
          _config = config;
      }

      public DbSet<Usuario> Usuario { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
        modelBuilder.Entity<Usuario>().ToTable("Usuario");
      }
    }
}