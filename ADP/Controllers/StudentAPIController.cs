using ADP.Factory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.Controllers
{
    public class StudentAPIController : Controller
    {
        private readonly IStudentFactory _studentFactory;
        public StudentAPIController(IStudentFactory studentFactory)
        {
            _studentFactory = studentFactory;
        }
        [Route("api/StudentApi/Insert")]
        [HttpPost]
        public async Task<IActionResult> Insert(StudentViewModel model)
        {
            await _studentFactory.Insert(model);
            return Ok(new { message = "Student Added" });
        }
        [Route("api/StudentApi/Update/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(int id, StudentViewModel model)
        {
            await _studentFactory.Update(id, model);
            return Ok(new { message = "Student Updated" });
        }
        [Route("api/StudentApi/Delete/{id}")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentFactory.Delete(id);
            return Ok(new { message = "Student Deleted Successfully" });
        }
        [Route("api/StudentApi/Details/{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _studentFactory.DetailsById(id);
            return Ok(new { message = "Student Details Fetch Successfully", result = data });
        }
        [Route("api/StudentApi/List")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var list = await _studentFactory.Get();
            return Ok(new { message = "Student List Fetch Successfully" , result  = list});
        }
    }
}
