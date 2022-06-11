using AutoMapper;
using Catalog.Application.Common.Contracts;
using Catalog.Application.Common.Pagination.Filter;
using Catalog.Application.Common.Pagination.Helpers;
using Catalog.Application.Common.Pagination.Queries;
using Catalog.Application.Common.Pagination.Responses;
using Catalog.Domain.Entities;
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
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public HotelController(IHotelRepository hotelRepository, IMapper mapper, IUriService uriService)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
            _uriService = uriService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("createhotel")]
        public IActionResult CreateHotel([FromBody] HotelCreateRequest request)
        {
            var result = _hotelRepository.CreateHotel(request);
            return Ok(result);
        }

        [HttpGet("getallhotels")]
        public IActionResult GetAllHotels([FromQuery] PaginationQuery paginationQuery)
        {
            var paginationFilter = _mapper.Map<PaginationFilter>(paginationQuery);

            var result = _hotelRepository.GetHotels(paginationFilter);

            if(paginationFilter == null || paginationFilter.PageNumber < 1 || paginationFilter.PageSize < 1)
            {
                return Ok(new PagedResponse<Hotel>(result));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, paginationFilter, result);
            return Ok(paginationResponse);
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
