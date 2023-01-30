using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.lib.models;
using core.lib.DAL;
using Microsoft.EntityFrameworkCore;
namespace core.lib.repositories
{
    public class StudentRepository: GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(SmsDbContext context):base(context)
        {
            
        }

        public async Task<Student> GetStudentByID(int studentID)
        {
            return await _context.Students.FindAsync(studentID);
        }

        public async Task<Student> GetStudentEnrollments(int studentID)
        {
            return await _context.Students.Include(s => s.Enrollments).SingleOrDefaultAsync(s=>s.StudentId==studentID);
        }
    }
}