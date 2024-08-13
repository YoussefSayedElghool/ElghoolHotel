using AutoMapper;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Models;


namespace ElghoolHotel.API.Profiles
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<RegisterDto, IUserBase>();
        }
    }
}
