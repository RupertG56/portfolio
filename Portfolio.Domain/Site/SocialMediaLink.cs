namespace Portfolio.Domain.Site;

public sealed class SocialMediaLink(string name, string url)
{
    public string Name { get; set; } = name;
    public string Url { get; set; } = url;

    public string Icon => Name.ToLower() switch
    {
        "github" => "fab fa-github",
        "linkedin" => "fab fa-linkedin",
        "twitter" => "fab fa-twitter",
        "facebook" => "fab fa-facebook",
        "instagram" => "fab fa-instagram",
        _ => string.Empty
    };
}
