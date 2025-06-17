using System;
using System.Collections.Generic;

namespace Dal
    .models;

public partial class Purchase
{
    public short PurchaseCode { get; set; }

    public short CustomerCode { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public int PurchaseAmount { get; set; }

    public string? Note { get; set; }

    public virtual Customer CustomerCodeNavigation { get; set; } = null!;

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
