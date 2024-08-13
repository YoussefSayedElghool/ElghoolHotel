using ElghoolHotel.API.Core.Contract.Service;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;





namespace ElghoolHotel.API.Controllers
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountingService accountingService;

        public AccountsController(IAccountingService accountingService)
        {
            this.accountingService = accountingService;
        }


        [HttpPost("register")]
        public async Task<ActionResult<Result<AccountDto>>> RegisterAsync(RegisterDto registerDto)
        {
            if (registerDto is null || !ModelState.IsValid)
                return BadRequest(new Result<AccountDto>() { 
                IsCompleteSuccessfully = false,
                ErrorMessages = ErrorMessageUserConst.Custom(400 , string.Join("\n" , ModelState.Values.SelectMany(v => v.Errors)))
                });

            var result = await accountingService.RegisterAsync(registerDto);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);


            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Result<AccountDto>>> LoginAsync(LoginDto loginDto)
        {

            if (loginDto is null || !ModelState.IsValid)
                return BadRequest(new Result<AccountDto>()
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(400, string.Join("\n", ModelState.Values.SelectMany(v => v.Errors)))
                });

            var result = await accountingService.LoginAsync(loginDto);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);


            return Ok(result);
        }

        [HttpGet("refreshToken")]
        public async Task<ActionResult<Result<AccountDto>>> RefreshToken(RevokeTokenDto revokeTokenDto)
        {
            var refreshToken = revokeTokenDto.refreshToken;

            if (!ModelState.IsValid || string.IsNullOrEmpty(refreshToken))
                return BadRequest(new Result<AccountDto>()
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(400, string.Join("\n", ModelState.Values.SelectMany(v => v.Errors)))
                });


            var result = await accountingService.RefreshTokenAsync(refreshToken);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);


            return Ok(result);
        }

        [HttpDelete("revokeToken")]
        public async Task<ActionResult<Result<bool>>> RevokeToken([FromBody] RevokeTokenDto revokeTokenDto)
        {

            var refreshToken = revokeTokenDto.refreshToken;
            if (!ModelState.IsValid || string.IsNullOrEmpty(refreshToken))
                return BadRequest(new Result<bool>()
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = ErrorMessageUserConst.Custom(400, string.Join("\n", ModelState.Values.SelectMany(v => v.Errors)))
                });


            var result = await accountingService.RevokeTokenAsync(refreshToken);

            if (!result.IsCompleteSuccessfully)
                return StatusCode(result.ErrorMessages.StatusCode, result);

            return Ok(result);
        }



    }
}
