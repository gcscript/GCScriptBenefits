using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace GCScript.Client.Windows.Avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _textBlockName = "Welcome to GCS!";

    [ObservableProperty]
    private UserControl _currentUserControl = new uc_PurchaseGenerator();

    [RelayCommand]
    private async void ButtonOnClick()
    {
        TextBlockName = "CLICKED";

        await Task.Delay(5000);
        TextBlockName = "5 Segundos";
    }

    [RelayCommand]
    private async void OpenUserControl(string name)
    {
        switch (name)
        {
            case "PurchaseGenerator":
                CurrentUserControl = new uc_PurchaseGenerator();
                break;
            case "Register":
                CurrentUserControl = new uc_Register();
                break;
            default:
                break;
        }
    }
}