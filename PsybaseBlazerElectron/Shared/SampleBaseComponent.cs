using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace PsybaseBlazerElectron.Shared
{
    public class SampleBaseComponent : ComponentBase
    {
        [Inject]
#pragma warning disable IDE1006 // Naming Styles
        protected IJSRuntime jsRuntime { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        [Inject]
        protected SampleService Service { get; set; }

       
        protected override void OnAfterRender(bool FirstRender)
        {
            Service.Update(new NotifyProperties() { HideSpinner = true, RestricMouseEvents = true });
        }
    }
}
