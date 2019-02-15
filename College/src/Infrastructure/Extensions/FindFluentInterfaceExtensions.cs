using Domain.Core;
using DynamicExpresso;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MongoDB.Driver
{
    public static class FindFluentInterfaceExtensions
    {
        public static Task<PagedResult<TProjection>> ToPagedAsync<TDocument, TProjection>(this IFindFluent<TDocument, TProjection> collection, int pageNumber, int pageSize, bool includeTotalCount = false, CancellationToken cancellationToken = default)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber));

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize));

            return Task.Run(
                async () =>
                {
                    Task<long> countTask = null;

                    if (includeTotalCount)
                        countTask = collection.CountDocumentsAsync();

                    if (pageNumber > 1)
                        collection = collection.Skip((pageNumber - 1) * pageSize);

                    collection = collection.Limit(pageSize);

                    var toListTask = collection.ToListAsync();

                    long totalCount = countTask != null ? await countTask : -1;

                    var dataList = await toListTask;

                    return new PagedResult<TProjection>(pageNumber, pageSize, totalCount, dataList);
                },
                cancellationToken);
        }

        public static IFindFluent<TDocument, TProjection> SortBy<TDocument, TProjection>(this IFindFluent<TDocument, TProjection> collection, string fieldName, SortDirection direction)
        {
            var sortExpression = GetSortExpression<TDocument>(fieldName);

            collection = direction == SortDirection.Ascending
                ? collection.SortBy(sortExpression)
                : collection.SortByDescending(sortExpression);

            return collection;
        }

        public static IOrderedFindFluent<TDocument, TProjection> ThenBy<TDocument, TProjection>(this IOrderedFindFluent<TDocument, TProjection> collection, string fieldName, SortDirection direction)
        {
            var sortExpression = GetSortExpression<TDocument>(fieldName);

            collection = direction == SortDirection.Ascending
                ? collection.ThenBy(sortExpression)
                : collection.ThenByDescending(sortExpression);

            return collection;
        }

        private static Expression<Func<TDocument, object>> GetSortExpression<TDocument>(string fieldName)
        {
            return new Interpreter()
                .ParseAsExpression<Func<TDocument, object>>($"document.{fieldName}", "document");
        }
    }
}
