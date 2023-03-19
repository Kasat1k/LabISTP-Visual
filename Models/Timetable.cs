using System;
using System.Collections.Generic;

namespace ISTPLab.Models;

public partial class Timetable
{
    public int Id { get; set; }

    public int Subject { get; set; }

    public int Auditory { get; set; }

    public int GroupTt { get; set; }

    public int Teacher { get; set; }

    public virtual Auditory AuditoryNavigation { get; set; } = null!;

    public virtual Group GroupTtNavigation { get; set; } = null!;

    public virtual Subject SubjectNavigation { get; set; } = null!;

    public virtual Teacher TeacherNavigation { get; set; } = null!;
}
