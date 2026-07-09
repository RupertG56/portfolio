using Portfolio.Api.Base;

namespace Portfolio.Api.SkillCategory;

public class SkillCategoryDocument : BaseDocument
{
    public string Name { get; set; } = null!;
    public List<SkillDocument> Skills { get; set; } = [];
}

public class SkillDocument
{
    public string Name { get; set; } = null!;
    public string ReferenceUrl { get; set; } = null!;
    public string CategoryId { get; set; } = null!;
}