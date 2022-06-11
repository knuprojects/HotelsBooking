using Catalog.Application.Common.Contracts;
using Catalog.Application.Common.Pagination.Queries;
using Microsoft.AspNetCore.WebUtilities;
using System;

namespace Catalog.Application.Common.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetAllHotelsUri(PaginationQuery paginationQuery = null)
        {
            var uri = new Uri(_baseUri);

            if (paginationQuery == null)
            {
                return uri;
            }

            var modifiedUri = QueryHelpers.AddQueryString(_baseUri, "pageNumber", paginationQuery.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(_baseUri, "pageSize", paginationQuery.PageSize.ToString());

            return new Uri(modifiedUri);
        }
    }
}
