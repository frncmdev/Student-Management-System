using System;
using System.Collections.Generic;

namespace core.lib.models;

public partial class Teacher
{
    public string TeacherId { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public DateTime Dateofbirth { get; set; }

    public DateTime DateCreated { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string? PictureUrl { get; set; }

    public int SchoolId { get; set; }

    public virtual School School { get; set; } = null!;

    public virtual ICollection<Unit> Units { get; } = new List<Unit>();
}
