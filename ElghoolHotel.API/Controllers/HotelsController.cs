using ElghoolHotel.API.Core.Contract.Service;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;
using ElghoolHotel.API.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ElghoolHotel.API.Controllers
{

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService hotelService;

        public HotelsController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<HotelDto>>>> GetHotels()
        {
            var result = await hotelService.GetAllHotelServiceAsync();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<HotelDto>>> EditHotel(HotelDto hotelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<HotelDto>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });

            var result = await hotelService.EditHotelServiceAsync(hotelDto);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<HotelDto>>> AddHotel(HotelDto hotelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<HotelDto>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });

            var result = await hotelService.AddHotelServiceAsync(hotelDto);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<HotelDto>>> DeleteHotel(int id)
        {
            var result = await hotelService.RemoveHotelServiceAsync(id);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }
    }


}
