using LEXEnprise.Shared.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LEXEnprise.Blazor.Application.Models.Lookup
{
    public class City : BaseModel
    {
        public string CityName { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
}
