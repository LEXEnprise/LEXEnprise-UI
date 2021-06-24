using LEXEnprise.Blazor.Application.Models.Lookup;

namespace LEXEnprise.Blazor.Application.Models.CaseFolders
{
    public class GetCaseFolderResponse : BaseModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string CaseFolderCode { get; set; }
        public string CaseFolderDesc { get; set; }
        public string Status { get; set; }
        public string GroupCode { get; set; }
        public int SupervisingLawyerId { get; set; }
        public LawyerModel SupervisingLawyer { get; set; }
        public int CaseOwnerId { get; set; }
        public LawyerModel CaseOwner { get; set; }
        public string CreatedByName { get; set; }
    }
}
