using CommunityToolkit.Mvvm.ComponentModel;

namespace Core.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string windowTitle = "Zenith Editor";
}

