using System;
using System.Collections.Generic;

namespace CAPIV3.Models;

public partial class Experience
{
    public int ExperienceId { get; set; }

    public string Title { get; set; } = null!;

    public int Duration { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
