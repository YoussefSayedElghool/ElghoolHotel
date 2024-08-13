using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Repository.abstraction_layer;

namespace ElghoolHotel.API.Core.Contract.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRoomRepository Hotels { get; }
        IRoomRepository Rooms { get; }
        IRoomTypeRepository RoomTypes { get; }
        ISliderRepository Sliders { get; }
        IReviewRepository Reviews { get; }
        ICityRepository Cities { get; }
        IBagRepository Bags { get; }
        IRefreshTokenRepository RefreshTokens { get; }

        Result<bool> Save();
    }
}
