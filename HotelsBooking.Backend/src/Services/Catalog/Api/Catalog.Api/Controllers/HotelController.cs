using Catalog.Application.Common.Contracts;
using Catalog.Domain.Models.Request;
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

        [HttpPost("createhotel")]
        public IActionResult CreateHotel([FromBody] HotelCreateRequest request)
        {
            var result = _hotelRepository.CreateHotel(request);
            return Ok(result);
        }

        [HttpGet("getallhotels")]
        public IActionResult GetAllHotelsAsync()
        {
            var result = _hotelRepository.GetAllHotelsAsync();
            return Ok(result);
        }

        [HttpDelete("deletehotel")]
        public IActionResult DeleteHotel([FromBody] HotelDeleteRequest request)
        {
            var result = _hotelRepository.DeleteHotel(request);
            return Ok(result);
        }
    }
}
