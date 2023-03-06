using System;
using System.Collections.Generic;

namespace ISTPLab;

public partial class Faculty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Auditory> Auditories { get; } = new List<Auditory>();

    public virtual ICollection<Group> Groups { get; } = new List<Group>();

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}
