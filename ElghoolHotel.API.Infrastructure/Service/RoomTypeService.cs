

//using AutoMapper;
//using ElghoolHotel.API.Core.Contract.Repository.UnitOfWork;
//using ElghoolHotel.API.Core.DTO;
//using ElghoolHotel.API.Core.Helpers;
//using ElghoolHotel.API.Core.Models;
//using Microsoft.Extensions.Configuration;

//namespace ElghoolHotel.API.Core.Service
//{
//    public class RoomTypeService : IRoomTypeService
//    {
//        private readonly IUnitOfWork unitOfWork;
//        private readonly IConfiguration configuration;
//        private readonly IMapper mapper;

//        public RoomTypeService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
//        {
//            this.unitOfWork = unitOfWork;
//            this.configuration = configuration;
//            this.mapper = mapper;
//        }

//        public async Task<Result<RoomTypeDto>> AddRoomTypeServiceAsync(RoomTypeDto item)
//        {

//        }

//        public Task<Result<RoomTypeDto>> EditRoomTypeServiceAsync(RoomTypeDto item)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<Result<List<RoomTypeDto>>> GetAllRoomTypeServiceAsync()
//        {
//            var result = await unitOfWork.RoomTypes.GetAllAsync();

//            if (!result.IsCompleteSuccessfully)
//                return new Result<CategoryResponseDto>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.IncorrectInput };

//            var roomTypes = mapper.Map<RoomTypeDto>(item);
//            return result;
//        }

//        public Task<Result<RoomTypeDto>> RemoveRoomTypeServiceAsync(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
