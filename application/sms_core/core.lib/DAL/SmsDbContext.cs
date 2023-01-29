using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using core.lib.models;
using Microsoft.Extensions.Configuration;
namespace core.lib.DAL;

public partial class SmsDbContext : DbContext
{
    private readonly IConfigurationRoot _appConfig;
    public SmsDbContext()
    {
        _appConfig = new ConfigurationBuilder().AddUserSecrets<SmsDbContext>().Build();
    }

    public SmsDbContext(DbContextOptions<SmsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseType> CourseTypes { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<GradeType> GradeTypes { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<UnitCourseAllocation> UnitCourseAllocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_appConfig["conn_str"]);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseCode).HasName("PK__course__537513F051DCEA3B");

            entity.ToTable("course");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(50)
                .HasColumnName("courseCode");
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .HasColumnName("courseName");
            entity.Property(e => e.CourseTypeId).HasColumnName("CourseTypeID");
            entity.Property(e => e.SchoolId).HasColumnName("schoolID");

            entity.HasOne(d => d.CourseType).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CourseTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseType_Course");

            entity.HasOne(d => d.School).WithMany(p => p.Courses)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_School_Course");
        });

        modelBuilder.Entity<CourseType>(entity =>
        {
            entity.HasKey(e => e.CourseTypeId).HasName("PK__courseTy__8173695267B92C72");

            entity.ToTable("courseType");

            entity.Property(e => e.CourseTypeId)
                .ValueGeneratedNever()
                .HasColumnName("CourseTypeID");
            entity.Property(e => e.CourseTypeDesc).HasMaxLength(100);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__enrollme__ACFF2C6675EB271F");

            entity.ToTable("enrollment");

            entity.Property(e => e.EnrollmentId)
                .HasMaxLength(32)
                .HasColumnName("enrollmentID");
            entity.Property(e => e.GradeId)
                .HasMaxLength(12)
                .HasColumnName("GradeID");
            entity.Property(e => e.Semester).HasColumnName("semester");
            entity.Property(e => e.StudentId).HasColumnName("studentID");
            entity.Property(e => e.UnitCode).HasMaxLength(50);
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Grade).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Unit_Grade");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Enrollment");

            entity.HasOne(d => d.UnitCodeNavigation).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.UnitCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Unit_Enrollment");
        });

        modelBuilder.Entity<GradeType>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__GradeTyp__54F87A3739AF64DF");

            entity.ToTable("GradeType");

            entity.Property(e => e.GradeId)
                .HasMaxLength(12)
                .HasColumnName("GradeID");
            entity.Property(e => e.GradeDesc).HasMaxLength(50);
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.SchoolId).HasName("PK__School__3DA4677BE36EC3D8");

            entity.ToTable("School");

            entity.Property(e => e.SchoolId).HasColumnName("SchoolID");
            entity.Property(e => e.SchoolName).HasMaxLength(100);
            entity.Property(e => e.SchoolUrl)
                .HasMaxLength(50)
                .HasColumnName("SchoolURL");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__4D11D65C1BD7BCB1");

            entity.ToTable("student");

            entity.Property(e => e.StudentId).HasColumnName("studentID");
            entity.Property(e => e.CitizenOf)
                .HasMaxLength(60)
                .HasColumnName("citizenOf");
            entity.Property(e => e.DateCreated)
                .HasColumnType("date")
                .HasColumnName("dateCreated");
            entity.Property(e => e.Dateofbirth)
                .HasColumnType("date")
                .HasColumnName("dateofbirth");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(150)
                .HasColumnName("fullname");
            entity.Property(e => e.Password).HasColumnName("PASSWORD");
            entity.Property(e => e.PictureUrl).HasColumnName("pictureURL");
            entity.Property(e => e.Salt)
                .HasMaxLength(16)
                .HasColumnName("salt");
            entity.Property(e => e.SchoolId).HasColumnName("schoolID");

            entity.HasOne(d => d.School).WithMany(p => p.Students)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_School_Student");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF2594444A9B00D");

            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId)
                .HasMaxLength(100)
                .HasColumnName("TeacherID");
            entity.Property(e => e.DateCreated)
                .HasColumnType("date")
                .HasColumnName("dateCreated");
            entity.Property(e => e.Dateofbirth)
                .HasColumnType("date")
                .HasColumnName("dateofbirth");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(150)
                .HasColumnName("fullname");
            entity.Property(e => e.Password).HasColumnName("PASSWORD");
            entity.Property(e => e.PictureUrl).HasColumnName("pictureURL");
            entity.Property(e => e.Salt)
                .HasMaxLength(16)
                .HasColumnName("salt");
            entity.Property(e => e.SchoolId).HasColumnName("schoolID");

            entity.HasOne(d => d.School).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_School_Teacher");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitCode).HasName("PK__unit__0665E6D820E03D46");

            entity.ToTable("unit");

            entity.Property(e => e.UnitCode).HasMaxLength(50);
            entity.Property(e => e.TeacherId)
                .HasMaxLength(100)
                .HasColumnName("teacherID");
            entity.Property(e => e.UnitName).HasMaxLength(100);

            entity.HasOne(d => d.Teacher).WithMany(p => p.Units)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_unit");
        });

        modelBuilder.Entity<UnitCourseAllocation>(entity =>
        {
            entity.HasKey(e => e.Ucaid).HasName("PK__unitCour__A67AC8A39BFE590B");

            entity.ToTable("unitCourseAllocation");

            entity.Property(e => e.Ucaid).HasColumnName("UCAID");
            entity.Property(e => e.CourseCode).HasMaxLength(50);
            entity.Property(e => e.UnitCode).HasMaxLength(50);

            entity.HasOne(d => d.CourseCodeNavigation).WithMany(p => p.UnitCourseAllocations)
                .HasForeignKey(d => d.CourseCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_UCA");

            entity.HasOne(d => d.UnitCodeNavigation).WithMany(p => p.UnitCourseAllocations)
                .HasForeignKey(d => d.UnitCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Unit_UCA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
