
using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime checkInDate{ get; set; }
        public DateTime checkOutDate{ get; set; }
        public virtual List<RoomRequest> Rooms { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual IUserBase User { get; set; }
    }
}