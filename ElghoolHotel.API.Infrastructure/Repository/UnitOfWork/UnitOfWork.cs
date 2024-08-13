using ElghoolHotel.API.Core.Contract.Repository;
using ElghoolHotel.API.Core.Contract.Repository.UnitOfWork;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;
using ElghoolHotel.API.Core.Repository.abstraction_layer;
using ElghoolHotel.API.Models;

namespace ElghoolHotel.API.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRoomRepository Hotels { get; }

        public IRoomRepository Rooms { get; }

        public IRoomTypeRepository RoomTypes { get; }

        public ISliderRepository Sliders { get; }

        public IReviewRepository Reviews { get; }

        public ICityRepository Cities { get; }

        public IBagRepository Bags { get; }

        public IRefreshTokenRepository RefreshTokens { get; }

        public UnitOfWork(IRoomRepository hotels, IRoomRepository rooms, IRoomTypeRepository roomTypes, ISliderRepository sliders, IReviewRepository reviews, ICityRepository cities, IBagRepository bags, IRefreshTokenRepository refreshTokens)
        {
            Hotels = hotels;
            Rooms = rooms;
            RoomTypes = roomTypes;
            Sliders = sliders;
            Reviews = reviews;
            Cities = cities;
            Bags = bags;
            RefreshTokens = refreshTokens;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Result<bool> Save()
        {
            bool returnValue = true;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return new Result<bool>()
                    {
                        IsCompleteSuccessfully = true,
                        Data = true
                    };
                }
                catch (Exception)
                {
                    returnValue = false;
                    dbContextTransaction.Rollback();
                    return new Result<bool>()
                    {
                        IsCompleteSuccessfully = false,
                        Data = false,
                        ErrorMessages = ErrorMessageUserConst.Unexpected
                    };
                }
            }
        }
    }
}
