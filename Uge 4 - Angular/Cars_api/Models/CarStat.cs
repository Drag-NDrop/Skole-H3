using System;
using System.Collections.Generic;

namespace Cars_api.Models;

public partial class CarStat
{
    public short? Rank { get; set; }

    public string? Model { get; set; }

    public int? Quantity { get; set; }

    public int? ChangeQuantityPercent { get; set; }

    public int Id { get; set; }
}
