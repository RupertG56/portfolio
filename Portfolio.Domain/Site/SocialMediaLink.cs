namespace Portfolio.Domain.Site;

public sealed class SocialMediaLink(string platform, string url)
{
    public string Platform { get; set; } = platform;
    public string Url { get; set; } = url;
}
