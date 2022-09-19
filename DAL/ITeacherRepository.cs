using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ITeacherRepository
    {
        IQueryable<Teacher> Get(Expression<Func<Teacher, bool>> expression);
        Task Insert(Teacher model);
        Task Update(Teacher model);
        Task Delete(int id);
    }
}
