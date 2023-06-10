using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Contracts;
using HotelBooking.Models.Hotels;
using HotelBooking.Data;
using NuGet.Packaging;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomsRepository _roomRepository;
        private readonly IDatesRepository _datesRepository;
        private readonly IMapper _mapper;

        public BookingController(IBookingRepository bookingRepository,IRoomsRepository roomRepository, IDatesRepository datesRepository, IMapper mapper)
        {
            this._bookingRepository = bookingRepository;
            this._roomRepository = roomRepository;
            this._datesRepository = datesRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingRepository.GetAllAsync();
            return Ok(bookings);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room = await _roomRepository.GetRoomById(booking.RoomID);

            if (room == null || !room.Available)
            {
                return BadRequest("The selected room is not available.");
            }

            var overlappingDates = room.BookedDates
                .Any(ad => ad.Date >= booking.CheckInDate && ad.Date < booking.CheckOutDate);



            if (overlappingDates)
            {
                return BadRequest("The room is already booked for some of the selected dates.");
            }

            // Add the booked dates to the room.BookedDates collection
            for (var currentDate = booking.CheckInDate.Date; currentDate < booking.CheckOutDate.Date; currentDate = currentDate.AddDays(1))
            {
                room.BookedDates.Add(new BookedDate { Date = currentDate });
            }

            await _roomRepository.UpdateAsync(room); // Update the room with the added booked dates

            booking.TotalPrice = (int)(booking.CheckOutDate - booking.CheckInDate).TotalDays * room.PricePerNight;

            await _bookingRepository.AddAsync(booking);


            return Ok($"Booking retrieved successfully. Booking Id {booking.Id}");

        }

        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var booking = await _bookingRepository.GetAsync(bookingId);

            if (booking == null)
            {
                return NotFound("Booking not found.");
            }

            var room = await _roomRepository.GetRoomById(booking.RoomID);

            if (room == null)
            {
                return NotFound("Room not found.");
            }

            var bookedDatesToRemove = room.BookedDates
                .Where(ad => ad.Date >= booking.CheckInDate && ad.Date < booking.CheckOutDate)
                .ToList();

            if (bookedDatesToRemove.Count > 0)
            {
                foreach (var bookedDate in bookedDatesToRemove)
                {
                    room.BookedDates.Remove(bookedDate);
                }

                await _roomRepository.UpdateAsync(room); // Update the room to remove the booked dates
                await _bookingRepository.DeleteAsync(booking.Id); // Delete the booking

                return Ok($"Booking canceled successfully. Booking Id {booking.Id}");
            }

            return BadRequest("No booked dates found for the booking.");
        }





    }
}
