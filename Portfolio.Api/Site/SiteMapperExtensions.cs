using Portfolio.Domain.Site;
using Portfolio.Contracts.Site;

namespace Portfolio.Api.Site;

public static class SiteMapperExtensions
{
    public static SiteModel ToDomain(this SiteDocument doc)
    {
        return new SiteModel
        {
            Id = doc.Id,
            Title = doc.Title,
            TagLine = doc.TagLine,
            ResumeUrl = doc.ResumeUrl,
            AboutMarkdown = doc.AboutMarkdown,
            ContactInfo = doc.ContactInfo,
            SocialMediaLinks = doc.SocialMediaLinks,
            HeroSection = doc.HeroSection,
            ThemeSettings = doc.ThemeSettings
        };
    }

    public static SiteModel ToDomain(this SiteDto dto)
    {
        return new SiteModel
        {
            Id = dto.Id,
            Title = dto.Title,
            TagLine = dto.TagLine,
            ResumeUrl = dto.ResumeUrl,
            AboutMarkdown = dto.AboutMarkdown,
            ContactInfo = new ContactInfo(
                dto.ContactInfo?.Email ?? string.Empty,
                dto.ContactInfo?.Phone ?? string.Empty,
                new Address(
                    dto.ContactInfo?.Address?.Street ?? string.Empty,
                    dto.ContactInfo?.Address?.City ?? string.Empty,
                    dto.ContactInfo?.Address?.State ?? string.Empty,
                    dto.ContactInfo?.Address?.ZipCode ?? string.Empty
                )
            ),
            SocialMediaLinks = dto.SocialMediaLinks?
                .Select(s => new SocialMediaLink(s.Name, s.Url)).ToList() ?? [],
            HeroSection = new HeroSection(
                dto.HeroSection?.Heading ?? string.Empty,
                dto.HeroSection?.Subheading ?? string.Empty,
                dto.HeroSection?.ImageUrl ?? string.Empty,
                dto.HeroSection?.Text ?? string.Empty
            ),
            ThemeSettings = new ThemeSettings(
                dto.ThemeSettings?.PrimaryColor ?? string.Empty,
                dto.ThemeSettings?.SecondaryColor ?? string.Empty,
                dto.ThemeSettings?.BackgroundColor ?? string.Empty,
                dto.ThemeSettings?.FontFamily ?? string.Empty
            )
        };
    }

    public static SiteDocument ToDocument(this SiteModel model)
    {
        return new SiteDocument
        {
            Id = model.Id,
            Title = model.Title,
            TagLine = model.TagLine,
            ResumeUrl = model.ResumeUrl,
            AboutMarkdown = model.AboutMarkdown,
            ContactInfo = model.ContactInfo,
            SocialMediaLinks = model.SocialMediaLinks,
            HeroSection = model.HeroSection,
            ThemeSettings = model.ThemeSettings
        };
    }

    public static SiteDto ToDto(this SiteModel model)
    {
        return new SiteDto(
            model.Id,
            model.Title,
            model.TagLine,
            model.ResumeUrl,
            model.AboutMarkdown,
            new ContactInfoDto(
                model.ContactInfo?.Email ?? string.Empty,
                model.ContactInfo?.Phone ?? string.Empty,
                new AddressDto(
                    model.ContactInfo?.Address?.Street ?? string.Empty,
                    model.ContactInfo?.Address?.City ?? string.Empty,
                    model.ContactInfo?.Address?.State ?? string.Empty,
                    model.ContactInfo?.Address?.ZipCode ?? string.Empty
                )
            ),
            model.SocialMediaLinks?.Select(s => new SocialMediaLinkDto(s.Name, s.Url, s.Icon)).ToList() ?? [],
            new HeroSectionDto(
                model.HeroSection?.Heading ?? string.Empty,
                model.HeroSection?.Subheading ?? string.Empty,
                model.HeroSection?.ImageUrl ?? string.Empty,
                model.HeroSection?.Text ?? string.Empty
            ),
            new ThemeSettingsDto(
                model.ThemeSettings?.PrimaryColor ?? string.Empty,
                model.ThemeSettings?.SecondaryColor ?? string.Empty,
                model.ThemeSettings?.BackgroundColor ?? string.Empty,
                model.ThemeSettings?.FontFamily ?? string.Empty
            )
        );
    }
}