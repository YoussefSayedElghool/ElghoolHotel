using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class HotelDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}