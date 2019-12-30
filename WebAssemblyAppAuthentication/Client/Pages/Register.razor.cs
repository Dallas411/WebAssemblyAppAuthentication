using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssemblyAppAuthentication.Client.Services;
using WebAssemblyAppAuthentication.Shared;

namespace WebAssemblyAppAuthentication.Client.Pages
{
    public partial class Register : ComponentBase
    {

        [Inject]
        protected IAuthService AuthService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        private RegisterModel RegisterModel = new RegisterModel();
        private bool ShowErrors;
        private IEnumerable<string> Errors;

        private async Task HandleRegistration()
        {
            ShowErrors = false;

            var result = await AuthService.Register(RegisterModel);

            if (result.Successful)
            {
                NavigationManager.NavigateTo("/login");
            }
            else
            {
                Errors = result.Errors;
                ShowErrors = true;
            }
        }
    }
}
