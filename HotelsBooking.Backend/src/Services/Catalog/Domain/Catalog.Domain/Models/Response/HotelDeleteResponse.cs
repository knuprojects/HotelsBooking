using System;
using System.Net;

namespace Catalog.Domain.Models.Response
{
    public sealed class HotelDeleteResponse
    {
        public Guid GID { get; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
