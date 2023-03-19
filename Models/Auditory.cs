using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLab.Models;

public partial class Auditory
{
    public int Id { get; set; }
    

    public int Floor { get; set; }

    public int Number { get; set; }

    public int Faculty { get; set; }

    public virtual Faculty FacultyNavigation { get; set; } = null!;

    public virtual ICollection<Timetable> Timetables { get; } = new List<Timetable>();
}
