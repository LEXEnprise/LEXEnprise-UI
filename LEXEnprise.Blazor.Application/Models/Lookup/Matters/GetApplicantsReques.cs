using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Models.Lookup.Matters
{
    public class GetApplicantsRequest : PagedRequest
    {
        public string SearchString { get; set; }
        public string SortString { get; set; } = "ApplicantName";
    }
}
