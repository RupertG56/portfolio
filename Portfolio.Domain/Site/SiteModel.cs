namespace Portfolio.Domain.Site
{
	public class SiteModel
	{
		public string Id { get; init; } = string.Empty;

		public string Title { get; set; } = string.Empty;

		public string TagLine { get; set; } = string.Empty;

		public string AboutMarkdown { get; set; } = string.Empty;

		public string ResumeUrl { get; set; } = string.Empty;

		public ContactInfo ContactInfo { get; set; } = new ContactInfo(string.Empty, string.Empty, new Address(string.Empty, string.Empty, string.Empty, string.Empty));

		public List<SocialMediaLink> SocialMediaLinks { get; set; } = [];

		public HeroSection HeroSection { get; set; } = new HeroSection(string.Empty, string.Empty, string.Empty, string.Empty);

		public ThemeSettings ThemeSettings { get; set; } = new ThemeSettings("#1976d2", string.Empty, string.Empty, string.Empty);
	}

	public sealed class ContactInfo(string email,
		string phone, Address address)
	{
		public string Email { get; set; } = email;
		public string Phone { get; set; } = phone;
		public Address Address { get; set; } = address;
	}

	public sealed class Address(
		string street, string city,
		string state, string zipCode)
	{
		public string Street { get; set; } = street;
		public string City { get; set; } = city;
		public string State { get; set; } = state;
		public string ZipCode { get; set; } = zipCode;
	}

	public sealed class SocialMediaLink(string platform, string url)
	{
		public string Platform { get; set; } = platform;
		public string Url { get; set; } = url;
	}

	public sealed class HeroSection(string heading, string subheading, string imageUrl, string text)
	{
		public string Heading { get; set; } = heading;
		public string Subheading { get; set; } = subheading;
		public string ImageUrl { get; set; } = imageUrl;
		public string Text { get; set; } = text;
	}

	public sealed class ThemeSettings(string primaryColor, string secondaryColor, string backgroundColor, string fontFamily)
	{
		public string PrimaryColor { get; set; } = primaryColor;
		public string SecondaryColor { get; set; } = secondaryColor;
		public string BackgroundColor { get; set; } = backgroundColor;
		public string FontFamily { get; set; } = fontFamily;
	}
}
