
using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class Bag
    {
        public int BagId { get; set; }
        public string Name { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual IUserBase User { get; set; }
    }
}