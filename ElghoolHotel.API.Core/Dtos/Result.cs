using System.Numerics;
using ElghoolHotel.API.Core.Helpers;

namespace ElghoolHotel.API.Core.DTO
{
    public class Result<T>
    {
        public bool IsCompleteSuccessfully { get; set; }
        public T Data { get; set; }
        public Error ErrorMessages { get; set; }
    }
}
