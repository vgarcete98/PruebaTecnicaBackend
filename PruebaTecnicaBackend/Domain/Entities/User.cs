using System;
using System.Collections.Generic;

namespace PruebaTecnicaBackend.Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? IsActive { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
