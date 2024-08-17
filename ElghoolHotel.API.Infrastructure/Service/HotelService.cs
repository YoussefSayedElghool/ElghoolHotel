using AutoMapper;
using ElghoolHotel.API.Core.Contract.Repository.UnitOfWork;
using ElghoolHotel.API.Core.Contract.Service;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;
using ElghoolHotel.API.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;

namespace ElghoolHotel.API.Core.Service
{
    public class HotelService : IHotelService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public HotelService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public async Task<Result<List<HotelDto>>> GetAllHotelServiceAsync()
        {
            return mapper.Map<Result<List<HotelDto>>>(await unitOfWork.Hotels.GetAllAsync());
        }
        public async Task<Result<HotelDto>> AddHotelServiceAsync(HotelDto item)
        {
            var hotel = mapper.Map<Hotel>(item);
            
            var result = await unitOfWork.Hotels.InsertAsync(hotel);
            var saveResult = unitOfWork.Save();

            if (!saveResult.IsCompleteSuccessfully)
                return new Result<HotelDto>() { 
                IsCompleteSuccessfully = saveResult.IsCompleteSuccessfully,
                ErrorMessages = saveResult.ErrorMessages
                };

            return mapper.Map<Result<HotelDto>>(result);
        }
        public async Task<Result<HotelDto>> EditHotelServiceAsync(HotelDto item)
        {
            var hotel = mapper.Map<Hotel>(item);

            var result = await unitOfWork.Hotels.EditAsync(hotel);
            var saveResult = unitOfWork.Save();

            if (!saveResult.IsCompleteSuccessfully)
                return new Result<HotelDto>()
                {
                    IsCompleteSuccessfully = saveResult.IsCompleteSuccessfully,
                    ErrorMessages = saveResult.ErrorMessages
                };

            return mapper.Map<Result<HotelDto>>(result);
        }
        public async Task<Result<HotelDto>> RemoveHotelServiceAsync(int id)
        {
            var result = await unitOfWork.Hotels.DeleteAsync(id);

            return mapper.Map<Result<HotelDto>>(result);
        }
    }


}
