using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLab.Models;

public partial class Timetable
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Предмет")]
    public int Subject { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Номер аудиторії")]
    public int Auditory { get; set; }
    
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Група")]
    public int GroupTt { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Викладач")]
    public int Teacher { get; set; }
    
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Час проведення пари")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
    public DateTime Time { get; set; }
    [Display(Name = "Номер аудиторії")]
    public virtual Auditory AuditoryNavigation { get; set; } = null!;
    [Display(Name = "Група")]
    public virtual Group GroupTtNavigation { get; set; } = null!;
    [Display(Name = "Предмет")]
    public virtual Subject SubjectNavigation { get; set; } = null!;
    [Display(Name = "Викладач")]
    public virtual Teacher TeacherNavigation { get; set; } = null!;
}
