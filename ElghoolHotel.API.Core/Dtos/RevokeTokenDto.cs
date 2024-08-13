
using System.ComponentModel.DataAnnotations;

namespace ElghoolHotel.API.Core.DTO
{
    public class RevokeTokenDto
    {
            [Required]
            public string refreshToken { get; set; }
        
    }
}
