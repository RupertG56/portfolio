using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Project;

public record ProjectSummaryDto(
    string Id,
    string Title,
    string Summary,
    int SortOrder
);
