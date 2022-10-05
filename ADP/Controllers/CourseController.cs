using ADP.Factory;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.Controllers
{
    [Route("api/Course/[action]")]
    public class CourseController : GenericController<Course, CourseViewModel>
    {
        public CourseController(IGenericFactory<Course> genericFactory) : base(genericFactory)
        {
        }
    }
}
