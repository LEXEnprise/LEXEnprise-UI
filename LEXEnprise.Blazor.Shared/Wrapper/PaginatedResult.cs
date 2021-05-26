using LEXEnprise.Blazor.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LEXEnprise.Shared.Models.Paging
{
    public class PaginatedResult<T> : Result
    {
        public PageMetaData PageMetaData { get; set; }

        public PaginatedResult(List<T> data)
        {
            Data = data;
        }

        public List<T> Data { get; set; }

        internal PaginatedResult(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10, int totalCount = 0)
        {
            Data = data;
            Succeeded = succeeded;
            Messages = messages;

            PageMetaData = new PageMetaData
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                TotalCount = totalCount,
            };
        }

        public static PaginatedResult<T> Failure(List<string> messages)
        {
            return new PaginatedResult<T>(false, default, messages);
        }

        public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize, int totalCount)
        {
            return new PaginatedResult<T>(true, data, null, count, page, pageSize, totalCount);
        }



        public bool HasPreviousPage => PageMetaData.PageNumber > 1;

        public bool HasNextPage => PageMetaData.PageNumber < PageMetaData.TotalPages;
    }
}
