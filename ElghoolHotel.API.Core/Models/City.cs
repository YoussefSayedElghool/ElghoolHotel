using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public virtual List<Hotel> Hotels { get; set; }
    }
}