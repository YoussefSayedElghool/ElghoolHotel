using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string Type { get; set; }
        public virtual List<Room> Rooms { get; set; }

    }
}