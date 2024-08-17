using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class RoomRequest
    {
        public int RoomRequestId { get; set; }
        public int AdultNumber { get; set; }
        public int ChildrenNumber { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }        
        
        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }

        public virtual List<Booking> Bags { get; set; }

    }
}