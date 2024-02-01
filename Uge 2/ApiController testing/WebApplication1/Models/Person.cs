using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Person
{
    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Profession { get; set; } = null!;
}
