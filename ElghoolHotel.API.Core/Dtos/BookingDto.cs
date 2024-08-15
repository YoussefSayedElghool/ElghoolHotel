using ElghoolHotel.API.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.DTO
{
    public class BookingDto
    {
        public DateTime checkInDate { get; set; }
        public DateTime checkOutDate { get; set; }
        public virtual List<RoomRequest> RoomRequests { get; set; }
    }
}