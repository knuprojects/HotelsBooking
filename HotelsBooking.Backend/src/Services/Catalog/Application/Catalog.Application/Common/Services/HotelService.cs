using AutoMapper;
using Catalog.Application.Common.Contracts;
using Catalog.DAL.Common.Contracts;
using Catalog.Domain.Entities;
using Catalog.Domain.Models.Request;
using Catalog.Domain.Models.Response;
using System;
using System.Collections.Generic;
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
            var gid = Guid.NewGuid();

            var hotel = new Hotel
            {
                GID = gid,
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

        public IEnumerable<Hotel> GetHotels()
        {
            return _efService.GetAll();
        }
    }
}
