using System;
using System.Collections.Generic;

namespace demoDrozdov.Models;

public partial class Product
{
    public int Id { get; set; }

    public int? ProductType { get; set; }

    public string? ProductName { get; set; }

    public string? Article { get; set; }

    public float? MinCostForpartners { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual ProductType? ProductTypeNavigation { get; set; }
}
