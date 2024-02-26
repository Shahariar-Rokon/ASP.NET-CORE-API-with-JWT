using System;
using System.Collections.Generic;

namespace CAPIV3.Models;

public partial class TblUser
{
    public int TblUserId { get; set; }

    public string EmailId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public string FullName { get; set; } = null!;
}
