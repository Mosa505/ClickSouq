using BookNest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookNest.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Category> categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<OrderHeader> orderHeaders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Political Fiction", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Human Rights", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Historical", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Autobiography", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Thought", DisplayOrder = 5 }

                );

            modelBuilder.Entity<Product>().HasData(

               new Product
               {
                   Id = 1,
                   Title = "Men in the Sun",
                   Author = "Ghassan Kanafani",
                   Description = "A symbolic Palestinian novel that depicts the suffering of refugees and the harsh realities of displacement through a deeply human and tragic story.",
                   ISBN = "ARB1001001",
                   ListPrice = 100,
                   Price = 90,
                   Price50 = 80,
                   Price100 = 70,
                   CategoryId = 1,
                   ImageURL = ""

               },

               new Product

               {

                   Id = 2,

                   Title = "East of the Mediterranean",

                   Author = "Abdul Rahman Munif",

                   Description = "A powerful novel exposing political oppression and human suffering in the Middle East, written with deep psychological and social insight.",

                   ISBN = "ARB2002002",

                   ListPrice = 95,

                   Price = 85,

                   Price50 = 75,

                   Price100 = 65,
                   CategoryId = 2,
                   ImageURL = ""
               },

               new Product

               {

                   Id = 4,

                   Title = "Al-Majriyat",

                   Author = "Ibrahim al-Sakran",

                   Description = "An analytical and philosophical book exploring how modern distractions affect human consciousness, faith, and culture.",

                   ISBN = "ARB4004004",

                   ListPrice = 85,

                   Price = 80,

                   Price50 = 75,

                   Price100 = 70,
                   CategoryId = 5,
                   ImageURL = ""
               },

               new Product

               {

                   Id = 5,

                   Title = "My Intellectual Journey",

                   Author = "Abdelwahab Elmessiri",

                   Description = "An autobiographical work that traces Elmessiri’s personal and intellectual development, offering reflections on modernity, identity, and faith.",

                   ISBN = "ARB5005005",

                   ListPrice = 120,

                   Price = 110,

                   Price50 = 100,

                   Price100 = 90,
                   CategoryId = 4,
                   ImageURL = ""

               },

               new Product

               {

                   Id = 6,

                   Title = "The Road to Mecca",

                   Author = "Muhammad Asad",

                   Description = "A captivating autobiography of a Western intellectual who embraces Islam, offering deep insights into faith, culture, and personal transformation.",

                   ISBN = "ARB6006006",

                   ListPrice = 105,

                   Price = 95,

                   Price50 = 90,

                   Price100 = 80,
                   CategoryId = 4,
                   ImageURL = ""

               },

               new Product

               {

                   Id = 7,

                   Title = "Granada Trilogy",

                   Author = "Radwa Ashour",

                   Description = "A historical trilogy set in post-Reconquista Spain, telling the story of Muslims after the fall of Granada, filled with emotion, loss, and resistance.",

                   ISBN = "ARB7007007",

                   ListPrice = 130,

                   Price = 120,

                   Price50 = 110,

                   Price100 = 100,
                   CategoryId = 3,
                   ImageURL = ""

               }

                );
        }


    }
}
