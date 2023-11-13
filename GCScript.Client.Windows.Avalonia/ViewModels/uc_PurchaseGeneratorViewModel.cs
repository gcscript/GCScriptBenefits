using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCScript.Client.Windows.Avalonia.ViewModels
{
    public partial class uc_PurchaseGeneratorViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _textBlockName = "Welcome to GCS!";
    }
}
