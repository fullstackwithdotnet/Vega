using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Vega.Extentions {
    public static class IQueryableExtentions {
        public static IQueryable<T> ApplyOdering<T> (this IQueryable<T> query, IQueryObject queryObject, Dictionary<string, Expression<Func<T, object>>> columnsMap) {
            if (String.IsNullOrEmpty (queryObject.SortBy) || !columnsMap.ContainsKey (queryObject.SortBy)) {
                return query;
            }
            if (queryObject.IsSortAssending) {
                return query.OrderBy (columnsMap[queryObject.SortBy]);
            } else {
                return query.OrderByDescending (columnsMap[queryObject.SortBy]);
            }
        }

        public static IQueryable<T> ApplyPaging<T> (this IQueryable<T> query, IQueryObject queryObject) {
            if(queryObject.Page <= 0)
                queryObject.Page = 1;
            if (queryObject.PageSize <= 0)
                queryObject.PageSize = 5;
            return query.Skip ((queryObject.Page - 1) * queryObject.PageSize).Take (queryObject.PageSize);
        }

    }
}