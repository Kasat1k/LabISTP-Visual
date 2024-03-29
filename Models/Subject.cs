﻿using System;
using System.Collections.Generic;
using ISTPLab.Models;

namespace ISTPLab;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Timetable> Timetables { get; } = new List<Timetable>();
}
