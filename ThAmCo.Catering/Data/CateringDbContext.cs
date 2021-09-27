using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Data
{
    public class CateringDbContext : DbContext
    {

        // Connections to the database for each table
        public DbSet<FoodItem> FoodItem { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<MenuFoodItem> MenuFoodItem { get; set; }

        public DbSet<FoodBooking> FoodBooking { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Catering;");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Compound key connection for MenuFoodItem
            builder.Entity<MenuFoodItem>()
                .HasKey(a => new { a.MenuId, a.FoodItemId });

            builder.Entity<MenuFoodItem>()
                .HasOne(a => a.Menu)
                .WithMany(m => m.FoodItems)
                .HasForeignKey(a => a.MenuId);

            builder.Entity<MenuFoodItem>()
                .HasOne(a => a.FoodItem)
                .WithMany()
                .HasForeignKey(a => a.FoodItemId);


            // Provide seed data
            builder.Entity<FoodItem>().HasData(
                new FoodItem { FoodItemId = 1, Description = "Spaghetti and Bolognese", unitPrice = 5.99f },
                new FoodItem { FoodItemId = 2, Description = "Full English", unitPrice = 7.99f },
                new FoodItem { FoodItemId = 3, Description = "Fish & Chips", unitPrice = 4.99f }
            );

            builder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, MenuName = "Breakfast"},
                new Menu { MenuId = 2, MenuName = "Lunch"},
                new Menu { MenuId = 3, MenuName = "Dinner"}
            );

            builder.Entity<MenuFoodItem>().HasData(
                new MenuFoodItem {MenuId = 1, FoodItemId = 2},
                new MenuFoodItem {MenuId = 2, FoodItemId = 1},
                new MenuFoodItem {MenuId = 3, FoodItemId = 3}
            );

            builder.Entity<FoodBooking>().HasData(
                new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 5, MenuId = 2 },
                new FoodBooking { FoodBookingId = 2, ClientReferenceId = 2, NumberOfGuests = 2, MenuId = 3}
            );
        }
    }
}
