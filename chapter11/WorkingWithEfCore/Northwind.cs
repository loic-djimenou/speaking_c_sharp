using Microsoft.EntityFrameworkCore;

namespace Packt.Shared

{

    // this manages the connection to the database

    public class Northwind : DbContext

    {

        // these properties map to tables in the database

        public DbSet<Category>? Categories { get; set; }

        public DbSet<Product>? Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename={path}");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            // example of using Fluent API instead of attributes

            // to limit the length of a category name to 15

            modelBuilder.Entity<Category>()

            .Property(category => category.CategoryName)

            .IsRequired() // NOT NULL

            .HasMaxLength(15);

            // GetHashCodelobal filters on products in the whole applications
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.Discontinued);

        }

    }

}