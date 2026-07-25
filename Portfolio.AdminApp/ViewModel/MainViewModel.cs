using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Portfolio.AdminApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial string Title { get; set; } = "";

        [RelayCommand]
        private void Save()
        {

        }

    }
}
