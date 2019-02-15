using Domain.Core;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Entity
{
    public static class EntityFrameworkQueryableInterfaceExtensions
    {
        public static Task<PagedResult<TEntity>> ToPaged<TEntity>(this IQueryable<TEntity> source, int pageNumber, int pageSize, bool includeTotalCount = false, CancellationToken cancellationToken = default)
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
                        countTask = source.LongCountAsync();

                    var query = source;

                    if (pageNumber > 1)
                        query = query.Skip((pageNumber - 1) * pageSize);

                    query = query.Take(pageSize);

                    long totalCount = countTask != null ? await countTask : -1;

                    var dataList = query.ToList();

                    return new PagedResult<TEntity>(pageNumber, pageSize, totalCount, dataList);
                },
                cancellationToken);
        }
    }
}
