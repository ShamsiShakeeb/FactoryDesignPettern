using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IStudentRepository
    {
        IQueryable<Student> Get(Expression<Func<Student, bool>> expression);
        Task Insert(Student model);
        Task Update(Student model);
        Task Delete(int id);
    }
}
