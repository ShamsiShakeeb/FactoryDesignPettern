using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IStudentTeacherRepository
    {
        IQueryable<StudentTeacher> Get(Expression<Func<StudentTeacher, bool>> expression);
        Task Insert(StudentTeacher model);
        Task Update(StudentTeacher model);
        Task Delete(int id);
    }
}
