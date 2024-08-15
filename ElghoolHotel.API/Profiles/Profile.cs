using AutoMapper;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Models;
using ElghoolHotel.API.Models;


namespace ElghoolHotel.API.Profiles
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<RegisterDto, IUserBase>();
            CreateMap<RoomTypeDto, RoomType>().ReverseMap();
            CreateMap<Result<List<RoomType>>, Result<List<RoomTypeDto>>>().ReverseMap();
        }
    }
}
