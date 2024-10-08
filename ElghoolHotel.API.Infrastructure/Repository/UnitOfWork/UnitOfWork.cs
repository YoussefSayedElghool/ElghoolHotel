﻿using ElghoolHotel.API.Core.Contract.Repository;
using ElghoolHotel.API.Core.Contract.Repository.UnitOfWork;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;
using ElghoolHotel.API.Core.Repository.abstraction_layer;
using ElghoolHotel.API.Models;

namespace ElghoolHotel.API.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public IHotelRepository Hotels { get; }

        public IRoomRepository Rooms { get; }

        public IRoomTypeRepository RoomTypes { get; }

        public ISliderRepository Sliders { get; }

        public IReviewRepository Reviews { get; }

        public ICityRepository Cities { get; }

        public IBookingRepository Bookings { get; }

        public IRefreshTokenRepository RefreshTokens { get; }

        public UnitOfWork(AppDbContext context, IHotelRepository hotels, IRoomRepository rooms, IRoomTypeRepository roomTypes, ISliderRepository sliders, IReviewRepository reviews, ICityRepository cities, IBookingRepository bookings, IRefreshTokenRepository refreshTokens)
        {
            this.context = context;
            Hotels = hotels;
            Rooms = rooms;
            RoomTypes = roomTypes;
            Sliders = sliders;
            Reviews = reviews;
            Cities = cities;
            Bookings = bookings;
            RefreshTokens = refreshTokens;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Result<bool> Save()
        {
            bool returnValue = true;
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
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
