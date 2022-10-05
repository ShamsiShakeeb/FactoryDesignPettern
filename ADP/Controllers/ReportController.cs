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
    public class ReportController : GenericController<Report, ReportViewModel>
    {
        public ReportController(IGenericFactory<Report> genericFactory) : base(genericFactory)
        {
        }
        public IActionResult ReportList()
        {
            return View();
        }
    }
}
