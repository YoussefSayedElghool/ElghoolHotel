using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class Slider
    {
        public int SliderId { get; set; }
        public string ImageUrl  { get; set; }
    }
}