﻿using AdService.Application.Common.Models;


namespace AdService.Application.Common.Extensions;

public static class IQueryableExtensions
{
    public static async Task<PaginatedList<T>> PaginatedListAsync<T>(
        this IQueryable<T> queryable,
        int pageNumber,
        int pageSize)
        => await PaginatedList<T>.CreateAsync(queryable, pageNumber, pageSize);
}
