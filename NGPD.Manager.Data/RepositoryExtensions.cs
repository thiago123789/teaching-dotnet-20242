using Microsoft.EntityFrameworkCore;
using NGPD.Manager.Entities.Pagination;

namespace NGPD.Manager.Data;

public static class RepositoryExtensions
{
    public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> query, PaginationFilter filter)
    {
        var list = await query.Skip((filter?.PageSize ?? 0) * (filter?.PageNumber ?? 0)).Take(filter?.PageSize ?? 10).ToListAsync();

        return new PagedResult<T>()
        {
            PageSize = filter?.PageSize ?? 10,
            TotalCount = query.Count(),
            PageCount = list.Count(),
            CurrentPage = filter?.PageNumber ?? 0,
            List = list
        };
    }

    public static PagedResult<T> Paginate<T>(this IQueryable<T> query, PaginationFilter filter)
    {
        var list = query.Skip((filter?.PageSize ?? 0) * (filter?.PageNumber ?? 0)).Take(filter?.PageSize ?? 10).ToList();

        return new PagedResult<T>()
        {
            PageSize = filter?.PageSize ?? 10,
            TotalCount = query.Count(),
            PageCount = list.Count(),
            CurrentPage = filter?.PageNumber ?? 0,
            List = list
        };
    }
}