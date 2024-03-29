﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Data
{
    public class BookedDate
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(RoomId))]
        public int RoomId { get; set; }
    }
}
