using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLab.Models;

public partial class Group
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Група")]
    public string Name { get; set; } = null!;

    public int Faculty { get; set; }
    [Display(Name = "Факультет")]
    public virtual Faculty FacultyNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<Timetable> Timetables { get; } = new List<Timetable>();
}
