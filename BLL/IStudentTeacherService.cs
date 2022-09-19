using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IStudentTeacherService
    {
        Task Insert(StudentTeacher studentTeacher);
        Task Update(StudentTeacher studentTeacher);
        Task Delete(int id);
        Task<List<StudentTeacher>> Get(Expression<Func<StudentTeacher, bool>> expression);
    }
}
