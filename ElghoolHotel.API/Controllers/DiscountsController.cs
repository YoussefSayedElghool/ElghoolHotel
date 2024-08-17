using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;
using ElghoolHotel.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ElghoolHotel.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly UserManager<User> userManager;

        public DiscountsController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<Result<bool>>> HasDiscount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                return new Result<bool>
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.IncorrectInput
                };

            return new Result<bool>
            {
                IsCompleteSuccessfully = true,
                Data = user.HasDiscount
            };
        }


    }
}
