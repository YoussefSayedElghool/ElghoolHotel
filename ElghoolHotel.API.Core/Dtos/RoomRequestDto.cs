using ElghoolHotel.API.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.DTO
{
    public class RoomRequestDto
    {
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public int AdultNumber { get; set; }
        public int ChildrenNumber { get; set; }
    }
}