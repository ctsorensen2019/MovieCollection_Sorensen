using Microsoft.EntityFrameworkCore;

namespace MovieCollection.Models
{
    public class MovieFormContext : DbContext
    {

        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options) 
        { 
            
        }

        public DbSet<Application> Movies { get; set; }


        // This table corresponds to 'Categories'
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Seed Data
        {
            modelBuilder.Entity<Category>().HasData();
        }
    }
}
