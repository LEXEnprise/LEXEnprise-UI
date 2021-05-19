using LEXEnprise.Shared.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LEXEnprise.Blazor.Application.Models.Lookup
{
    public class Industry : BaseModel
    {
        public string IndustryName { get; set; }
        public string NatureOf { get; set; }
        public int IndustryCityId { get; set; }
        public int IndustryStateId { get; set; }
        public int IndustryCountryId { get; set; }

        [ForeignKey("IndustryCityId")]
        public virtual City IndustryCity { get; set; }
        [ForeignKey("IndustryStateId")]
        public virtual State IndustryState { get; set; }
        [ForeignKey("IndustryCountryId")]
        public virtual Country IndustryCountry { get; set; }
    }
}
