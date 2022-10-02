using DAL;
using DAL.Repository;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentService : Repository<Student>, IStudentService
    {
        public StudentService(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

    }
}
