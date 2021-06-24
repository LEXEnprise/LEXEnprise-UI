namespace LEXEnprise.Blazor.Application.Models.Matters
{
    public class AddIPMatterRequest : AddMatterBaseRequest
    {
        public IPMatterOtherInfo OtherInfo { get; set; } = new IPMatterOtherInfo();
    }
}
