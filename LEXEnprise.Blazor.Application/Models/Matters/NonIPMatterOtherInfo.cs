using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Models.Matters
{
    public class NonIPMatterOtherInfo
    {
        public int MatterId { get; set; }
        public int OpposingLawyerId { get; set; }
        public int LawFirmAppearancePositionId { get; set; }
        public int OppCounselAppearancePositionId { get; set; }
        public int FillingEntityId { get; set; }
    }
}
