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
    public class ReviewsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ReviewsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<Review>>>> GetReviews()
        {
            var result = await unitOfWork.Reviews.GetAllAsync();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Review>>> EditSlider([FromBody] Review review)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<Review>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });

            var result = await unitOfWork.Reviews.EditAsync(review);

            var saveResult = unitOfWork.Save();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            if (!saveResult.IsCompleteSuccessfully)
                return StatusCode(saveResult.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Review>>> AddSlider([FromBody] Review review)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<Review>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(
                        400,
                        string.Join("\n", ModelState.Values.SelectMany(v => v.Errors))
                    )
                });

            var result = await unitOfWork.Reviews.InsertAsync(review);

            var saveResult = unitOfWork.Save();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            if (!saveResult.IsCompleteSuccessfully)
                return StatusCode(saveResult.ErrorMessages.StatusCode, result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<Review>>> DeleteSlider(int id)
        {
            var result = await unitOfWork.Reviews.DeleteAsync(id);

            var saveResult = unitOfWork.Save();

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            if (!saveResult.IsCompleteSuccessfully)
                return StatusCode(saveResult.ErrorMessages.StatusCode, result);

            return Ok(result);
        }
    }


}
