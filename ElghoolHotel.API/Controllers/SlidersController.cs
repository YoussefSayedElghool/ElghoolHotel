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
    public class SlidersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public SlidersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<Slider>>>> GetSliders()
        {
            var result = await unitOfWork.Sliders.GetAllAsync();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Slider>>> EditSlider([FromBody] Slider slider)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<Slider>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });

            var result = await unitOfWork.Sliders.EditAsync(slider);
            var saveResult = unitOfWork.Save();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            if (!saveResult.IsCompleteSuccessfully)
                return StatusCode(saveResult.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Slider>>> AddSlider([FromBody] Slider slider)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<Slider>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });

            var result = await unitOfWork.Sliders.InsertAsync(slider);

            var saveResult = unitOfWork.Save();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            if (!saveResult.IsCompleteSuccessfully)
                return StatusCode(saveResult.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<Slider>>> DeleteSlider(int id)
        {
            var result = await unitOfWork.Sliders.DeleteAsync(id);

            var saveResult = unitOfWork.Save();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            if (!saveResult.IsCompleteSuccessfully)
                return StatusCode(saveResult.ErrorMessages.StatusCode, result);

            return Ok(result);
        }
    }


}
