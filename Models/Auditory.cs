using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLab.Models;

public partial class Auditory
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Етаж")]

    public int Floor { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Номер аудиторії")]
    public int Number { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Факультет")]
    public int Faculty { get; set; }
    [Display(Name = "Факультет")]
    public virtual Faculty FacultyNavigation { get; set; } = null!;

    public virtual ICollection<Timetable> Timetables { get; } = new List<Timetable>();
}
