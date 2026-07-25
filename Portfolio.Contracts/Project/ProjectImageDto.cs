using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Project;

public record ProjectImageDto(
    string Url,
    string AltText,
    int SortOrder
);