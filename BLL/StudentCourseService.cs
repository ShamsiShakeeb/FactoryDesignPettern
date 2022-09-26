using DAL;
using DAL.Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    internal class StudentCourseService : Repository<StudentCourse>, IStudentCourseService
    {
        public StudentCourseService(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
