using Catalog.DAL.Common.Contracts;
using Catalog.Domain.Entities;
using Catalog.Domain.Models.Request;
using Catalog.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Application.Common.Contracts
{
    public interface IRoomRepository 
    {
        Task<RoomCreateResponse> CreateRoom(RoomCreateRequest request);
        List<Room> GetAllRooms();
        Task<RoomDeleteResponse> DeleteRoom(RoomDeleteRequest request);
        List<Room> GetRoomByHotelId(int hotelId);
    }
}
