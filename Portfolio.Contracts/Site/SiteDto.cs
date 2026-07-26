using System.Net;

namespace Portfolio.Contracts.Site;

public record SiteDto(
	string Id,
	string Title,
	string TagLine,
	string AboutMarkdown,
	string ResumeUrl,
	ContactInfoDto ContactInfo,
	IReadOnlyList<SocialMediaLinkDto> SocialMediaLinks,
	HeroSectionDto HeroSection,
	ThemeSettingsDto ThemeSettings);
