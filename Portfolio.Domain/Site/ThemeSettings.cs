namespace Portfolio.Domain.Site;

public sealed class ThemeSettings(string primaryColor, string secondaryColor, string backgroundColor, string fontFamily)
{
    public string PrimaryColor { get; set; } = primaryColor;
    public string SecondaryColor { get; set; } = secondaryColor;
    public string BackgroundColor { get; set; } = backgroundColor;
    public string FontFamily { get; set; } = fontFamily;
}