using ElghoolHotel.API.Core.Contract.Repository.UnitOfWork;
using ElghoolHotel.API.Core.Contract.Service;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Helpers;
using ElghoolHotel.API.Core.Models;
using ElghoolHotel.API.Infrastructure.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace ElghoolHotel.API.Controllers
{

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public BookingsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<Result<bool>>> Create(BookingDto bookingDto)
        {
            //unitOfWork.Bags.EditAsync(bag);
            //bookingDto.
            //if (ModelState.IsValid)
            //{
            //    unitOfWork.Bags.EditAsync(bag);
            //    unitOfWork.Save();
            //}

            return Ok();

        }

    }


}
