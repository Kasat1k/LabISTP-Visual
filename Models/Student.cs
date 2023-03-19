using System;
using System.Collections.Generic;

namespace ISTPLab.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int GroupSt { get; set; }

    public virtual Group GroupStNavigation { get; set; } = null!;
}
