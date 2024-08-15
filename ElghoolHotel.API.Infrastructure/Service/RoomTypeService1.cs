using AutoMapper;
using ElghoolHotel.API.Core.Contract.Repository.UnitOfWork;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;
using ElghoolHotel.API.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;

namespace ElghoolHotel.API.Core.Service
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public RoomTypeService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public async Task<Result<List<RoomTypeDto>>> GetAllRoomTypeServiceAsync()
        {
            return mapper.Map<Result<List<RoomTypeDto>>>(await unitOfWork.RoomTypes.GetAllAsync());
        }
        public async Task<Result<RoomTypeDto>> AddRoomTypeServiceAsync(RoomTypeDto item)
        {
            var roomType = mapper.Map<RoomType>(item);
            
            var result = await unitOfWork.RoomTypes.InsertAsync(roomType);
            var saveResult = unitOfWork.Save();

            if (!saveResult.IsCompleteSuccessfully)
                return new Result<RoomTypeDto>() { 
                IsCompleteSuccessfully = saveResult.IsCompleteSuccessfully,
                ErrorMessages = saveResult.ErrorMessages
                };

            return mapper.Map<Result<RoomTypeDto>>(result);
        }
        public async Task<Result<RoomTypeDto>> EditRoomTypeServiceAsync(RoomTypeDto item)
        {
            var roomType = mapper.Map<RoomType>(item);

            var result = await unitOfWork.RoomTypes.EditAsync(roomType);
            var saveResult = unitOfWork.Save();

            if (!saveResult.IsCompleteSuccessfully)
                return new Result<RoomTypeDto>()
                {
                    IsCompleteSuccessfully = saveResult.IsCompleteSuccessfully,
                    ErrorMessages = saveResult.ErrorMessages
                };

            return mapper.Map<Result<RoomTypeDto>>(result);
        }
        public async Task<Result<RoomTypeDto>> RemoveRoomTypeServiceAsync(int id)
        {
            var result = await unitOfWork.RoomTypes.DeleteAsync(id);

            return mapper.Map<Result<RoomTypeDto>>(result);
        }
    }


}
