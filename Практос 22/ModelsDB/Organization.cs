using System;
using System.Collections.Generic;

namespace Практос_22.ModelsDB;

public partial class Organization
{
    public int Code { get; set; }

    public string TitleOrganization { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Phone { get; set; }

    public int NumberEmployees { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
