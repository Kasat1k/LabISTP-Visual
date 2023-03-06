using System;
using System.Collections.Generic;

namespace ISTPLab;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Faculty { get; set; }

    public virtual Faculty FacultyNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<Timetable> Timetables { get; } = new List<Timetable>();
}
