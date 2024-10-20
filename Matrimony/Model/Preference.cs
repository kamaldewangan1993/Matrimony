using System;
using System.Collections.Generic;

namespace Matrimony.Model;

public partial class Preference
{
    public string? PreferenceId { get; set; }

    public string? UserId { get; set; }

    public string? FamilyStatus { get; set; }

    public string? Location { get; set; }

    public string? Occupation { get; set; }
}
