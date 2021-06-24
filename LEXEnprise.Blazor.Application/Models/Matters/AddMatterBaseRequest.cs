namespace LEXEnprise.Blazor.Application.Models.Matters
{
    public abstract class AddMatterBaseRequest
    {
        public int CaseFolderId { get; set; }
        public string CaseFolderCode { get; set; }
        public Matter Matter { get; set; } = new Matter();
    }
}
