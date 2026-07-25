using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Project;

public record TechnologyDto(
    string Name,
    string? Url,
    string? Icon
);
