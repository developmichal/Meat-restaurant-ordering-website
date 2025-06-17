using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Product
{
    public short ProductCode { get; set; }

    public string ProductName { get; set; } = null!;

    public short CategoryCode { get; set; }

    public string ProductDescription { get; set; } = null!;

    public short Price { get; set; }

    public string Picture { get; set; } = null!;

    public short QuantityInStock { get; set; }

    public DateOnly LastUpdateDate { get; set; }

    public virtual Category CategoryCodeNavigation { get; set; } = null!;

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
