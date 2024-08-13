using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string UserImageUrl  { get; set; }
        public string UserReview { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }

    }
}