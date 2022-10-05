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
    [Route("api/TeacherApi/[action]")]
    public class TeacherApiController : GenericController<Teacher, TeacherViewModel>
    {
        public TeacherApiController(IGenericFactory<Teacher> genericFactory) : base(genericFactory)
        {
        }
    }
}
