using ADP.Factory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.Controllers
{
    //[Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentFactory _studentFactory;

        public StudentController(IStudentFactory studentFactory)
        {
            _studentFactory = studentFactory;
        }
        [Route("api/student/Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _studentFactory.Get();
            return Ok(list);
        }
        [Route("api/student/StudentTeacherReport")]
        [HttpGet]
        public async Task<IActionResult> StudentTeacherReport()
        {
            var list = await _studentFactory.StudentTeacherRelation();
            return Ok(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [Route("api/student/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            await _studentFactory.Insert(model);
            return Ok(true);
        }
    }
}
