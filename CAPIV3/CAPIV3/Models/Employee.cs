using System;
using System.Collections.Generic;

namespace CAPIV3.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime JoinDate { get; set; }

    public string? ImageName { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
}
