using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ISTPLab.Models;

namespace ISTPLab;

public partial class Subject
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Предмет")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Timetable> Timetables { get; } = new List<Timetable>();
}
