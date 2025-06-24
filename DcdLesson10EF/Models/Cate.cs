using System;
using System.Collections.Generic;

namespace DcdLesson10EF.Models;

public partial class Cate
{
    public int CateId { get; set; }

    public string? CateName { get; set; }

    public bool? CateStatus { get; set; }
}
