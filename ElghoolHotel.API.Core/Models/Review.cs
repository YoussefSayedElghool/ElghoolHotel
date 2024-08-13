using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string UserImageUrl  { get; set; }
        public string UserReview { get; set; }
    }
}