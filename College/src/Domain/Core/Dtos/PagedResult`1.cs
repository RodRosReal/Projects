using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Domain.Core
{
    public sealed class PagedResult<TData> : IDto
    {
        [JsonConstructor]
        public PagedResult(int pageNumber, int pageSize, long totalCount, IList<TData> dataList)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;

            this.DataList = dataList ?? throw new ArgumentNullException(nameof(dataList));
        }

        public PagedResult(int pageNumber, int pageSize, IList<TData> dataList)
            : this(pageNumber, pageSize, -1, dataList)
        {
        }

        public int PageNumber { get; }

        public int PageSize { get; }

        public long TotalCount { get; }

        public IList<TData> DataList { get; }
    }
}
