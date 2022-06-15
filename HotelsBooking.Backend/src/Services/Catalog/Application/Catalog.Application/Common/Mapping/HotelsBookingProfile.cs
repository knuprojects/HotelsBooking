using AutoMapper;
using Catalog.Application.Common.Pagination.Filter;
using Catalog.Application.Common.Pagination.Queries;
using Catalog.Domain.Entities;
using Catalog.Domain.Models.Request;
using Catalog.Domain.Models.Response;

namespace Catalog.Application.Common.Mapping
{
    public class HotelsBookingProfile : Profile
    {
        public HotelsBookingProfile()
        {
            CreateMap<HotelCreateRequest, Hotel>().ReverseMap();
            CreateMap<Hotel, HotelCreateResponse>().ReverseMap();
            CreateMap<HotelDeleteRequest, Hotel>().ReverseMap();
            CreateMap<Hotel, HotelDeleteResponse>().ReverseMap();

            CreateMap<RoomCreateRequest, Room>().ReverseMap();
            CreateMap<Room, RoomCreateResponse>().ReverseMap();
            CreateMap<RoomDeleteRequest, Room>().ReverseMap();
            CreateMap<Room, RoomCreateResponse>().ReverseMap();

            CreateMap<PaginationQuery, PaginationFilter>().ReverseMap();
        }
    }
}
