using System;
using System.Collections.Generic;

namespace AviaSales.Data;

public partial class Role
{
    public int IdRole { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
