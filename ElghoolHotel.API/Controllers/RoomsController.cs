using ElghoolHotel.API.Core.Contract.Repository.UnitOfWork;
using ElghoolHotel.API.Core.Contract.Service;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;
using ElghoolHotel.API.Core.Models;
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
    public class RoomsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public RoomsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<Room>>>> GetRooms()
        {
            var result = await unitOfWork.Rooms.GetAllAsync();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Room>>> EditRoom([FromBody] Room room)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<Room>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });

            var result = await unitOfWork.Rooms.EditAsync(room);
            var saveResult = unitOfWork.Save();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            if (!saveResult.IsCompleteSuccessfully)
                return StatusCode(saveResult.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Room>>> AddRoom([FromBody] Room room)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<Room>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });

            var result = await unitOfWork.Rooms.InsertAsync(room);

            var saveResult = unitOfWork.Save();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            if (!saveResult.IsCompleteSuccessfully)
                return StatusCode(saveResult.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<Room>>> DeleteRoom(int id)
        {
            var result = await unitOfWork.Rooms.DeleteAsync(id);

            var saveResult = unitOfWork.Save();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            if (!saveResult.IsCompleteSuccessfully)
                return StatusCode(saveResult.ErrorMessages.StatusCode, result);

            return Ok(result);
        }
    }


}
