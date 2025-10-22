using System;
using System.Collections.Generic;

namespace AviaSales.Data;

public partial class Booking
{
    public int IdBooking { get; set; }

    public int? IdUser { get; set; }

    public int? IdFlight { get; set; }

    public virtual Flight? IdFlightNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
