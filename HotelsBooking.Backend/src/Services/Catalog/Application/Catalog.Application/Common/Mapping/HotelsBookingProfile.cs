using AutoMapper;
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
        }
    }
}
