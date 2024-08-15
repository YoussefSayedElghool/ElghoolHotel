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
    public class HotelsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public HotelsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<Hotel>>>> GetHotels()
        {
            var result = await unitOfWork.Hotels.GetAllAsync();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Hotel>>> EditHotel([FromBody] Hotel Hotel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<Hotel>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });

            var result = await unitOfWork.Hotels.EditAsync(Hotel);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Hotel>>> AddHotel([FromBody] Hotel Hotel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<Hotel>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });

            var result = await unitOfWork.Hotels.InsertAsync(Hotel);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<Hotel>>> DeleteHotel(int id)
        {
            var result = await unitOfWork.Hotels.DeleteAsync(id);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }
    }


}
