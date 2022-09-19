using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IStudentService
    {
        Task Insert(Student student);
        Task Update(Student student);
        Task Delete(int id);
        Task<List<Student>> Get(Expression<Func<Student, bool>> expression);
    }
}
