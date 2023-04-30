using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLab.Models;

public partial class Student
{
    public int Id { get; set; }
    [Display(Name = "Студент")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public string Name { get; set; } = null!;
    [Display(Name = "Група")]
    public int GroupSt { get; set; }
    [Display(Name = "Група")]
    public virtual Group GroupStNavigation { get; set; } = null!;
}
