using System;
using System.Collections.Generic;

namespace demoDrozdov.Models;

public partial class PartnerProduct
{
    public int Id { get; set; }

    public int? Products { get; set; }

    public int? Partnername { get; set; }

    public int? Productamount { get; set; }

    public string? Salesdate { get; set; }

    public virtual Partner? PartnernameNavigation { get; set; }

    public virtual Product? ProductsNavigation { get; set; }
}
