using Catalog.Application.Common.Pagination.Queries;
using System;

namespace Catalog.Application.Common.Contracts
{
    public interface IUriService
    {
        Uri GetAllHotelsUri(PaginationQuery paginationQuery = null);
    }
}
