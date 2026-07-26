using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Portfolio.AdminApp.Services;
using Portfolio.Contracts.Site;

namespace Portfolio.AdminApp.ViewModel
{
    public partial class SiteViewModel : ObservableObject
    {
        private ISiteService siteService;
		private SiteDto? site;

        public SiteViewModel(ISiteService siteService)
		{
			this.siteService = siteService;
			IsInEditMode = false;
		}

		/// <summary>
		/// This constructor is used for design-time data in the XAML designer.
		/// </summary>
		public SiteViewModel()
		{
			siteService = new SiteService(new Api.PortfolioApiClient(new System.Net.Http.HttpClient()));
			site = new SiteDto(
				"designtime-site",
				"Design Time Site",
				"This is the design time site tagline.",
				"This is the design time site about markdown.",
				"/files/resume.pdf",
				new ContactInfoDto(
					"design-time-email@example.com",
					"123-456-7890",
					new AddressDto(
						"123 Design Time St",
						"Design City",
						"DS",
						"12345"
					)
				),
				[],
				new HeroSectionDto(
					string.Empty,
					string.Empty,
					string.Empty,
					string.Empty),
				new ThemeSettingsDto(
					string.Empty,
					string.Empty,
					string.Empty,
					string.Empty)
			);
		}

		[RelayCommand]
		public async Task LoadSiteDataAsync(CancellationToken cancellationToken = default)
		{
			var siteData = await siteService.GetAsync(cancellationToken);
			if (siteData != null && siteData.Success)
			{
				site = siteData.Data!;
				SiteTitle = site.Title;
				AboutMarkdown = site.AboutMarkdown;
				TagLine = site.TagLine;
				SiteResumeUrl = site.ResumeUrl;
				SiteEmail = site.ContactInfo.Email;
				SitePhone = site.ContactInfo.Phone;
				SiteAddressStreet = site.ContactInfo.Address.Street;
				SiteAddressCity = site.ContactInfo.Address.City;
				SiteAddressState = site.ContactInfo.Address.State;
				SiteAddressZip = site.ContactInfo.Address.ZipCode;
			}
		}

		[RelayCommand]
		private void SwitchToEditMode()
		{
			IsInEditMode = true;
		}

		[RelayCommand]
		private void CancelEdit()
		{
			IsInEditMode = false;
		}

		[RelayCommand]
		public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			if (site is null)
			{
				return false;
			}

			var updatedSite = new SiteDto(
				site.Id,
				SiteTitle ?? site.Title,
				TagLine ?? site.TagLine,
				AboutMarkdown ?? site.AboutMarkdown,
				SiteResumeUrl ?? site.ResumeUrl,
				new ContactInfoDto(
					SiteEmail ?? site.ContactInfo.Email,
					SitePhone ?? site.ContactInfo.Phone,
					new AddressDto(
						SiteAddressStreet ?? site.ContactInfo.Address.Street,
						SiteAddressCity ?? site.ContactInfo.Address.City,
						SiteAddressState ?? site.ContactInfo.Address.State,
						SiteAddressZip ?? site.ContactInfo.Address.ZipCode
					)
				),
				site.SocialMediaLinks,
				site.HeroSection,
				site.ThemeSettings
			);
			var result = await siteService.UpdateAsync(updatedSite, cancellationToken);
			if (result.Success)
			{
				IsInEditMode = false;
				await LoadSiteDataAsync(cancellationToken);
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool IsInViewMode => !IsInEditMode;

		[ObservableProperty]
		public partial bool IsInEditMode { get; set; }

		partial void OnIsInEditModeChanged(bool value)
		{
			OnPropertyChanged(nameof(IsInViewMode));
		}

		#region ViewModel Model Properties

		[ObservableProperty]
		public partial string? SiteTitle { get; set; }

		[ObservableProperty]
		public partial string? AboutMarkdown { get; set; }

		[ObservableProperty]
		public partial string? TagLine { get; set; }

		[ObservableProperty]
		public partial string? SiteResumeUrl { get; set; }

		[ObservableProperty]
		public partial string? SiteEmail { get; set; }

		[ObservableProperty]
		public partial string? SitePhone { get; set; }

		[ObservableProperty]
		public partial string? SiteAddressStreet { get; set; }

		[ObservableProperty]
		public partial string? SiteAddressCity { get; set; }

		[ObservableProperty]
		public partial string? SiteAddressState { get; set; }

		[ObservableProperty]
		public partial string? SiteAddressZip { get; set; }

		#endregion ViewModel Model Properties
	}
}
