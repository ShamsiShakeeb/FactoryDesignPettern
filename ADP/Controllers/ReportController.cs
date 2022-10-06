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
    [Route("api/Report/[action]")]
    public class ReportController : GenericController<Report, ReportViewModel>
    {
        public ReportController(IGenericFactory<Report> genericFactory) : base(genericFactory)
        {
        }
        public IActionResult ReportList()
        {
            return View();
        }
        public IActionResult DetailsView(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Update(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
