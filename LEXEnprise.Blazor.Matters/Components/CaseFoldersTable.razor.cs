using LEXEnprise.Blazor.Application.Models.CaseFolders;
using LEXEnprise.Blazor.Application.Models.Clients;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Matters.Components
{
    public partial class CaseFoldersTable
    {
        [Parameter]
        public List<GetCaseFolderResponse> CaseFolders { get; set; }

        [Parameter]
        public EventCallback<int> OnDeleted { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime Js { get; set; }

        //we use the Js property and the InvokeAsync method to call the confirm JavaScript function and 
        //pass a parameter to that function.If a user confirms the delete action, we invoke our event callback parameter 
        //and execute the method from the parent component.
        private async Task Delete(int id)
        {
            var caseFolder = CaseFolders.FirstOrDefault(p => p.Id.Equals(id));

            //Js is IJSRuntime from Microsoft.JSInterop, Js.InvokeAsync to call a javascript "confirm" function.
            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {caseFolder.CaseFolderCode} client?");
            if (confirmed)
            {
                await OnDeleted.InvokeAsync(id);
            }
        }
    }
}
