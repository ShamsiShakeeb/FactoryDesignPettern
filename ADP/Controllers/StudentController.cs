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
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly IStudentFactory _studentFactory;

        public StudentController(IStudentFactory studentFactory)
        {
            _studentFactory = studentFactory;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _studentFactory.Get();
            return View(list);
        }
        public async Task<IActionResult> StudentTeacherReport()
        {
            var list = await _studentFactory.StudentTeacherRelation();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            await _studentFactory.Insert(model);
            return RedirectToAction(actionName: "Index" , controllerName:"Student");
        }
    }
}
