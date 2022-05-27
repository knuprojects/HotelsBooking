using Catalog.Domain.Entities;
using Catalog.Domain.Models.Request;
using Catalog.Domain.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Application.Common.Contracts
{
    public interface IHotelRepository
    {
        Task<HotelCreateResponse> CreateHotel(HotelCreateRequest request);
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        Task<HotelDeleteResponse> DeleteHotel(HotelDeleteRequest request);
    }
}
