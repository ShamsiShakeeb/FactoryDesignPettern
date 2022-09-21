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
    public class TeacherService : Repository<Teacher> , ITeacherService
    {
        public TeacherService(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}
