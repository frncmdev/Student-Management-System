using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.lib.repositories
{
    public interface IUnitOfWork
    {
        public ICourseRepository courseRepository {get;}
        public IStudentRepository studentRepository {get;}
        public void Save();
        public void Dispose();
    }
}