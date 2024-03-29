﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLab.Models;

public partial class Faculty
{
    public int Id { get; set; }
    [Required (ErrorMessage = "Поле не повинно бути порожнім")]
    [Display (Name = "Факультет")]

    public string Name { get; set; } = null!;
    // [Display(Name = "Інформація")]
    public virtual ICollection<Auditory> Auditories { get; } = new List<Auditory>();

    public virtual ICollection<Group> Groups { get; } = new List<Group>();

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}
