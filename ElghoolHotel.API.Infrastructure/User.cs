

using ElghoolHotel.API.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace ElghoolHotel.API.Models
{
    public class User : IdentityUser , IUserBase
    {
        public required string DisplayName { get; set; }
        public string Image { get; set; }

        public virtual List<Bag> Bags { get; set; }
        public virtual List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    }
}
