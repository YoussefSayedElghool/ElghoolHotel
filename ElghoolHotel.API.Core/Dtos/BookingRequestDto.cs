using ElghoolHotel.API.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.DTO
{
    public class BookingRequestDto
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public virtual List<RoomRequestDto> RoomRequests { get; set; }
    }
}