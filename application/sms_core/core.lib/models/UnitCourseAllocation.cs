using System;
using System.Collections.Generic;

namespace core.lib.models;

public partial class UnitCourseAllocation
{
    public int Ucaid { get; set; }

    public string CourseCode { get; set; } = null!;

    public string UnitCode { get; set; } = null!;

    public virtual Course CourseCodeNavigation { get; set; } = null!;

    public virtual Unit UnitCodeNavigation { get; set; } = null!;
}
