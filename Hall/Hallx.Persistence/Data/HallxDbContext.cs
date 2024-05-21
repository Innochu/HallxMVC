using Hallx.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hallx.Persistence.Data
{
    public class HallxDbContext : DbContext
    {
        public HallxDbContext(DbContextOptions<HallxDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Toys", DisplayOrder=6},
                new Category { Id=2, Name="Soap", DisplayOrder=7},
                new Category { Id=3, Name="Hamper", DisplayOrder=9});

            modelBuilder.Entity<Product>().HasData(
    new Product
    {
        Id = 1,
        Title = "The Lean Startup",
        Description = "How Today's Entrepreneurs Use Continuous Innovation to Create Radically Successful Businesses",
        Author = "Eric Ries",
        ISBN = "978-0307887894",
        Price = 14.99,
        ListPrice = 19.99,
        Price50 = 12.99,
        Price100 = 10.99
    },
    new Product
    {
        Id = 2,
        Title = "Atomic Habits",
        Description = "An Easy & Proven Way to Build Good Habits & Break Bad Ones",
        Author = "James Clear",
        ISBN = "978-0735211292",
        Price = 12.99,
        ListPrice = 17.99,
        Price50 = 11.99,
        Price100 = 9.99
    },
    new Product
    {
        Id = 3,
        Title = "The Midnight Library",
        Description = "A Novel",
        Author = "Matt Haig",
        ISBN = "978-0525559474",
        Price = 16.99,
        ListPrice = 21.99,
        Price50 = 14.99,
        Price100 = 12.99
    },
    new Product
    {
        Id = 4,
        Title = "The Art of Happiness",
        Description = "A Handbook for Living",
        Author = "Dalai Lama XIV, Howard C. Cutler",
        ISBN = "978-1573221801",
        Price = 11.99,
        ListPrice = 15.99,
        Price50 = 10.99,
        Price100 = 8.99
    },
    new Product
    {
        Id = 5,
        Title = "The Alchemist",
        Description = "A Fable About Following Your Dream",
        Author = "Paulo Coelho",
        ISBN = "978-0061122416",
        Price = 9.99,
        ListPrice = 13.99,
        Price50 = 8.99,
        Price100 = 7.99
    },
    new Product
    {
        Id = 6,
        Title = "The Hunger Games",
        Description = "Book 1 of the Hunger Games Trilogy",
        Author = "Suzanne Collins",
        ISBN = "978-0439023481",
        Price = 8.99,
        ListPrice = 12.99,
        Price50 = 7.99,
        Price100 = 6.99
    },
    new Product
    {
        Id = 7,
        Title = "The Subtle Art of Not Giving a F*ck",
        Description = "A Counterintuitive Approach to Living a Good Life",
        Author = "Mark Manson",
        ISBN = "978-0062457714",
        Price = 14.99,
        ListPrice = 18.99,
        Price50 = 13.99,
        Price100 = 11.99
    },
    new Product
    {
        Id = 8,
        Title = "The Power of Habit",
        Description = "Why We Do What We Do in Life and Business",
        Author = "Charles Duhigg",
        ISBN = "978-0812981605",
        Price = 13.99,
        ListPrice = 17.99,
        Price50 = 12.99,
        Price100 = 10.99
    },
    new Product
    {
        Id = 9,
        Title = "The Martian",
        Description = "A Novel",
        Author = "Andy Weir",
        ISBN = "978-0553418026",
        Price = 11.99,
        ListPrice = 15.99,
        Price50 = 10.99,
        Price100 = 9.99
    },
    new Product
    {
        Id = 10,
        Title = "The 7 Habits of Highly Effective People",
        Description = "Powerful Lessons in Personal Change",
        Author = "Stephen R. Covey",
        ISBN = "978-0671708634",
        Price = 17.99,
        ListPrice = 22.99,
        Price50 = 15.99,
        Price100 = 13.99
    }
);
        }
    }
}
