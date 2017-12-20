using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using vega.api.Core.Models;

namespace vega.api.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObject, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (string.IsNullOrWhiteSpace(queryObject.SortBy) || !columnsMap.ContainsKey(queryObject.SortBy))
                return query;

            if (queryObject.IsSortAscending)
            {
                return query = query.OrderBy(columnsMap[queryObject.SortBy]);
            }
            else
            {
                return query = query.OrderByDescending(columnsMap[queryObject.SortBy]);
            }
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0)
            {
                queryObj.Page = 1;
            }
            if (queryObj.PageSize <= 0)
            {
                queryObj.PageSize = 10;
            }

            return query = query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }
    }
}
