using System;
using System.Collections.Generic;

namespace PruebaTecnicaBackend.Domain.Entities;

public partial class Address
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? ZipCode { get; set; }

    public virtual User User { get; set; } = null!;
}
