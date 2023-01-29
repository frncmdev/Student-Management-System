using System;
using System.Collections.Generic;

namespace core.lib.models;

public partial class School
{
    public int SchoolId { get; set; }

    public string? SchoolName { get; set; }

    public string? SchoolUrl { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}
