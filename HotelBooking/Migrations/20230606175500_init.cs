using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeaturedImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    MaximumGuests = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookedDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookedDates_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "City", "FeaturedImage", "Name" },
                values: new object[,]
                {
                    { 1, "29 Rustaveli Ave, Tbilisi, Tbilisi, 0108", "Tbilisi", "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/41cbdcb1.jpg?impolicy=resizecrop&rw=1200&ra=fit", "The Biltmore Hotel Tbilisi" },
                    { 2, "4, Freedom Square, Tbilisi, 0105", "Tbilisi", "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/3e65a896.jpg?impolicy=resizecrop&rw=1200&ra=fit", "Courtyard by Marriott Tbilisi" },
                    { 3, "1 Republic square, Tbilisi, 0108", "Tbilisi", "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/84d23097.jpg?impolicy=resizecrop&rw=1200&ra=fit", "Radisson Blu Iveria Hotel Tbilisi" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Single Room" },
                    { 2, "Double Room" },
                    { 3, "Deluxe Room" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Available", "HotelId", "MaximumGuests", "Name", "PricePerNight", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, true, 1, 3, "Premium Room", 199, 1 },
                    { 2, true, 1, 3, "Deluxe Twin Room", 299, 2 },
                    { 3, true, 1, 2, "Club Room", 89, 1 },
                    { 4, true, 1, 5, "Deluxe Double Room", 189, 2 },
                    { 5, true, 1, 3, "Junior Suite", 99, 1 },
                    { 6, true, 1, 2, "Club Twin Room", 199, 2 },
                    { 7, true, 1, 6, "Grand Deluxe Suite", 299, 3 },
                    { 8, true, 1, 5, "Executive Suite", 299, 1 },
                    { 9, true, 2, 5, "Superior Twin Room", 199, 2 },
                    { 10, true, 2, 3, "Junior Suite", 99, 2 },
                    { 11, true, 2, 5, "Superior Room", 399, 3 },
                    { 12, true, 2, 3, "Executive Room", 99, 2 },
                    { 13, true, 2, 4, "Deluxe Twin Room", 199, 2 },
                    { 14, true, 2, 3, "Deluxe Room", 149, 1 },
                    { 15, true, 3, 4, "Premium Room", 149, 2 },
                    { 16, true, 3, 6, "Superior Room", 299, 3 },
                    { 17, true, 3, 3, "Superior Room, City View (High Floor)", 399, 3 },
                    { 18, true, 3, 2, "Standard Room", 99, 1 },
                    { 19, true, 3, 4, "Junior Suite", 199, 2 },
                    { 20, true, 3, 2, "Premium Room", 149, 3 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "RoomId", "Source" },
                values: new object[,]
                {
                    { 1, 1, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/78e5bc5d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 2, 1, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/bf815e90.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 3, 1, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/cbb31f78.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 4, 1, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d9add37c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 5, 1, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/11ed224a.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 6, 1, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/1f20a362.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 7, 2, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/b6bb61fc.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 8, 2, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/14b60598.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 9, 2, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/99460f51.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 10, 2, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/7aac5bc6.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 11, 2, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/f7436d8f.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 12, 2, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d9add37c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 13, 3, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/74bb8203.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 14, 3, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/08619d53.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 15, 3, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/afdf2bac.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 16, 3, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/cbb31f78.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 17, 3, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d6ca6c86.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 18, 4, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/14b60598.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 19, 4, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/74bb8203.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 20, 4, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d6ca6c86.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 21, 4, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/78e5bc5d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 22, 4, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/8eb86ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 23, 5, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/cbb31f78.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 24, 5, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/bf815e90.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 25, 5, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/7aac5bc6.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 26, 5, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d6ca6c86.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 27, 6, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/14b60598.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 28, 6, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/f7436d8f.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 29, 6, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/99460f51.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 30, 6, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d9add37c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 31, 7, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/1f20a362.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 32, 7, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/11ed224a.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 33, 7, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/8eb86ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 34, 7, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d6ca6c86.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 35, 8, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/d6ca6c86.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 36, 8, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/854cc524.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 37, 8, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/1f20a362.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 38, 8, "https://images.trvl-media.com/lodging/16000000/15840000/15835100/15835033/3ac19564.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 39, 9, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/eca80ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 40, 9, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2e585f43.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 41, 9, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/c3b4f65a.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 42, 9, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/8b412d08.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 43, 9, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/60315e6d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 44, 10, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/d020b03c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 45, 10, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/76e3960e.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 46, 10, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2e585f43.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 47, 10, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/eca80ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 48, 10, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/acd56094.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 49, 10, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/11f2b0fe.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 50, 11, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/8715314f.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 51, 11, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2e585f43.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 52, 11, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/eca80ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 53, 11, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/1b7de5ef.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 54, 11, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/9c55692c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 55, 11, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/11f2b0fe.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 56, 12, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/58871759.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 57, 12, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2e585f43.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 58, 12, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/eca80ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 59, 12, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2ded8747.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 60, 12, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/b437570e.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 61, 12, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/60315e6d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 62, 13, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/ef867c3b.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 63, 13, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2e585f43.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 64, 13, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/eca80ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 65, 13, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/b437570e.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 66, 13, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/60315e6d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 67, 13, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/8b412d08.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 68, 13, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/ef867c3b.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 69, 14, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/9c55692c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 70, 14, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/2e585f43.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 71, 14, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/eca80ca3.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 72, 14, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/b437570e.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 73, 14, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/60315e6d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 74, 14, "https://images.trvl-media.com/lodging/1000000/920000/916400/916376/8b412d08.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 75, 15, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/ea540433.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 76, 15, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/2b8b7804.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 77, 15, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/26bab1f5.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 78, 15, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/496c6b5a.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 79, 15, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/2f36defd.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 80, 15, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/ea540433.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 81, 15, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/2b8b7804.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 82, 15, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/26bab1f5.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 83, 16, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/406a3697.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 84, 16, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/fa9c4653.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 85, 16, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/14f420c8.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 86, 16, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/c71aa3a5.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 87, 16, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/549de7ab.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 88, 16, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/a4557c21.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 89, 16, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/72dc8d9c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 90, 17, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/10371176.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 91, 17, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/549de7ab.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 92, 17, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/c71aa3a5.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 93, 17, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/16a596de.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 94, 17, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/72dc8d9c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 95, 17, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/10371176.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 96, 18, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/406a3697.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 97, 18, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/67b0e7dc.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 98, 18, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/549de7ab.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 99, 18, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/95f52722.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 100, 18, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/d3c76ffb.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 101, 18, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/715be0ff.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 102, 19, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/a2a0d8cd.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 103, 19, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/029d4d4c.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 104, 19, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/411ebc16.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 105, 19, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/d09117ce.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 106, 19, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/c9d0a60d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 107, 20, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/2b8b7804.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 108, 20, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/a263f2a2.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 109, 20, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/2056565d.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 110, 20, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/e498958a.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" },
                    { 111, 20, "https://images.trvl-media.com/lodging/3000000/2620000/2614700/2614694/4f130092.jpg?impolicy=fcrop&w=1200&h=800&p=1&q=medium" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedDates_RoomId",
                table: "BookedDates",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_RoomId",
                table: "Images",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedDates");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
