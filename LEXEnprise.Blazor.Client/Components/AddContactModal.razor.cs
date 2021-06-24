using Blazored.Modal;
using Blazored.Modal.Services;
using LEXEnprise.Blazor.Application.Models;
using LEXEnprise.Blazor.Shared.Validations;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Clients.Components
{
    public partial class AddContactModal
    {
        [CascadingParameter]
        public BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public string Title { get; set; }

        private Contact _contact { get; set; }

        [Parameter]
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        private bool _isMainAccountOfficer = false;

        private CommonCustomValidation _addContactValidation;
        protected override void OnInitialized()
        {
            _contact = new Contact();
        }

        private bool IsValidContact()
        {
            _addContactValidation.ClearErrors();
            var errors = new Dictionary<string, List<string>>();

            if ((_contact.IsMainAccountOfficer == true) &&
                (Contacts.Any(c => c.IsMainAccountOfficer == true)))
            {
                errors.Add(nameof(_contact),
                    new() { "There is an existing Main Account Officer already." });
            }

            if (errors.Count > 0)
            {
                _addContactValidation.DisplayErrors(errors);
                return false;
            }

            return true;
        }

        private async Task AddContact()
        {
            _contact.IsMainAccountOfficer = _isMainAccountOfficer;
            if (IsValidContact())
                await BlazoredModal.CloseAsync(ModalResult.Ok(_contact));
        }

        private async Task Cancel() => await BlazoredModal.CancelAsync();
    }
}
