using AutoMapper;
using ElghoolHotel.API.Core.Contract.Repository.UnitOfWork;
using ElghoolHotel.API.Core.Contract.Service;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;
using ElghoolHotel.API.Core.Models;
using ElghoolHotel.API.Core.Service;
using ElghoolHotel.API.Infrastructure.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace ElghoolHotel.API.Controllers
{

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly IRoomTypeService roomTypeService;

        public RoomTypesController(IRoomTypeService roomTypeService)
        {
            this.roomTypeService = roomTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<RoomTypeDto>>>> GetRoomTypes()
        {
            var result = await roomTypeService.GetAllRoomTypeServiceAsync();
       
            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<RoomTypeDto>>> EditRoomType([FromBody] RoomTypeDto RoomType)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<RoomTypeDto>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });

            var result = await roomTypeService.EditRoomTypeServiceAsync(RoomType);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<RoomTypeDto>>> AddRoomType([FromBody] RoomTypeDto RoomType)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<RoomTypeDto>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });

            var result = await roomTypeService.AddRoomTypeServiceAsync(RoomType);
           
            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<RoomTypeDto>>> DeleteRoomType(int id)
        {
            var result = await roomTypeService.RemoveRoomTypeServiceAsync(id);
            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);
            return Ok(result);
        }
    }


}
