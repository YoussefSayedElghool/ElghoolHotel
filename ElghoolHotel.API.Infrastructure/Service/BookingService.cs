using AutoMapper;
using ElghoolHotel.API.Core.Contract.Repository.UnitOfWork;
using ElghoolHotel.API.Core.Contract.Service;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;
using ElghoolHotel.API.Core.Models;
using ElghoolHotel.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ElghoolHotel.API.Core.Service
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> userManager;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<Result<Booking>> CreateBookingAsync(BookingRequestDto bookingDto , string userId)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId);

                if (user == null)
                    return new Result<Booking>
                    {
                        IsCompleteSuccessfully = false,
                        ErrorMessages = ErrorMessageUserConst.IncorrectInput
                    };
                
                if (!user.HasDiscount)
                {
                    user.HasDiscount = true;
                }

                var booking = _mapper.Map<Booking>(bookingDto);
                booking.UserId = userId;
                await _unitOfWork.Bookings.InsertAsync(booking);
                _unitOfWork.Save();

                return new Result<Booking>
                {
                    IsCompleteSuccessfully = true,
                    Data = booking
                };
            }
            catch (Exception ex)
            {
                return new Result<Booking>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Unexpected
                };
            }
        }
   
    
    
        public async Task<Result<List<Booking>>> GetAllUserBookingAsync(string userId)
        {

            if (string.IsNullOrEmpty(userId))
                return new Result<List<Booking>>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.IncorrectInput
                };


            var bookings = await _unitOfWork.Bookings.GetWhereAsync(b => b.UserId == userId);

            if (!bookings.IsCompleteSuccessfully)
                return new Result<List<Booking>>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = bookings.ErrorMessages
                };


            if (bookings.Data == null || bookings.Data.Count() == 0)
                return new Result<List<Booking>>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.NotFound
                };



            return bookings;

        }



    }

}
