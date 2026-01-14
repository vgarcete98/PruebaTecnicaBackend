using System;
using System.Collections.Generic;

namespace PruebaTecnicaBackend.Domain.Entities;

public partial class Currency
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal RateToBase { get; set; }
}
