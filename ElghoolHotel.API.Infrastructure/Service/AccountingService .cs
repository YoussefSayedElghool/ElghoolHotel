using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ElghoolHotel.API.Models;
using ElghoolHotel.API.Core.Contract.Service;
using ElghoolHotel.API.Core.Contract.Repository.UnitOfWork;
using ElghoolHotel.API.Core.Helpers;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Models;
using AutoMapper;

namespace ElghoolHotel.API.Service
{
    public class AccountingService : IAccountingService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper mapper;
        private readonly IUnitOfWork repositoryUnitOfWork;
        private readonly JWT _jwt;
        public AccountingService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt,IMapper mapper , IUnitOfWork repositoryUnitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.mapper = mapper;
            this.repositoryUnitOfWork = repositoryUnitOfWork;
            _jwt = jwt.Value;
        }

        public async Task<Result<AccountDto>> RegisterAsync(RegisterDto registerDto)
        {
            if (await _userManager.FindByEmailAsync(registerDto.Email) is not null)
                return new Result<AccountDto>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.EmailAlreadyRegistered };

            var user = mapper.Map<User>(registerDto);
            user.UserName = registerDto.Email;
            user.Image = ""; // hint
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors) errors += $"{error.Description},";

                return new Result<AccountDto>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.Custom(400 , errors) };
            }


            return await CreateAccount(user);

            
        }

        public async Task<Result<AccountDto>> LoginAsync(LoginDto model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return new Result<AccountDto>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.incorrectEmailOrPassword};

            return await CreateAccount(user);
        }

        public async Task<Result<AccountDto>> RefreshTokenAsync(string token)
        {
            
            var result = await repositoryUnitOfWork.RefreshTokens.RevokeRefreshTokenAsync(token);

            if (!result.IsCompleteSuccessfully)

                return new Result<AccountDto>()
                {
                    IsCompleteSuccessfully = result.IsCompleteSuccessfully,
                    ErrorMessages = result.ErrorMessages
                };


            var user = result.Data;
            return await CreateAccount((User)user);

        }

        public async Task<Result<bool>> RevokeTokenAsync(string token)
        {
            var result = await repositoryUnitOfWork.RefreshTokens.RevokeRefreshTokenAsync(token);

            if (!result.IsCompleteSuccessfully)
                
                return new Result<bool>()
                {
                    IsCompleteSuccessfully = result.IsCompleteSuccessfully,
                    ErrorMessages = result.ErrorMessages,
                    Data = result.IsCompleteSuccessfully
                };

            return new Result<bool>()
            {
                IsCompleteSuccessfully = result.IsCompleteSuccessfully,
                ErrorMessages = result.ErrorMessages,
                Data = result.IsCompleteSuccessfully
            };
        }



        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.DisplayName)
            }
            .Union(userClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }


        private async Task<Result<AccountDto>> CreateAccount(User user)
        {
            var jwtSecurityToken = await CreateJwtToken(user);

            Result<RefreshToken> refreshTokenResult = await repositoryUnitOfWork.RefreshTokens.GetActiveRefreshTokenAsync(user);

            if (!refreshTokenResult.IsCompleteSuccessfully)
                return new Result<AccountDto>()
                {
                    IsCompleteSuccessfully = false,
                    ErrorMessages = refreshTokenResult.ErrorMessages
                };


            var account = new AccountDto
            {
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                DisplayName = user.DisplayName,
                RefreshToken = refreshTokenResult.Data.Token,
                RefreshTokenExpiration = refreshTokenResult.Data.ExpiresOn,
                IsAuthenticated = true
            };


            return new Result<AccountDto>()
            {
                IsCompleteSuccessfully = true,
                Data = account
            };
        }



    }
}
