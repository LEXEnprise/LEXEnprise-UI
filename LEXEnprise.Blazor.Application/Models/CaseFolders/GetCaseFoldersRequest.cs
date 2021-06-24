using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Models.CaseFolders
{
    public class GetCaseFoldersRequest : PagedRequest
    {
        public string SearchString { get; set; }
        public string SortString { get; set; }
    }
}
