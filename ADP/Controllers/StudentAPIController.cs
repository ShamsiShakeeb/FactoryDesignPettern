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
        private readonly IStudentFactory _studentFactory;
        public StudentAPIController(IGenericFactory<Student> genericFactory, IStudentFactory studentFactory) : base(genericFactory)
        {
            _studentFactory = studentFactory;
        }
        
        [HttpGet]
        public async Task<IActionResult> StudentTeacherReport()
        {
            var list = await _studentFactory.StudentTeacherRelation();
            return Ok(new
            {
                success = list.Any(),
                message = string.Format("{0} List Fetched Successfully", "Student Teacher Relation"),
                result = list
            });
        }
        [HttpGet]
        public async Task<ActionResult> DeleteByEmail(string email)
        {
            if (email==null)
                return BadRequest("Not a valid email");
            await _studentFactory.DeleteByEmail(email);
            return Ok();
        }
    }
}
