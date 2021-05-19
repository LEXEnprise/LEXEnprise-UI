namespace LEXEnprise.Blazor.Clients.Pages
{
    public partial class AddClient
    {
        public string PageTitle { get; set; } = "Add Client";

        private AddClientRequest addClientModel;

        protected override void OnInitialized()
        {
            addClientModel = new AddClientRequest();
        }

        private async void OnValidSubmit()
        {

        }

        private async void OnClear()
        {

        }
    }
}
