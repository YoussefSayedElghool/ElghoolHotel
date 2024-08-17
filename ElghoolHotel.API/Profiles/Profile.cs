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



            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Result<List<Hotel>>, Result<List<HotelDto>>>().ReverseMap();



            CreateMap<BookingRequestDto, Booking>().ReverseMap();

            //CreateMap<List<BookingRequestDto>, List<Booking>>().ReverseMap();

            CreateMap<Result<BookingRequestDto>, Result<Booking>>().ReverseMap();
            CreateMap<Result<List<BookingRequestDto>>, Result<List<Booking>>>().ReverseMap();

            CreateMap<RoomRequestDto, RoomRequest>().ReverseMap();

            CreateMap<Booking, BookingResponseDto>().ReverseMap();

            CreateMap<Result<List<Booking>>, Result<List<BookingResponseDto>>>().ReverseMap();


            //CreateMap<BookingResponseDto, Booking>()
            //    .ForMember(dest => dest.RoomRequests, opt => opt.MapFrom(src => src.RoomRequests));

            //CreateMap<RoomResponseDto, RoomRequest>()
            //    .ForMember(dest => dest.Hotel.Name, opt => opt.MapFrom(src => src.HotelName))
            //    .ForMember(dest => dest.RoomType.Type, opt => opt.MapFrom(src => src.RoomType));

            CreateMap<RoomRequest, RoomResponseDto>()
           .ForPath(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel.Name))
           .ForPath(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType.Type));
        }
    }
}
