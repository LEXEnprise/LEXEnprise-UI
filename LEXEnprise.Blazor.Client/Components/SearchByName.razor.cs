using Microsoft.AspNetCore.Components;

namespace LEXEnprise.Blazor.Clients.Components
{
    public partial class SearchByName
    {
        public string SearchTerm { get; set; }

        [Parameter]
        public EventCallback<string> OnSearchSubmit { get; set; }

        [Parameter]
        public EventCallback<string> OnFilterSubmit { get; set; }

        private void SubmitSearch(object sender)
        {
            OnSearchSubmit.InvokeAsync(SearchTerm);
        }

        private void ShowFilterForm(object sender)
        {
            OnFilterSubmit.InvokeAsync();
        }
    }
}
