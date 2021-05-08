using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Shared.Wrapper
{
    public class PaginatedResult<T> : Result
    {
        public PageMetaData PageMetaData { get; set; }

        public PaginatedResult(List<T> data)
        {
            Data = data;
        }

        public List<T> Data { get; set; }

        internal PaginatedResult(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10)
        {
            Data = data;
            Succeeded = succeeded;
            Messages = messages;

            PageMetaData = new PageMetaData
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                TotalCount = count,
            };
        }

        public static PaginatedResult<T> Failure(List<string> messages)
        {
            return new PaginatedResult<T>(false, default, messages);
        }

        public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new PaginatedResult<T>(true, data, null, count, page, pageSize);
        }

        public bool HasPreviousPage => PageMetaData.CurrentPage > 1;

        public bool HasNextPage => PageMetaData.CurrentPage < PageMetaData.TotalPages;
    }
}
