using System;
using System.Collections.Generic;

namespace DuongChiDu_2310900022.Models;

public partial class DcdEmployee
{
    public int DcdEmpId { get; set; }

    public string? DcdEmpName { get; set; }

    public string? DcdEmpLevel { get; set; }

    public DateOnly? DcdEmpStartDate { get; set; }

    public bool? DcdEmpStatus { get; set; }
}
