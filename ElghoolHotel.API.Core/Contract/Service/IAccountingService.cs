using ElghoolHotel.API.Core.DTO;

namespace ElghoolHotel.API.Core.Contract.Service
{
    public interface IAccountingService
    {
        Task<Result<AccountDto>> RegisterAsync(RegisterDto registerDto);
        Task<Result<AccountDto>> LoginAsync(LoginDto model);
        Task<Result<AccountDto>> RefreshTokenAsync(string token);
        Task<Result<bool>> RevokeTokenAsync(string token);
    }
}
