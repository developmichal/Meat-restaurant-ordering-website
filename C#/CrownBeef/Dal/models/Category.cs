using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Category
{
    public short CategoryCode { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
