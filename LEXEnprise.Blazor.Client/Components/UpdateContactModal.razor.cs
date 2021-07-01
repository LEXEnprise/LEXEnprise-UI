using Blazored.Modal;
using Blazored.Modal.Services;
using LEXEnprise.Blazor.Application.Models;
using LEXEnprise.Blazor.Shared.Enums;
using LEXEnprise.Blazor.Shared.Validations;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Clients.Components
{
    public partial class UpdateContactModal
    {
        [CascadingParameter]
        public BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public Contact ContactInfo { get; set; }

        [Parameter]
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        private bool _isMainAccountOfficer = false;

        private CommonCustomValidation _updateContactValidation;
        protected override async Task OnParametersSetAsync()
        {
            _isMainAccountOfficer = ContactInfo.IsMainAccountOfficer ?? false;
        }

        private bool IsValidContact()
        {
            _updateContactValidation.ClearErrors();
            var errors = new Dictionary<string, List<string>>();

            if ((ContactInfo.IsMainAccountOfficer == true) &&
                (Contacts.Any(c => c.IsMainAccountOfficer == true && c.Id != ContactInfo.Id)))
            {
                errors.Add(nameof(ContactInfo),
                    new() { "There is an existing Main Account Officer already." });
            }

            if (errors.Count > 0)
            {
                _updateContactValidation.DisplayErrors(errors);
                return false;
            }

            return true;
        }

        private async Task SaveContact()
        {
            ContactInfo.IsMainAccountOfficer = _isMainAccountOfficer;
           

            if (IsValidContact())
                await BlazoredModal.CloseAsync(ModalResult.Ok(ContactInfo));
        }

        private async Task Cancel() => await BlazoredModal.CancelAsync();
    }
}
