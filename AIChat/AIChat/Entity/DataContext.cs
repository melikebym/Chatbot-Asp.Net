using AIChat.Models;
using Microsoft.EntityFrameworkCore;

namespace AIChat.Entity
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Option> Options { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Option>()
                .HasMany(o => o.Children)
                .WithOne(o => o.Parent)
                .HasForeignKey(o => o.ParentID);
        }
    }
}
