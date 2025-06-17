using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class PurchaseDetail
{
    public short DetailsCode { get; set; }

    public short PurchaseCode { get; set; }

    public short ProductCode { get; set; }

    public short Amount { get; set; }

    public virtual Product ProductCodeNavigation { get; set; } = null!;

    public virtual Purchase PurchaseCodeNavigation { get; set; } = null!;
}
