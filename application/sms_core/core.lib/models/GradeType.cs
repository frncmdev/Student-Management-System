using System;
using System.Collections.Generic;

namespace core.lib.models;

public partial class GradeType
{
    public string GradeId { get; set; } = null!;

    public string GradeDesc { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();
}
