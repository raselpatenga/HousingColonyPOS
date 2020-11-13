using Common.DTOs;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace System.Linq
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> PageBy<T>([NotNull] this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            if (query == null)
            {
                throw new ArgumentException($"{query} can not be null!", nameof(query));
            }

            return query.Skip(skipCount).Take(maxResultCount);
        }

        public static TQueryable PageBy<T, TQueryable>([NotNull] this TQueryable query, int skipCount, int maxResultCount)
            where TQueryable : IQueryable<T>
        {
            if (query == null)
            {
                throw new ArgumentException($"{query} can not be null!", nameof(query));
            }

            return (TQueryable) query.Skip(skipCount).Take(maxResultCount);
        }
        public static IQueryable<T> PageBy<T>([NotNull] this IQueryable<T> query, PagedRequestDTO pagedRequest)
        {
            if (query == null || pagedRequest == null)
            {
                throw new ArgumentException($"{query} can not be null!", nameof(query));
            }

            if(!string.IsNullOrEmpty(pagedRequest.SortColumn))
            {
                var sortColumn = pagedRequest.SortColumn;

                if (!pagedRequest.IsAscending)
                    sortColumn += " desc";

                query = query.OrderBy(sortColumn);
            }

            if (pagedRequest.PageNo == 0)
                return query;

            int pageSize = pagedRequest.PageSize == 0 ? 10 : pagedRequest.PageSize;
            int pageNo = pagedRequest.PageNo - 1;

            return query.PageBy(pageNo * pageSize, pageSize);
        }


        public static IQueryable<T> WhereIf<T>([NotNull] this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            if (query == null)
            {
                throw new ArgumentException($"{query} can not be null!", nameof(query));
            }

            return condition
                ? query.Where(predicate)
                : query;
        }

        public static TQueryable WhereIf<T, TQueryable>([NotNull] this TQueryable query, bool condition, Expression<Func<T, bool>> predicate)
            where TQueryable : IQueryable<T>
        {
            if (query == null)
            {
                throw new ArgumentException($"{query} can not be null!", nameof(query));
            }

            return condition
                ? (TQueryable) query.Where(predicate)
                : query;
        }

        public static IQueryable<T> WhereIf<T>([NotNull] this IQueryable<T> query, bool condition, Expression<Func<T, int, bool>> predicate)
        {
            if (query == null)
            {
                throw new ArgumentException($"{query} can not be null!", nameof(query));
            }

            return condition
                ? query.Where(predicate)
                : query;
        }
       
        public static TQueryable WhereIf<T, TQueryable>([NotNull] this TQueryable query, bool condition, Expression<Func<T, int, bool>> predicate)
            where TQueryable : IQueryable<T>
        {
            if (query == null)
            {
                throw new ArgumentException($"{query} can not be null!", nameof(query));
            }

            return condition
                ? (TQueryable) query.Where(predicate)
                : query;
        }
    }
}
