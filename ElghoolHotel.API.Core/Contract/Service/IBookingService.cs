

using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Models;

namespace ElghoolHotel.API.Core.Service
{
    public interface IBookingService
    {
        Task<Result<Booking>> CreateBookingAsync(BookingRequestDto bookingDto,string userId);
        Task<Result<List<Booking>>> GetAllUserBookingAsync(string userId);
    }

}
