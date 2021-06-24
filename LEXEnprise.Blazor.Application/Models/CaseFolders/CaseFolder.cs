using LEXEnprise.Blazor.Application.Models.Lookup.Matters;
using LEXEnprise.Blazor.Application.Models.Matters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Models.CaseFolders
{
    public class CaseFolder : BaseModel
    {
        public int ClientId { get; set; }
        public string ClientNumber { get; set; }
        public string ClientName { get; set; }
        public string CaseFolderCode { get; set; }
        public string CaseFolderDesc { get; set; }
        public string Status { get; set; }
        public int CaseGroupId { get; set; }
        public string GroupCode { get; set; }
        public int SupervisingLawyerId { get; set; }
        public Lawyer SupervisingLawyer { get; set; }
        public int CaseOwnerId { get; set; }
        public Lawyer CaseOwner { get; set; }

        public List<Matter> Matters { get; set; } = new List<Matter>();
    }
}
