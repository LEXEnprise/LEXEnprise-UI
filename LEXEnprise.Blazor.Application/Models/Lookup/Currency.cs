using LEXEnprise.Shared.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace LEXEnprise.Blazor.Application.Models.Lookup
{
    public class Currency : BaseModel
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; } 
    }
}
