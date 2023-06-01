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

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomsRepository _roomRepository;
        private readonly IMapper _mapper;

        public BookingController(IBookingRepository bookingRepository,IRoomsRepository roomRepository, IMapper mapper)
        {
            this._bookingRepository = bookingRepository;
            this._roomRepository = roomRepository;
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

            var bookedDates = room.AvailableDates
                .Where(ad => ad.Date >= booking.CheckInDate && ad.Date <= booking.CheckOutDate)
                .ToList();

            if (bookedDates.Count > 0)
            {
                foreach (var bookedDate in bookedDates)
                {
                    room.AvailableDates.Remove(bookedDate);
                }
            }
            else
            {
                return BadRequest("The room is already booked for some of the selected dates.");
            }

            booking.TotalPrice = (int)(booking.CheckOutDate - booking.CheckInDate).TotalDays * room.PricePerNight;

            await _bookingRepository.AddAsync(booking);

            return Ok($"Booking created successfully. Booking Id {booking.Id}");
        }
    }
}
