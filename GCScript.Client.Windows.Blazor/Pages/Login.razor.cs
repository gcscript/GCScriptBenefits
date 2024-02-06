using Microsoft.AspNetCore.Components;

namespace GCScript.Client.Windows.Blazor.Pages;

public partial class Login
{
    string username;
    string password;

    void btn_Login()
    {
        NavigationManager.NavigateTo("/data");
        // Implemente a lógica de autenticação aqui
        // Se a autenticação for bem-sucedida, redirecione para a página do painel
        //NavigationManager.NavigateTo("/dashboard");
    }
}
