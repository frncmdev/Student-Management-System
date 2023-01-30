using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.lib.models;
namespace core.lib.repositories
{
    public interface IStudentRepository: IGenericRepository<Student>
    {
        public Task<Student> GetStudentByID(int studentID);
        public Task<Student> GetStudentEnrollments(int studentID);
    }
}