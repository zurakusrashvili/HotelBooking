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
        private readonly IHotelRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingController(IHotelRepository bookingRepository, IMapper mapper)
        {
            this._bookingRepository = bookingRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            var hotels = await _bookingRepository.GetAllAsync();

            var records = _mapper.Map<List<HotelDto>>(hotels);

            return Ok(records);
        }

        // GET: api/Categories/5
        [HttpGet]
        [Route("GetHotel/{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _bookingRepository.GetHotelById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            var hotelDto = _mapper.Map<HotelDto>(hotel);
            return Ok(hotelDto);
        }
    }
}
