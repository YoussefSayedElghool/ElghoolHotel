﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ElghoolHotel.API.Infrastructure.Repository;
using ElghoolHotel.API.Models;
using ElghoolHotel.API.Core.Models;
using ElghoolHotel.API.Core.Contract.Repository;


namespace ElghoolHotel.API.Repository
{
    public class CityRepository : BaseRepository<City> , ICityRepository
    {
        public CityRepository(AppDbContext _context) : base(_context)
        {
        }

    }
}



