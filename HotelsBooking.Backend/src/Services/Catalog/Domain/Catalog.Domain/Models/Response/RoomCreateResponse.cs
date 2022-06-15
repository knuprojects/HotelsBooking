using System;
using System.Net;

namespace Catalog.Domain.Models.Response
{
    public sealed class RoomCreateResponse
    {
        public int Id { get; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
