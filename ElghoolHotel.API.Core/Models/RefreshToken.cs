﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ElghoolHotel.API.Core.Models
{
    public class RefreshToken
    {
        public int RefreshTokenId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        public bool IsRevoked => RevokedOn != null;
        public bool IsActive => RevokedOn == null && !IsExpired;

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual IUserBase User { get; set; } = null!;
    }
}
