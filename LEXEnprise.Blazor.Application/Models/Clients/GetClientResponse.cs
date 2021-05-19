using LEXEnprise.Blazor.Application.Models.Lookup;

namespace LEXEnprise.Blazor.Application.Models.Clients
{
    public class GetClientResponse : BaseModel
    {
        public string ClientNumber { get; set; }
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public ClientType ClientType { get; set; }
        public Industry Industry { get; set; }
        public ClientStatus Status { get; set; }
        public Contact AccountManager { get; set; }

    }
}
