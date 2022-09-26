using DAL;
using DAL.Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CourseService : Repository<Course>, ICourseService
    {
        public CourseService(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
