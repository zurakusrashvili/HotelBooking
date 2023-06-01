using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Emit;

namespace HotelBooking.Data
{
    public class HotelBookingDbContext : DbContext
    {

        private List<AvailableDate> GenerateMockAvailableDates(int roomId, DateTime startDate, DateTime endDate)
        {
            List<AvailableDate> availableDates = new List<AvailableDate>();
            int count = 1;
            for (int i = 1; i <= roomId; i++)
            {

                DateTime currentDate = startDate;
                while (currentDate <= endDate)
                {
                    AvailableDate availableDate = new AvailableDate
                    {
                        Id = count++,
                        Date = currentDate,
                        RoomId = i
                    };

                    availableDates.Add(availableDate);
                    currentDate = currentDate.AddDays(1);
                }
            }

            return availableDates;
        }


        public HotelBookingDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<AvailableDate> AvailableDates { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "The Biltmore Hotel Tbilisi",
                    Address = "29 Rustaveli Ave, Tbilisi, Tbilisi, 0108",
                    City = "Tbilisi",
                    FeaturedImage = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/41cbdcb1.jpg?impolicy=resizecrop&rw=1200&ra=fit"
                },

                new Hotel
                {
                    Id = 2,
                    Name = "Courtyard by Marriott Tbilisi",
                    Address = "4, Freedom Square, Tbilisi, 0105",
                    City = "Tbilisi",
                    FeaturedImage = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/3e65a896.jpg?impolicy=resizecrop&rw=1200&ra=fit"
                },

                new Hotel
                {
                    Id = 3,
                    Name = "Radisson Blu Iveria Hotel Tbilisi",
                    Address = "1 Republic square, Tbilisi, 0108",
                    City = "Tbilisi",
                    FeaturedImage = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/84d23097.jpg?impolicy=resizecrop&rw=1200&ra=fit"
                }

            );
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddYears(2);

            var availableDates = GenerateMockAvailableDates(20, startDate, endDate);
            modelBuilder.Entity<AvailableDate>().HasData( availableDates );

            modelBuilder.Entity<Room>().HasData(
                new Room()
                {
                    Id = 1,
                    Name = "Premium Room",
                    PricePerNight = 10,
                    HotelId = 1,
                    Available = true,
                    MaximumGuests = 3

                },

                 new Room()
                 {
                     Id = 2,
                     Name = "Deluxe Twin Room",
                     PricePerNight = 100,
                     HotelId = 1,
                     Available = true,
                     MaximumGuests = 3
                 },

                  new Room()
                  {
                      Id = 3,
                      Name = "Club Room",
                      PricePerNight = 100,
                      HotelId = 1,
                      Available = true,
                      MaximumGuests = 2
                  },

                   new Room()
                   {
                       Id = 4,
                       Name = "Deluxe Double Room",
                       PricePerNight = 10,
                       HotelId = 1,
                       Available = true,
                       MaximumGuests = 3
                   },

                    new Room()
                    {
                        Id = 5,
                        Name = "Junior Suite",
                        PricePerNight = 10,
                        HotelId = 1,
                        Available = true,
                        MaximumGuests = 3
                    },

                     new Room()
                     {
                         Id = 6,
                         Name = "Club Twin Room",
                         PricePerNight = 10,
                         HotelId = 1,
                         Available = true,
                         MaximumGuests = 2
                     },

                      new Room()
                      {
                          Id = 7,
                          Name = "Grand Deluxe Suite",
                          PricePerNight = 10,
                          HotelId = 1,
                          Available = true,
                          MaximumGuests = 3
                      },

                       new Room()
                       {
                           Id = 8,
                           Name = "Executive Suite",
                           PricePerNight = 10,
                           HotelId = 1,
                           Available = true,
                           MaximumGuests = 5
                       },

                       //2
                       new Room()
                       {
                           Id = 9,
                           Name = "Superior Twin Room",
                           PricePerNight = 10,
                           HotelId = 2,
                           Available = true,
                           MaximumGuests = 3
                       },

                       new Room()
                       {
                           Id = 10,
                           Name = "Junior Suite",
                           PricePerNight = 10,
                           HotelId = 2,
                           Available = true,
                           MaximumGuests = 3
                       },

                       new Room()
                       {
                           Id = 11,
                           Name = "Superior Room",
                           PricePerNight = 10,
                           HotelId = 2,
                           Available = true,
                           MaximumGuests = 3
                       },

                       new Room()
                       {
                           Id = 12,
                           Name = "Executive Room",
                           PricePerNight = 10,
                           HotelId = 2,
                           Available = true,
                           MaximumGuests = 3
                       },

                       new Room()
                       {
                           Id = 13,
                           Name = "Deluxe Twin Room",
                           PricePerNight = 10,
                           HotelId = 2,
                           Available = true,
                           MaximumGuests = 3
                       },

                       new Room()
                       {
                           Id = 14,
                           Name = "Deluxe Room",
                           PricePerNight = 10,
                           HotelId = 2,
                           Available = true,
                           MaximumGuests = 3
                       },


                        //3
                        new Room()
                        {
                            Id = 15,
                            Name = "Premium Room",
                            PricePerNight = 10,
                            HotelId = 3,
                            Available = true,
                            MaximumGuests = 3
                        },
                        new Room()
                        {
                            Id = 16,
                            Name = "Superior Room",
                            PricePerNight = 10,
                            HotelId = 3,
                            Available = true,
                            MaximumGuests = 3
                        },
                        new Room()
                        {
                            Id = 17,
                            Name = "Superior Room, City View (High Floor)",
                            PricePerNight = 10,
                            HotelId = 3,
                            Available = true,
                            MaximumGuests = 3
                        },
                        new Room()
                        {
                            Id = 18,
                            Name = "Standard Room",
                            PricePerNight = 10,
                            HotelId = 3,
                            Available = true,
                            MaximumGuests = 3
                        },
                        new Room()
                        {
                            Id = 19,
                            Name = "Junior Suite",
                            PricePerNight = 10,
                            HotelId = 3,
                            Available = true,
                            MaximumGuests = 4
                        },
                        new Room()
                        {
                            Id = 20,
                            Name = "Premium Room",
                            PricePerNight = 10,
                            HotelId = 3,
                            Available = true,
                            MaximumGuests = 2

                        }

        );

