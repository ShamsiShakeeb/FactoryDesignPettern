using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DatabaseContext _databaseContext;
        public TeacherRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<Teacher> Get(Expression<Func<Teacher, bool>> expression)
        {
            return _databaseContext.Teacher.Where(expression);
        }
        public async Task Insert(Teacher model)
        {
            _databaseContext.Teacher.Add(model);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task Update(Teacher model)
        {
            _databaseContext.Teacher.Update(model);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var data = await _databaseContext.Teacher.Where(x => x.Id == id).FirstOrDefaultAsync();
            _databaseContext.Teacher.Remove(data);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
