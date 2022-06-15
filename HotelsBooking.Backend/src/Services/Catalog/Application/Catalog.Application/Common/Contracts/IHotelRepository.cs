using Catalog.Application.Common.Pagination.Filter;
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
        List<Hotel> GetHotels(PaginationFilter paginationFilter = null);
        Task<HotelDeleteResponse> DeleteHotel(HotelDeleteRequest request);

        List<Hotel> GetHotelsByCity(string city);
    }
}
