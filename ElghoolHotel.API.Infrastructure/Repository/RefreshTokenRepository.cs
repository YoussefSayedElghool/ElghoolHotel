using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using System.Security.Cryptography;
using ElghoolHotel.API.Infrastructure.Repository;
using ElghoolHotel.API.Models;
using ElghoolHotel.API.Core.Models;
using ElghoolHotel.API.Core.Repository.abstraction_layer;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;


namespace ElghoolHotel.API.Repository
{
    public class RefreshTokenRepository : BaseRepository<RefreshToken> ,  IRefreshTokenRepository
    {

        AppDbContext context;
        private readonly UserManager<User> userManager;

        public RefreshTokenRepository(AppDbContext _context , UserManager<User> userManager) : base(_context)
        {
            context = _context;
            this.userManager = userManager;
        }

        public async Task<Result<RefreshToken>> GetActiveRefreshTokenAsync(IUserBase user)
        {
            if (user is null) new Result<RefreshToken> { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.IncorrectInput };

            var result = new RefreshToken();
            if (user.RefreshTokens is not null && user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                result.Token = activeRefreshToken.Token;
                result.ExpiresOn = activeRefreshToken.ExpiresOn;

            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                result.Token = refreshToken.Token;
                result.ExpiresOn = refreshToken.ExpiresOn;
                user.RefreshTokens.Add(refreshToken);
                await userManager.UpdateAsync((User)user);
            }

            return new Result<RefreshToken>
            {
                IsCompleteSuccessfully = true,
                Data = result
            };


        }

        public async Task<Result<IUserBase>> RevokeRefreshTokenAsync(string token)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                return new Result<IUserBase>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.InvalidToken };


            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);
           
            if (!refreshToken.IsActive)
                return new Result<IUserBase>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.InvalidToken };


            refreshToken.RevokedOn = DateTime.UtcNow;

            try
            {
                await userManager.UpdateAsync(user);
            }
            catch (Exception)
            {
                return new Result<IUserBase>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.Unexpected};

            }

            return new Result<IUserBase>() { IsCompleteSuccessfully = true , Data = user };

        }


        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow
            };
        }

       
    }
}



