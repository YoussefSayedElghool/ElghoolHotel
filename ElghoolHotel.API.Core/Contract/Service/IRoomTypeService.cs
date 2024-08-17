using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Models;

namespace ElghoolHotel.API.Core.Contract.Service
{
    public interface IRoomTypeService
    {
        Task<Result<List<RoomTypeDto>>> GetAllRoomTypeServiceAsync();
        Task<Result<RoomTypeDto>> AddRoomTypeServiceAsync(RoomTypeDto item);
        Task<Result<RoomTypeDto>> EditRoomTypeServiceAsync(RoomTypeDto item);
        Task<Result<RoomTypeDto>> RemoveRoomTypeServiceAsync(int id);
    }
}
