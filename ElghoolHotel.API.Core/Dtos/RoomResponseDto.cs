using ElghoolHotel.API.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.DTO
{
    public class RoomResponseDto
    {
        public int AdultNumber { get; set; }
        public int ChildrenNumber { get; set; }
        public string HotelName { get; set; }
        public string RoomType { get; set; }

    }
}