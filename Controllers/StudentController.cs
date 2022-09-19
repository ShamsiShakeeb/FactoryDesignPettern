using ADP.Factory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentFactory _studentFactory;

        public StudentController(IStudentFactory studentFactory)
        {
            _studentFactory = studentFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> StudentTeacherReport()
        {
            var list = await _studentFactory.StudentTeacherRelation();
            return View(list);
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(StudentViewModel model)
        {
            await _studentFactory.Insert(model);
            return RedirectToAction(actionName: "Index" , controllerName:"Student");
        }
    }
}
