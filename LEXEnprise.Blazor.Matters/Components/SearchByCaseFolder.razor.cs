using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Matters.Components
{
    public partial class SearchByCaseFolder
    {
        public string SearchCaseFolderTerm { get; set; }

        [Parameter]
        public EventCallback<string> OnSearchSubmit { get; set; }

        [Parameter]
        public EventCallback<string> OnShowFilter { get; set; }

        private void SubmitCaseFolderSearch(object sender)
        {
            OnSearchSubmit.InvokeAsync(SearchCaseFolderTerm);
        }

        private void ShowCaseFolderFilterForm(object sender)
        {
            OnShowFilter.InvokeAsync();
        }
    }
}
