using System;
using System.Collections.Generic;

namespace core.lib.models;

public partial class Enrollment
{
    public string EnrollmentId { get; set; } = null!;

    public int Year { get; set; }

    public int Semester { get; set; }

    public string UnitCode { get; set; } = null!;

    public int StudentId { get; set; }

    public string GradeId { get; set; } = null!;

    public virtual GradeType Grade { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Unit UnitCodeNavigation { get; set; } = null!;
}
