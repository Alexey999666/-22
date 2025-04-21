using System;
using System.Collections.Generic;

namespace Практос_22.ModelsDB;

public partial class Edition
{
    public int Index { get; set; }

    public string TitleEdition { get; set; } = null!;

    public string? Type { get; set; }

    public int PageCount { get; set; }

    public decimal Price { get; set; }

    public byte[]? Photo { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
