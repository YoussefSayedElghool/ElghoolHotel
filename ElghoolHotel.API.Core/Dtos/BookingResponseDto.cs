using ElghoolHotel.API.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.DTO
{
    public class BookingResponseDto
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public virtual List<RoomResponseDto> RoomRequests { get; set; }
    }
}