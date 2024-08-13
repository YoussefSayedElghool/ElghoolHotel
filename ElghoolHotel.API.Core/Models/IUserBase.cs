namespace ElghoolHotel.API.Core.Models
{

    public interface IUserBase
    {
        public string DisplayName { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }
        public List<Bag> Bags { get; set; }

    }
}

