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
    public class RoomService : IRoomRepository
    {
        private readonly IEfRepository<Room> _efService;
        private readonly IMapper _mapper;
        public RoomService(IEfRepository<Room> efService, IMapper mapper)
        {
            _efService = efService;
            _mapper = mapper;
        }
        public Task<RoomCreateResponse> CreateRoom(RoomCreateRequest request)
        {

            var room = new Room
            {
                Id = 1,
                Number = request.Number,
                Floor = request.Floor,
                RoomType = request.RoomType,
                Price = request.Price,
                HotelId = request.HotelId
            };

            _efService.Add(room);
            var response = _mapper.Map<RoomCreateResponse>(room);
            return Task.FromResult(response);
        }

        public Task<RoomDeleteResponse> DeleteRoom(RoomDeleteRequest request)
        {
            var response = _mapper.Map<Room>(request);
            _efService.Remove(response);
            var result = _mapper.Map<RoomDeleteResponse>(response);
            return Task.FromResult(result);
        }

        public List<Room> GetAllRooms()
        {
            return _efService.GetAll();
        }

        public List<Room> GetRoomByHotelId(int hotelId)
        {
            return _efService.GetAll().FindAll(h => h.HotelId == hotelId);
        }
    }
}
