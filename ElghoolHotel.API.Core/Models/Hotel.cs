using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }

        public virtual List<Room> Rooms { get; set; }

    }
}