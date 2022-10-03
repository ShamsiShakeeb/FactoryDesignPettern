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
    [Route("api/StudentApi/[action]")]
    public class StudentAPIController : GenericController<Student,StudentViewModel>
    {
        public StudentAPIController(IGenericFactory<Student> genericFactory) : base(genericFactory)
        {

        }
    }
}
