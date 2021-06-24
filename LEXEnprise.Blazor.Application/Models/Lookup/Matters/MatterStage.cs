namespace LEXEnprise.Blazor.Application.Models.Lookup.Matters
{
    public class MatterStage : BaseModel
    {
        public int CaseTypeId { get; set; }
        public int StageId { get; set; }
        public string StageDesciption { get; set; }

        public CaseType CaseType { get; set; }
    }
}
