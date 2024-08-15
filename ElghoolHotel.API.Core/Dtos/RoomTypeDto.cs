using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.DTO
{
    public class RoomTypeDto
    {
        public int RoomTypeId { get; set; }
        public string Type { get; set; }
    }
}