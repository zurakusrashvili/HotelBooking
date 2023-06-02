using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Contracts;
using HotelBooking.Models.Rooms;
using HotelBooking.Data;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsRepository _roomsRepository;
        private readonly IMapper _mapper;

        public RoomsController(IRoomsRepository roomsRepository, IMapper mapper)
        {
            this._roomsRepository = roomsRepository;
            this._mapper = mapper;
        }

        // GET: api/Rooms
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAllRooms()
        {
            var rooms = await _roomsRepository.GetAllAsync();
            return Ok(_mapper.Map<List<RoomDto>>(rooms));
        }

        [HttpGet]
        [Route("GetRoom/{id}")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoomById(int id)
        {
            var room = await _roomsRepository.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            var roomDto = _mapper.Map<RoomDto>(room);
            return Ok(roomDto);
        }
        [HttpGet]
        [Route("GetAvailableRooms")]
        public async Task<ActionResult<IList<RoomDto>>> GetAvailableStatus([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var rooms = await _roomsRepository.GetAllRooms();

            if (rooms == null)
            {
                return NotFound();
            }

            var availableRooms = rooms.Where(room =>
                !room.BookedDates.Any(ad => ad.Date >= from && ad.Date <= to)
            ).ToList();

            var roomDto = _mapper.Map<List<RoomDto>>(availableRooms);
            return Ok(roomDto);
        }




        //[HttpGet]
        //[Route("GetFiltered")]
        //public async Task<ActionResult<IEnumerable<ProductDto>>> GetFilteredProducts([FromQuery]bool? vegeterian, [FromQuery]bool? nuts, [FromQuery]int? spiciness, [FromQuery] int? categoryId)
        //{
        //    var products = await _roomsRepository.GetFiltered(vegeterian, nuts, spiciness, categoryId);

        //    return Ok(_mapper.Map<List<ProductDto>>(products));
        //}
    }
}
