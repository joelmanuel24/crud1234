using Microsoft.EntityFrameworkCore;
using Movie.Application.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Entities.Movie> Movies { get; set; }
        public DbSet<Entities.Category> Categories { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Action"
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Horror"
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Drama"
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Comedy"
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Fantasy"
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
