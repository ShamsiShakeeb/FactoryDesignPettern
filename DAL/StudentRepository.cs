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
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _databaseContext;

        public StudentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<Student> Get(Expression<Func<Student,bool>> expression)
        {
            return _databaseContext.Student.Where(expression);
        }
        public async Task Insert(Student model)
        {
            _databaseContext.Student.Add(model);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task Update(Student model)
        {
            _databaseContext.Student.Update(model);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var data = await _databaseContext.Student.Where(x=> x.Id == id).FirstOrDefaultAsync();
            _databaseContext.Student.Remove(data);
            await _databaseContext.SaveChangesAsync();
        }

    }
}
