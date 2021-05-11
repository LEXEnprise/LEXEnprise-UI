namespace LEXEnprise.Blazor.Application.Models.Clients
{
    public class GetClientResponse
    {
        public int Id { get; set; }
        public string ClientNumber { get; set; }
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public ClientStatus Status { get; set; }
        public Contact AccountManager { get; set; }

    }
}
