using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<Customer>>();

            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.MembershipTypes.Any())
                    SeedMembershipTypes(context);

                if (!context.Roles.Any())
                    SeedRoles(context);

                if (!context.Customers.Any())
                     SeedCustomers(userManager);

                if (!context.Genre.Any())
                    SeedGenres(context);

                if (!context.Books.Any())
                    SeedBooks(context);

                context.SaveChanges();
            }
        }

        private static void SeedBooks(ApplicationDbContext context)
        {
            context.Books.AddRange(
                new Book
                {
                    GenreId = 1,
                    Name = "Fault in our stars",
                    AuthorName = "John Green",
                    ReleaseDate = DateTime.Parse("10/01/2012"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 2,
                    Name = "The fellowship of the Ring",
                    AuthorName = "J.R.R. Tolkien",
                    ReleaseDate = DateTime.Parse("29/07/1954"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 99
                },
                new Book
                {
                    GenreId = 3,
                    Name = "Dune",
                    AuthorName = "Frank Herbert",
                    ReleaseDate = DateTime.Parse("01/08/1965"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 3
                },
                new Book
                {
                    GenreId = 4,
                    Name = "Murder on the Orient Express",
                    AuthorName = "Agatha Christie",
                    ReleaseDate = DateTime.Parse("01/01/1934"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 26
                },
                new Book
                {
                    GenreId = 5,
                    Name = "Steve Jobs: The Exclusive Biography",
                    AuthorName = "Walter Isaacson",
                    ReleaseDate = DateTime.Parse("24/10/2011"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 7
                },
                new Book
                {
                    GenreId = 6,
                    Name = "Shining",
                    AuthorName = "Stephen King",
                    ReleaseDate = DateTime.Parse("28/01/1977"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 56
                }
            );
        }

        private static void SeedGenres(ApplicationDbContext context)
        {
            context.Genre.AddRange(
                new Genre
                {
                    Id = 1,
                    Name = "Romance"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Fantasy"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Sci-Fi"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Criminal"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Biography"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Horror"
                }
            );
        }

        private static void SeedCustomers(UserManager<Customer> userManager)
        {
            var hasher = new PasswordHasher<Customer>();

            var customer1 = new Customer
            {
                Name = "Kate Brown",
                Email = "kate.brown@gmail.com",
                NormalizedEmail = "kate.brown@gmail.com",
                UserName = "kate.brown@gmail.com",
                NormalizedUserName = "kate.brown@gmail.com",
                MembershipTypeId = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "test")
            };

  
            userManager.CreateAsync(customer1).Wait();
            userManager.AddToRoleAsync(customer1, "user").Wait();

            var customer2 = new Customer
            {
                Name = "David Green",
                Email = "david.green@gmail.com",
                NormalizedEmail = "david.green@gmail.com",
                UserName = "david.green@gmail.com",
                NormalizedUserName = "david.green@gmail.com",
                MembershipTypeId = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "test")
            };


            userManager.CreateAsync(customer2).Wait();
            userManager.AddToRoleAsync(customer2, "storemanager").Wait();

            var customer3 = new Customer
            {
                Name = "John Smith",
                Email = "john.smith@gmail.com",
                NormalizedEmail = "john.smith@gmail.com",
                UserName = "john.smith@gmail.com",
                NormalizedUserName = "john.smith@gmail.com",
                MembershipTypeId = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "test")
            };


            userManager.CreateAsync(customer3).Wait();
            userManager.AddToRoleAsync(customer3, "owner").Wait();
        }

        private static void SeedRoles(ApplicationDbContext context)
        {
            context.Roles.AddRange(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "user"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "StoreManager",
                    NormalizedName = "storemanager"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Owner",
                    NormalizedName = "owner"
                }
            );

            context.SaveChanges();
        }

        private static void SeedMembershipTypes(ApplicationDbContext context)
        {
            context.MembershipTypes.AddRange(
                new MembershipType
                {
                    Id = 1,
                    Name = "Pay as You Go",
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0
                },
                new MembershipType
                {
                    Id = 2,
                    Name = "Monthly",
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10
                },
                new MembershipType
                {
                    Id = 3,
                    Name = "Quaterly",
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15
                },
                new MembershipType
                {
                    Id = 4,
                    Name = "Yearly",
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20
                }
            );

            context.SaveChanges();
        }
    }
}