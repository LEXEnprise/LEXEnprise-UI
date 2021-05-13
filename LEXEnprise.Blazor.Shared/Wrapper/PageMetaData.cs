using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Shared.Wrapper
{
    public class PageMetaData
    {
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; } = 10;

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages; 
    }
}
