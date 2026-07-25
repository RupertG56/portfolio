using Portfolio.Domain.Site;

namespace Portfolio.Api.Site;

public class SiteDocument
{
    public const string CollectionName = "site";
    public string Id { get; init; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string TagLine { get; set; } = string.Empty;
    public string AboutMarkdown { get; set; } = string.Empty;
    public string ResumeUrl { get; set; } = "/files/PrincipalResume.pdf";
    public ContactInfo ContactInfo { get; set; } = new ContactInfo(string.Empty, string.Empty, new Address(string.Empty, string.Empty, string.Empty, string.Empty));
    public List<SocialMediaLink> SocialMediaLinks { get; set; } = [];
    public HeroSection HeroSection { get; set; } = new HeroSection(string.Empty, string.Empty, string.Empty, string.Empty);
    public ThemeSettings ThemeSettings { get; set; } = new ThemeSettings("#1976d2", string.Empty, string.Empty, string.Empty);
}