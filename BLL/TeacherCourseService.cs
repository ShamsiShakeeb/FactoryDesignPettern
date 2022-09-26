using DAL;
using DAL.Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class TeacherCourseService : Repository<TeacherCourse>, ITeacherCourseService
    {
        public TeacherCourseService(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
