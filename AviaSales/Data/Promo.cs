using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AviaSales.Data;

public partial class Promo
{
    public int IdPromo { get; set; }

    public int? Discount { get; set; }

    [Display(AutoGenerateField = false)]
    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}
