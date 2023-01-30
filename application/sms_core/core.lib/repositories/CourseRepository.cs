using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using core.lib.DAL;
using core.lib.models;
using Microsoft.EntityFrameworkCore.Query;

namespace core.lib.repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(SmsDbContext context):base(context)
        {

        }
        public async Task<Course> GetById(string courseCode)
        {
            return await _context.Courses.FindAsync(courseCode);
        }

        public async Task<Course> GetCourseWithUnits(string courseCode)
        {
            return await _context.Courses.Include(c=> c.UnitCourseAllocations).SingleOrDefaultAsync(c => c.CourseCode == courseCode);
        }
    }
}