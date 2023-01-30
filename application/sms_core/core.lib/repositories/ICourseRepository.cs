using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.lib.models;
namespace core.lib.repositories
{
    public interface ICourseRepository: IGenericRepository<Course>
    {
        public Task<Course> GetById(string courseCode);
        public Task<Course> GetCourseWithUnits(string courseCode);
    }
}