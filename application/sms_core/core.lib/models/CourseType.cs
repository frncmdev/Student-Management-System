using System;
using System.Collections.Generic;

namespace core.lib.models;

public partial class CourseType
{
    public int CourseTypeId { get; set; }

    public string CourseTypeDesc { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
