using ADP.Factory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.ViewComponents
{
    public class StudentTeacherRelationViewComponent : ViewComponent
    {
        private readonly IStudentFactory _studentFactory;
        public StudentTeacherRelationViewComponent(IStudentFactory studentFactory)
        {
            _studentFactory = studentFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? studentId)
        {
            var model = new List<StudentTeacherRelationViewModel>();
            if (studentId == null)
                model = await _studentFactory.StudentTeacherRelation();
            else
                model = await _studentFactory.StudentTeacherRelationByStudentId(Convert.ToInt32(studentId));

            return View("StudentTeacherRelation",model);
        }
    }
}
