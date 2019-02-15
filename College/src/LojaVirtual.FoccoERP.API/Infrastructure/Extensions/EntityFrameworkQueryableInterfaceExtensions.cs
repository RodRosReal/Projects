using Domain.Core;
using System.Linq;

namespace System.Data.Entity
{
    public static class EntityFrameworkQueryableInterfaceExtensions
    {
        public static PagedResult<TEntity> ToPaged<TEntity>(this IQueryable<TEntity> source, int pageNumber, int pageSize, bool includeTotalCount = false)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber));

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize));

            long? countTask = null;

            if (includeTotalCount)
                countTask = source.LongCount();

            var query = source;

            if (pageNumber > 1)
                query = query.Skip((pageNumber - 1) * pageSize);

            query = query.Take(pageSize);

            long totalCount = countTask.HasValue ? countTask.Value : -1;

            var dataList = query.ToList();

            return new PagedResult<TEntity>(pageNumber, pageSize, totalCount, dataList);
        }
    }
}
