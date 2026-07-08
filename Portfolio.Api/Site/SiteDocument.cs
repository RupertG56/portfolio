namespace Portfolio.Api.Site;

public class SiteDocument
{
    public string Id { get; init; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string TagLine { get; set; } = string.Empty;
    public string AboutMarkdown { get; set; } = string.Empty;
    public string ResumeUrl { get; set; } = "/files/PrincipalResume.pdf";
    public ContactInfo ContactInfo { get; set; } = new ContactInfo(string.Empty, string.Empty, new Address(string.Empty, string.Empty, string.Empty, string.Empty));
    public List<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    public HeroSection HeroSection { get; set; } = new HeroSection(string.Empty, string.Empty, string.Empty, string.Empty);
    public ThemeSettings ThemeSettings { get; set; } = new ThemeSettings("#1976d2", string.Empty, string.Empty, string.Empty);
}

public sealed record ContactInfo(string Email, string Phone, Address Address);

public sealed record Address(string Street, string City, string State, string ZipCode);

public sealed record SocialMediaLink(string Platform, string Url);

public sealed record HeroSection(string Heading, string Subheading, string ImageUrl, string Text);

public sealed record ThemeSettings(string PrimaryColor, string SecondaryColor, string BackgroundColor, string FontFamily);