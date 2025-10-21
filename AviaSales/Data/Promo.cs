using System;
using System.Collections.Generic;

namespace AviaSales.Data;

public partial class Promo
{
    public int IdPromo { get; set; }

    public int? Discount { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
