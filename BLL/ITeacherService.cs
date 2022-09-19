using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ITeacherService
    {
        Task Insert(Teacher Teacher);
        Task Update(Teacher Teacher);
        Task Delete(int id);
        Task<List<Teacher>> Get(Expression<Func<Teacher, bool>> expression);
    }
}
