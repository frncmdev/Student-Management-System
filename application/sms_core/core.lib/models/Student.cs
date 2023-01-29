using System;
using System.Collections.Generic;

namespace core.lib.models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Fullname { get; set; } = null!;

    public DateTime Dateofbirth { get; set; }

    public DateTime DateCreated { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string? PictureUrl { get; set; }

    public string? CitizenOf { get; set; }

    public int SchoolId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();

    public virtual School School { get; set; } = null!;
}
