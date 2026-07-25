using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Project;

public record ProjectLinksDto(
    string? Demo,
    string? GitHub,
    string? Documentation
);
