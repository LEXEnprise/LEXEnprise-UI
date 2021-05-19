using LEXEnprise.Shared.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LEXEnprise.Blazor.Application.Models.Lookup
{
    public class State : BaseModel
    {
        public State()
        {
            Cities = new List<City>();
        }

        public string StateCode { get; set; }
        public string StateName { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
