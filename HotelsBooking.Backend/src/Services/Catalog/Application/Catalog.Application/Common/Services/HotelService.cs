using AutoMapper;
using Catalog.Application.Common.Contracts;
using Catalog.Application.Common.Pagination.Filter;
using Catalog.DAL.Common.Contracts;
using Catalog.Domain.Entities;
using Catalog.Domain.Models.Request;
using Catalog.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Application.Common.Services
{
    public class HotelService : IHotelRepository
    {
        private readonly IEfRepository<Hotel> _efService;
        private readonly IMapper _mapper;
        public HotelService(IEfRepository<Hotel> efService, IMapper mapper)
        {
            _efService = efService;
            _mapper = mapper;
        }
        public Task<HotelCreateResponse> CreateHotel(HotelCreateRequest request)
        {

            var hotel = new Hotel
            {
                Name = request.Name,
                Description = request.Description,
                City = request.City,
                PhotoUrl = request.PhotoUrl
            };

            _efService.Add(hotel);
            var response = _mapper.Map<HotelCreateResponse>(hotel);
            return Task.FromResult(response);
        }

        public Task<HotelDeleteResponse> DeleteHotel(HotelDeleteRequest request)
        {
            var response = _mapper.Map<Hotel>(request);
            _efService.Remove(response);
            var result = _mapper.Map<HotelDeleteResponse>(response);
            return Task.FromResult(result);
        }

        public List<Hotel> GetHotels(PaginationFilter paginationFilter = null)
        {
            if (paginationFilter == null)
            {
                return _efService.GetAll();
            }
            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

            return _efService.GetAll().Skip(skip).ToList();
        }

        public List<Hotel> GetHotelsByCity(string city)
        {
            return _efService.GetAll().FindAll(h => h.City == city);
        }
    }
}
