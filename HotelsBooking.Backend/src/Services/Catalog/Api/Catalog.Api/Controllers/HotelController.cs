using Catalog.Application.Common.Contracts;
using Catalog.Domain.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("createhotel")]
        public IActionResult CreateHotel([FromBody] HotelCreateRequest request)
        {
            var result = _hotelRepository.CreateHotel(request);
            return Ok(result);
        }

        [HttpGet("getallhotels")]
        public IActionResult GetAllHotels()
        {
            var result = _hotelRepository.GetHotels();
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletehotel")]
        public IActionResult DeleteHotel([FromBody] HotelDeleteRequest request)
        {
            var result = _hotelRepository.DeleteHotel(request);
            return Ok(result);
        }
    }
}
