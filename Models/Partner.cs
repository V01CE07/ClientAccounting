using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace demoDrozdov.Models;

public partial class Partner: INotifyPropertyChanged
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? Partnername { get; set; }

    public string? Director { get; set; }

    public string? Partneremail { get; set; }

    public string? Partnerphone { get; set; }

    public string? Partneradress { get; set; }

    public string? Inn { get; set; }

    public int? Rating { get; set; }

    public string? Logo { get; set; }

    public string? Salesplace { get; set; }

    public string? Historyproduct { get; set; }

    public int? Discount { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public event PropertyChangedEventHandler? PropertyChanged;
}
