using CommunityToolkit.Mvvm.ComponentModel;

namespace Portfolio.AdminApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel(SiteViewModel siteViewModel)
		{
			SiteViewModel = siteViewModel;
		}

		/// <summary>
		/// This constructor is used for design-time data in the XAML designer.
		/// </summary>
		public MainViewModel()
		{
			SiteViewModel = new SiteViewModel();
		}

		[ObservableProperty]
        public partial string Title { get; set; } = "";

        public SiteViewModel SiteViewModel { get; set; }
	}
}
