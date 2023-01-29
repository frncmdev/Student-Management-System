using System;
using System.Collections.Generic;

namespace core.lib.models;

public partial class Course
{
    public string CourseCode { get; set; } = null!;

    public string? CourseName { get; set; }

    public int CourseTypeId { get; set; }

    public int SchoolId { get; set; }

    public virtual CourseType CourseType { get; set; } = null!;

    public virtual School School { get; set; } = null!;

    public virtual ICollection<UnitCourseAllocation> UnitCourseAllocations { get; } = new List<UnitCourseAllocation>();
}
