using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int MaxAdultNumber { get; set; }
        public int MaxChildrenNumber { get; set; }
        public double Price { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }        
        
        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}