using System;
using System.Collections.Generic;

namespace core.lib.models;

public partial class Unit
{
    public string UnitCode { get; set; } = null!;

    public string UnitName { get; set; } = null!;

    public string TeacherId { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();

    public virtual Teacher Teacher { get; set; } = null!;

    public virtual ICollection<UnitCourseAllocation> UnitCourseAllocations { get; } = new List<UnitCourseAllocation>();
}
