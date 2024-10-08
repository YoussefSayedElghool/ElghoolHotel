﻿using System;
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
        IHotelRepository Hotels { get; }
        IRoomRepository Rooms { get; }
        IRoomTypeRepository RoomTypes { get; }
        ISliderRepository Sliders { get; }
        IReviewRepository Reviews { get; }
        ICityRepository Cities { get; }
        IBookingRepository Bookings { get; }
        IRefreshTokenRepository RefreshTokens { get; }

        Result<bool> Save();
    }
}
