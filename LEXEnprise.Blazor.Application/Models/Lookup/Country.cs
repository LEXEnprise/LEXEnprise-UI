using LEXEnprise.Shared.Models;

using System.Collections;
using System.Collections.Generic;

namespace LEXEnprise.Blazor.Application.Models.Lookup
{
    public class Country : BaseModel
    {
        public Country()
        {
            States = new List<State>();
        }

        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
