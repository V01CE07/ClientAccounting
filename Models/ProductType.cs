using System;
using System.Collections.Generic;

namespace demoDrozdov.Models;

public partial class ProductType
{
    public int Id { get; set; }

    public string? Producttype1 { get; set; }

    public float? ProductTypeIndex { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
