using LEXEnprise.Blazor.Application.Models.Lookup.Matters;
using LEXEnprise.Blazor.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Models.Matters
{
    public class MatterHandlingLawyer
    {
        public int MatterId { get; set; }
        public int LawyerId { get; set; }
        public bool IsMainLawyer { get; set; } = false;
        public short Action { get; set; } = DataActions.None;

        public Matter Matter { get; set; }
        public Lawyer HandlingLawyer { get; set; }
    }
}
