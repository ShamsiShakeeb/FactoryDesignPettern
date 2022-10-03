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

        [Route("api/student/PostNewStudent")]
        [HttpPost]
        public async Task<ActionResult> PostNewStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
             return BadRequest("Invalid data.");

          await _studentFactory.Insert(student);

          return Ok();
        }
        [Route("api/student/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");
            await _studentFactory.Delete(id);
            return Ok();
        }

        [Route("api/student/StudentUpdate/{id}")]
        [HttpPut]
        public async Task<ActionResult> StudentUpdate(int id , StudentViewModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            await _studentFactory.Update(id, student);
            return Ok();
        }

        [Route("api/student/Search/{address}")]
        [HttpGet]
        public async Task<IActionResult> Search(string address)
        {
            var list = await _studentFactory.Get(address);
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
