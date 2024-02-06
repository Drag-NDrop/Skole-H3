using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Person
{
    public Person(string name, int age, string profession)
    {
        this.Name = name;
        this.Age = age;
        this.Profession = profession;
    }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Profession { get; set; } = null!;
}
