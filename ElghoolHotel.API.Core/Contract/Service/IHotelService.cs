using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Models;

namespace ElghoolHotel.API.Core.Contract.Service
{
    public interface IHotelService
    {
        Task<Result<List<HotelDto>>> GetAllHotelServiceAsync();
        Task<Result<HotelDto>> AddHotelServiceAsync(HotelDto item);
        Task<Result<HotelDto>> EditHotelServiceAsync(HotelDto item);
        Task<Result<HotelDto>> RemoveHotelServiceAsync(int id);
    }
}
