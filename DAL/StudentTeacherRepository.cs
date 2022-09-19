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
    public class StudentTeacherRepository : IStudentTeacherRepository
    { 
        private readonly DatabaseContext _databaseContext;

        public StudentTeacherRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<StudentTeacher> Get(Expression<Func<StudentTeacher, bool>> expression)
        {
            return _databaseContext.Student_Teacher.Where(expression);
        }
        public async Task Insert(StudentTeacher model)
        {
            _databaseContext.Student_Teacher.Add(model);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task Update(StudentTeacher model)
        {
            _databaseContext.Student_Teacher.Update(model);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var data = await _databaseContext.Student_Teacher.Where(x => x.Id == id).FirstOrDefaultAsync();
            _databaseContext.Student_Teacher.Remove(data);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
