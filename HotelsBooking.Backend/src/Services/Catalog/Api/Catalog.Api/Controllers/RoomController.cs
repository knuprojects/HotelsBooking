using Catalog.Application.Common.Contracts;
using Catalog.Domain.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpPost("createroom")]
        public IActionResult CreateRoom([FromBody] RoomCreateRequest request)
        {
            var result = _roomRepository.CreateRoom(request);
            return Ok(result);
        }

        [HttpGet("getallrooms")]
        public IActionResult GetAllRoomsAsync()
        {
            var result = _roomRepository.GetAllRoomsAsync();
            return Ok(result);
        }

        [HttpDelete("deleteroom")]
        public IActionResult DeleteRoom(RoomDeleteRequest request)
        {
            var result = _roomRepository.DeleteRoom(request);
            return Ok(result);
        }
    }
}
