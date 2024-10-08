﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime CheckInDate{ get; set; }
        public DateTime CheckOutDate{ get; set; }
        public virtual List<RoomRequest> RoomRequests { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual IUserBase User { get; set; }
    }
}