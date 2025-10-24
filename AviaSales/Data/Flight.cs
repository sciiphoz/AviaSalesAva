using System;
using System.Collections.Generic;

namespace AviaSales.Data;

public partial class Flight
{
    public int IdFlight { get; set; }

    public string? Airline { get; set; }

    public string? Aircraft { get; set; }

    public string? DepartureCity { get; set; }

    public string? ArrivalCity { get; set; }

    public DateOnly? DepartureTime { get; set; }

    public DateOnly? ArrivalTime { get; set; }

    public int? Price { get; set; }

    public string? Class { get; set; }

    public int? SeatNumber { get; set; }

    public string? Status { get; set; }

    public int? IdPromo { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Promo? IdPromoNavigation { get; set; }
}
