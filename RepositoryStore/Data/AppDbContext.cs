using Microsoft.EntityFrameworkCore;
using RepositoryStore.Models;

namespace RepositoryStore.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<Product> Products { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
			=> modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
	}
}
