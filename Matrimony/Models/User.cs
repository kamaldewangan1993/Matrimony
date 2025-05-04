using System;
using System.Collections.Generic;

namespace Matrimony.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? AppId { get; set; }

    public string? EmailId { get; set; }

    public string? MobileNo { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public string? AadharNo { get; set; }

    public string? District { get; set; }

    public int? City { get; set; }

    public int? State { get; set; }

    public bool? IsActive { get; set; }
}
