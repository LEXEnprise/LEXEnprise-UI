using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Application.Models.Lookup.Matters
{
    public class GetLawyerResponse : BaseModel
    {
        public string Fullname { get; set; }
        public int CaseGroupId { get; set; }
        public string EmailAddress { get; set; }
        public string Position { get; set; }
        public DateTime? DateHired { get; set; }
        public string LawSchool { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string OtherContactNos { get; set; }

        public CaseGroup CaseGroup { get; set; }
    }
}
