namespace ElghoolHotel.API.Core.Models
{

    public interface IUserBase
    {
        public string DisplayName { get; set; }
        public string NationalId { get; set; }
        public bool HasDiscount { get; set; }
        public double Discount { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public List<Booking> Bags { get; set; }

    }
}

