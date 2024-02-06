using GCScript.Shared;
using Microsoft.AspNetCore.Components;

namespace GCScript.Client.Windows.Blazor.Pages;

public partial class Index
{

    //protected override void OnAfterRender(bool firstRender)
    //{
    //    if (!Settings.Logado)
    //    {
    //        NavigationManager.NavigateTo("/login");
    //    }
    //}

    protected override async Task OnInitializedAsync()
    {
        if (!Settings.Logado)
        {
            NavigationManager.NavigateTo("/login");
        }
    }
}
