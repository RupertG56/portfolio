namespace Portfolio.Domain.Site;

public sealed class HeroSection(string heading, string subheading, string imageUrl, string text)
{
    public string Heading { get; set; } = heading;
    public string Subheading { get; set; } = subheading;
    public string ImageUrl { get; set; } = imageUrl;
    public string Text { get; set; } = text;
}
