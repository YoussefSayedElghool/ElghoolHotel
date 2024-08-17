using AutoMapper;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;
using ElghoolHotel.API.Core.Models;
using ElghoolHotel.API.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;


namespace ElghoolHotel.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService bookingService;
        private readonly IMapper mapper;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            this.bookingService = bookingService;
            this.mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Result<BookingRequestDto>>> Booking([FromForm] BookingRequestDto bookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Result<BookingRequestDto>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return BadRequest(new Result<BookingRequestDto>()
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(404, string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))),
                });

            var result = await bookingService.CreateBookingAsync(bookingDto , userId);

            var resultDto = mapper.Map<Result<BookingRequestDto>>(result);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(resultDto); 
        }


        [HttpGet]
        public async Task<ActionResult<Result<List<BookingResponseDto>>>> Booking()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return BadRequest(new Result<List<BookingResponseDto>>()
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(404, string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))),
                });


            var result = await bookingService.GetAllUserBookingAsync(userId);

            var resultDto = mapper.Map<Result<List<BookingResponseDto>>>(result);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(resultDto); 
        }
    
    
    }
}