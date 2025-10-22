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

    public DateTime? DepartureTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public string FlightTime
    {
        get
        {
            if (DepartureTime.HasValue && ArrivalTime.HasValue)
            {
                TimeSpan duration = ArrivalTime.Value - DepartureTime.Value;
                return duration.ToString(@"d\.hh\:mm");
            }
            return "N/A";
        }
    }


    public int? Price { get; set; }

    public string? Class { get; set; }

    public int? SeatNumber { get; set; }

    public string? Status { get; set; }

    public int? IdPromo { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Promo? IdPromoNavigation { get; set; }
}
