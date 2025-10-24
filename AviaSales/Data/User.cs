using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AviaSales.Data;

public partial class User
{
    public int IdUser { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? IdRole { get; set; }

    [Display(AutoGenerateField = false)]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [Display(AutoGenerateField = false)]
    public virtual Role? IdRoleNavigation { get; set; }
}