            modelBuilder.Entity<Image>().HasData(

new Image()
{
    Id = 1,
    RoomId = 1,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/78e5bc5d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 2,
    RoomId = 1,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/bf815e90.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 3,
    RoomId = 1,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/cbb31f78.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 4,
    RoomId = 1,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d9add37c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 5,
    RoomId = 1,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/11ed224a.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 6,
    RoomId = 1,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/1f20a362.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 7,
    RoomId = 2,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/b6bb61fc.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 8,
    RoomId = 2,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/14b60598.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 9,
    RoomId = 2,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/99460f51.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 10,
    RoomId = 2,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/7aac5bc6.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 11,
    RoomId = 2,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/f7436d8f.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 12,
    RoomId = 2,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d9add37c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 13,
    RoomId = 3,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/74bb8203.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 14,
    RoomId = 3,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/08619d53.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 15,
    RoomId = 3,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/afdf2bac.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 16,
    RoomId = 3,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/cbb31f78.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 17,
    RoomId = 3,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d6ca6c86.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 18,
    RoomId = 4,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/14b60598.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 19,
    RoomId = 4,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/74bb8203.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 20,
    RoomId = 4,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d6ca6c86.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 21,
    RoomId = 4,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/78e5bc5d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 22,
    RoomId = 4,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/8eb86ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 23,
    RoomId = 5,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/cbb31f78.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 24,
    RoomId = 5,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/bf815e90.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 25,
    RoomId = 5,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/7aac5bc6.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 26,
    RoomId = 5,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d6ca6c86.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 27,
    RoomId = 6,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/14b60598.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 28,
    RoomId = 6,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/f7436d8f.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 29,
    RoomId = 6,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/99460f51.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 30,
    RoomId = 6,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d9add37c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 31,
    RoomId = 7,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/1f20a362.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 32,
    RoomId = 7,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/11ed224a.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 33,
    RoomId = 7,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/8eb86ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 34,
    RoomId = 7,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d6ca6c86.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 35,
    RoomId = 8,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d6ca6c86.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 36,
    RoomId = 8,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/854cc524.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 37,
    RoomId = 8,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/1f20a362.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 38,
    RoomId = 8,
    Source = "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/3ac19564.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 39,
    RoomId = 9,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/eca80ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 40,
    RoomId = 9,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2e585f43.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 41,
    RoomId = 9,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/c3b4f65a.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 42,
    RoomId = 9,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/8b412d08.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 43,
    RoomId = 9,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/60315e6d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 44,
    RoomId = 10,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/d020b03c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 45,
    RoomId = 10,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/76e3960e.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 46,
    RoomId = 10,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2e585f43.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 47,
    RoomId = 10,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/eca80ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 48,
    RoomId = 10,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/acd56094.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 49,
    RoomId = 10,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/11f2b0fe.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 50,
    RoomId = 11,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/8715314f.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 51,
    RoomId = 11,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2e585f43.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 52,
    RoomId = 11,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/eca80ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 53,
    RoomId = 11,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/1b7de5ef.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 54,
    RoomId = 11,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/9c55692c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 55,
    RoomId = 11,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/11f2b0fe.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 56,
    RoomId = 12,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/58871759.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 57,
    RoomId = 12,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2e585f43.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 58,
    RoomId = 12,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/eca80ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 59,
    RoomId = 12,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2ded8747.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 60,
    RoomId = 12,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/b437570e.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 61,
    RoomId = 12,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/60315e6d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 62,
    RoomId = 13,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/ef867c3b.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 63,
    RoomId = 13,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2e585f43.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 64,
    RoomId = 13,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/eca80ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 65,
    RoomId = 13,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/b437570e.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 66,
    RoomId = 13,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/60315e6d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 67,
    RoomId = 13,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/8b412d08.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 68,
    RoomId = 13,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/ef867c3b.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 69,
    RoomId = 14,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/9c55692c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 70,
    RoomId = 14,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2e585f43.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 71,
    RoomId = 14,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/eca80ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 72,
    RoomId = 14,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/b437570e.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 73,
    RoomId = 14,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/60315e6d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 74,
    RoomId = 14,
    Source = "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/8b412d08.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 75,
    RoomId = 15,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/ea540433.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 76,
    RoomId = 15,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/2b8b7804.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 77,
    RoomId = 15,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/26bab1f5.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 78,
    RoomId = 15,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/496c6b5a.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 79,
    RoomId = 15,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/2f36defd.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 80,
    RoomId = 15,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/ea540433.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 81,
    RoomId = 15,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/2b8b7804.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 82,
    RoomId = 15,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/26bab1f5.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 83,
    RoomId = 16,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/406a3697.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 84,
    RoomId = 16,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/fa9c4653.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 85,
    RoomId = 16,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/14f420c8.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 86,
    RoomId = 16,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/c71aa3a5.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 87,
    RoomId = 16,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/549de7ab.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 88,
    RoomId = 16,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/a4557c21.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 89,
    RoomId = 16,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/72dc8d9c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 90,
    RoomId = 17,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/10371176.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 91,
    RoomId = 17,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/549de7ab.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 92,
    RoomId = 17,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/c71aa3a5.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 93,
    RoomId = 17,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/16a596de.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 94,
    RoomId = 17,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/72dc8d9c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 95,
    RoomId = 17,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/10371176.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 96,
    RoomId = 18,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/406a3697.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 97,
    RoomId = 18,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/67b0e7dc.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 98,
    RoomId = 18,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/549de7ab.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 99,
    RoomId = 18,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/95f52722.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 100,
    RoomId = 18,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/d3c76ffb.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 101,
    RoomId = 18,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/715be0ff.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 102,
    RoomId = 19,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/a2a0d8cd.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 103,
    RoomId = 19,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/029d4d4c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 104,
    RoomId = 19,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/411ebc16.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 105,
    RoomId = 19,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/d09117ce.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 106,
    RoomId = 19,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/c9d0a60d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 107,
    RoomId = 20,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/2b8b7804.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 108,
    RoomId = 20,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/a263f2a2.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 109,
    RoomId = 20,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/2056565d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 110,
    RoomId = 20,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/e498958a.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
},
new Image()
{
    Id = 111,
    RoomId = 20,
    Source = "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/4f130092.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium"
}
            );
        }

    }
}
