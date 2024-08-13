using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ElghoolHotel.API.Core.DTO
{
    public class AccountDto
    {
        public string? DisplayName { get; set; }

        public bool IsAuthenticated { get; set; }

        public string? Email { get; set; }

        public string? Token { get; set; }
        
        public string? RefreshToken { get; set; }
        
        public DateTime RefreshTokenExpiration { get; set; }
    }  
}