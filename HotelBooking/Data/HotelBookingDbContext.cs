using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HotelBooking.Data
{
    public class HotelBookingDbContext : DbContext
    {
        public HotelBookingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Category>().HasData(
        //        new Category
        //        {
        //            Id = 1,
        //            Name = "Salads"
        //        },
        //        new Category
        //        {
        //            Id = 2,
        //            Name = "Soups"
        //        },
        //        new Category
        //        {
        //            Id = 3,
        //            Name = "Chicken-Dishes"
        //        },
        //        new Category
        //        {
        //            Id = 4,
        //            Name = "Beef-Dishes"
        //        },
        //        new Category
        //        {
        //            Id = 5,
        //            Name = "Seafood-Dishes"
        //        },
        //        new Category
        //        {
        //            Id = 6,
        //            Name = "Vegetable-Dishes"
        //        },
        //        new Category
        //        {
        //            Id = 7,
        //            Name = "Bits&Bites"
        //        },
        //        new Category
        //        {
        //            Id = 8,
        //            Name = "On-The-Side"
        //        }
        //    );


        //    modelBuilder.Entity<Product>().HasData(
        //        new Product()
        //        {
        //            Id = 1,
        //            Name = "Laab kai chicken salad",
        //            Price = 10,
        //            Nuts = true,
        //            Image = "https://course-jsbasic.javascript.ru/assets/products/laab_kai_chicken_salad.png",
        //            Vegeterian = false,
        //            Spiciness = 2,
        //            CategoryId = 1
        //        },
        //      new Product()
        //      {
        //          Id = 2,
        //          Name = "Som tam papaya salad",
        //          Price = 9.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/som_tam_papaya_salad.png",
        //          Vegeterian = true,
        //          Spiciness = 0,
        //          CategoryId = 1
        //      },
        //      new Product()
        //      {
        //          Id = 3,
        //          Name = "Tom yam kai",
        //          Price = 7,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/tom_yam.png",
        //          Nuts = false,
        //          Vegeterian = false,
        //          Spiciness = 3,
        //          CategoryId = 2
        //      },
        //      new Product()
        //      {
        //          Id = 4,
        //          Name = "Tom kha kai",
        //          Price = 7,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/tom_kha.png",
        //          Nuts = false,
        //          Vegeterian = false,
        //          Spiciness = 3,
        //          CategoryId = 2
        //      },
        //      new Product()
        //      {
        //          Id = 5,
        //          Name = "Tom kha koong",
        //          Price = 8,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/tom_kha.png",
        //          Nuts = false,
        //          Vegeterian = false,
        //          Spiciness = 2,
        //          CategoryId = 2
        //      },
        //      new Product()
        //      {
        //          Id = 6,
        //          Name = "Tom yam koong",
        //          Price = 8,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/tom_yam.png",
        //          Vegeterian = false,
        //          Spiciness = 4,
        //          CategoryId = 2
        //      },
        //      new Product()
        //      {
        //          Id = 7,
        //          Name = "Tom yam vegetarian",
        //          Price = 7,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/tom_yam.png",
        //          Nuts = false,
        //          Vegeterian = true,
        //          Spiciness = 1,
        //          CategoryId = 2
        //      },
        //      new Product()
        //      {
        //          Id = 8,
        //          Name = "Tom kha vegetarian",
        //          Price = 7,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/tom_kha.png",
        //          Vegeterian = true,
        //          Spiciness = 1,
        //          CategoryId = 2
        //      },
        //      new Product()
        //      {
        //          Id = 9,
        //          Name = "Sweet 'n sour chicken",
        //          Price = 14,
        //          Nuts = true,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/sweet_n_sour.png",
        //          Vegeterian = false,
        //          Spiciness = 2,
        //          CategoryId = 3
        //      },
        //      new Product()
        //      {
        //          Id = 10,
        //          Name = "Chicken cashew",
        //          Price = 14,
        //          Nuts = true,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/chicken_cashew.png",
        //          Vegeterian = false,
        //          Spiciness = 1,
        //          CategoryId = 3
        //      },
        //      new Product()
        //      {
        //          Id = 11,
        //          Name = "Kai see ew",
        //          Price = 14,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/kai_see_ew.png",
        //          Nuts = false,
        //          Vegeterian = false,
        //          Spiciness = 4,
        //          CategoryId = 3
        //      },
        //      new Product()
        //      {
        //          Id = 12,
        //          Name = "Beef massaman",
        //          Price = 14.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/beef_massaman.png",
        //          Vegeterian = false,
        //          Spiciness = 2,
        //          CategoryId = 4
        //      },
        //      new Product()
        //      {
        //          Id = 13,
        //          Name = "Seafood chu chee",
        //          Price = 16,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/chu_chee.png",
        //          Nuts = false,
        //          Vegeterian = false,
        //          Spiciness = 2,
        //          CategoryId = 5
        //      },
        //      new Product()
        //      {
        //          Id = 14,
        //          Name = "Penang shrimp",
        //          Price = 16,
        //          Nuts = true,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/red_curry.png",
        //          Vegeterian = false,
        //          Spiciness = 4,
        //          CategoryId = 5
        //      },
        //      new Product()
        //      {
        //          Id = 15,
        //          Name = "Green curry veggies",
        //          Price = 12.5,
        //          Nuts = true,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/green_curry.png",
        //          Vegeterian = true,
        //          Spiciness = 0,
        //          CategoryId = 6
        //      },
        //      new Product()
        //      {
        //          Id = 16,
        //          Name = "Tofu cashew",
        //          Price = 12.5,
        //          Nuts = true,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/tofu_cashew.png",
        //          Vegeterian = true,
        //          Spiciness = 0,
        //          CategoryId = 6
        //      },
        //      new Product()
        //      {
        //          Id = 17,
        //          Name = "Red curry veggies",
        //          Price = 12.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/red_curry_vega.png",
        //          Vegeterian = true,
        //          Spiciness = 4,
        //          CategoryId = 6
        //      },
        //      new Product()
        //      {
        //          Id = 18,
        //          Name = "Krapau tofu",
        //          Price = 12.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/krapau_vega.png",
        //          Vegeterian = true,
        //          Spiciness = 0,
        //          CategoryId = 6
        //      },
        //      new Product()
        //      {
        //          Id = 19,
        //          Name = "Prawn crackers",
        //          Price = 2.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/kroepoek.png",
        //          Vegeterian = false,
        //          Spiciness = 1,
        //          CategoryId = 7
        //      },
        //      new Product()
        //      {
        //          Id = 20,
        //          Name = "Fish cakes",
        //          Price = 6.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/fish_cakes.png",
        //          Vegeterian = false,
        //          Spiciness = 1,
        //          CategoryId = 7
        //      },
        //      new Product()
        //      {
        //          Id = 21,
        //          Name = "Chicken satay",
        //          Price = 6.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/sate.png",
        //          Vegeterian = false,
        //          Spiciness = 1,
        //          CategoryId = 7
        //      },
        //      new Product()
        //      {
        //          Id = 22,
        //          Name = "Satay sauce",
        //          Price = 1.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/satesaus.png",
        //          Vegeterian = false,
        //          Spiciness = 2,
        //          CategoryId = 7
        //      },
        //      new Product()
        //      {
        //          Id = 23,
        //          Name = "Shrimp springrolls",
        //          Price = 6.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/koong_hom_pha.png",
        //          Vegeterian = false,
        //          Spiciness = 3,
        //          CategoryId = 7
        //      },
        //      new Product()
        //      {
        //          Id = 24,
        //          Name = "Mini vegetarian spring rolls",
        //          Price = 6.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/mini_vega_springrolls.png",
        //          Vegeterian = false,
        //          Spiciness = 2,
        //          CategoryId = 7
        //      },
        //      new Product()
        //      {
        //          Id = 25,
        //          Name = "Chicken springrolls",
        //          Price = 6.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/chicken_loempias.png",
        //          Vegeterian = false,
        //          Spiciness = 2,
        //          CategoryId = 7
        //      },
        //      new Product()
        //      {
        //          Id = 26,
        //          Name = "Thai fried rice",
        //          Price = 7.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/fried_rice.png",
        //          Vegeterian = false,
        //          Spiciness = 2,
        //          CategoryId = 8
        //      },
        //      new Product()
        //      {
        //          Id = 27,
        //          Name = "Fresh prawn crackers",
        //          Price = 2.5,
        //          Nuts = false,
        //          Image = "https://course-jsbasic.javascript.ru/assets/products/kroepoek.png",
        //          Vegeterian = false,
        //          Spiciness = 1,
        //          CategoryId = 8
        //      });

        //}

    }
}
