using Catalog.Application.Common.Contracts;
using Catalog.Application.Common.Pagination.Filter;
using Catalog.Application.Common.Pagination.Queries;
using Catalog.Application.Common.Pagination.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Application.Common.Pagination.Helpers
{
    public class PaginationHelpers
    {
        public static object CreatePaginatedResponse<T>(IUriService uriService, PaginationFilter paginationFilter, List<T> hotels)
        {
            var nextPage = paginationFilter.PageNumber >= 1 ? uriService
                .GetAllHotelsUri(new PaginationQuery(paginationFilter.PageNumber + 1, paginationFilter.PageSize)).ToString() : null;

            var previousPage = paginationFilter.PageNumber - 1 >= 1 ? uriService
                .GetAllHotelsUri(new PaginationQuery(paginationFilter.PageNumber - 1, paginationFilter.PageSize)).ToString() : null;

            return new PagedResponse<T>
            {
                Data = hotels,
                PageNumber = (int)(paginationFilter.PageNumber >= 1 ? paginationFilter.PageNumber : (int?)null),
                PageSize = (int)(paginationFilter.PageSize >= 1 ? paginationFilter.PageSize : (int?)null),
                NextPage = hotels.Any() ? nextPage : null,
                PreviousPage = previousPage
            };
        }
    }
}
