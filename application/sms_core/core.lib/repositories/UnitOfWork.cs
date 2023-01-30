using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.lib.DAL;
namespace core.lib.repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private SmsDbContext _context;
        // 
        public UnitOfWork()
        {
            _context = new SmsDbContext();
            courseRepository = new CourseRepository(_context);
        }

        public ICourseRepository courseRepository {get; private set;}

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
        public async void Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}