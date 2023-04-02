using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLab.Models;

public partial class Teacher
{
    public int Id { get; set; }
    [Display(Name = "Викладач")]
    public string Name { get; set; } = null!;
    //[Display(Name = "Факультет")]
    public int Faculty { get; set; }
    [Display(Name = "Факультет")]

    public virtual Faculty FacultyNavigation { get; set; } = null!;

    public virtual ICollection<Timetable> Timetables { get; } = new List<Timetable>();
}
