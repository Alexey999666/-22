using System;
using System.Collections.Generic;

namespace Практос_22.ModelsDB;

public partial class Subscription
{
    public int SubscriptionNumber { get; set; }

    public DateTime SubscriptionDate { get; set; }

    public int NumberMonths { get; set; }

    public decimal Discount { get; set; }

    public int Index { get; set; }

    public int Code { get; set; }

    public virtual Organization CodeNavigation { get; set; } = null!;

    public virtual Edition IndexNavigation { get; set; } = null!;
}
