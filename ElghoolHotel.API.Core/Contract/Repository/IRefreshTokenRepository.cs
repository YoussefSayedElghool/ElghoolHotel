using ElghoolHotel.API.Core.Contract.Repository;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Models;

namespace ElghoolHotel.API.Core.Repository.abstraction_layer
{
    public interface IRefreshTokenRepository : IBaseRepository<RefreshToken>
    {
        Task<Result<RefreshToken>> GetActiveRefreshTokenAsync(IUserBase user);
        Task<Result<IUserBase>> RevokeRefreshTokenAsync(string refreshToken);

    }
}
