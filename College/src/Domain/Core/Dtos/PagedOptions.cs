using Domain.ValueObjects;
using System;

namespace Domain.Core
{
    public class PagedOptions : IDto
    {
        public PagedOptions()
            : this(1)
        {
        }

        public PagedOptions(int pageNumber)
            : this(pageNumber, RepositoryConstants.DefaultQueryPageSize)
        {
        }

        public PagedOptions(int pageNumber, int pageSize)
            : this(pageNumber, pageSize, null, SortDirection.Ascending, false)
        {
        }

        public PagedOptions(int pageNumber, int pageSize, bool includeTotalCount)
            : this(pageNumber, pageSize, null, SortDirection.Ascending, includeTotalCount)
        {
        }

        public PagedOptions(int pageNumber, int pageSize, string orderBy, SortDirection direction)
            : this(pageNumber, pageSize, orderBy, direction, false)
        {
        }

        public PagedOptions(int pageNumber, int pageSize, string orderBy, SortDirection direction, bool includeTotalCount)
        {
            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageNumber));

            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize));

            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.OrderBy = orderBy;
            this.Direction = direction;
            this.IncludeTotalCount = includeTotalCount;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string OrderBy { get; set; }

        public SortDirection Direction { get; set; }

        public bool IncludeTotalCount { get; set; }
    }
}
