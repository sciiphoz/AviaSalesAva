using System;
using System.Collections.Generic;

namespace AviaSales.Data;

public partial class User
{
    public int IdUser { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? IdRole { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Role? IdRoleNavigation { get; set; }
}
