using ADP.Factory;
using BLL;
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
        private readonly IGenericFactory<Report> _genericFactory;
        public ReportController(IGenericFactory<Report> genericFactory
            ) : base(genericFactory)
        {
            _genericFactory = genericFactory;
        }
        public IActionResult ReportList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _genericFactory.Get<ReportViewModel>();
            return View (list);
        }

        [HttpGet]
        public  IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public override async  Task<IActionResult> Insert(ReportViewModel model)
        {
            var value = await _genericFactory.Insert(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        
        public override async Task<IActionResult> Delete(int id)
        {
           await _genericFactory.Delete(id);
            return RedirectToAction("Index");
        }
        public  async Task<IActionResult> Update(int id)
        {
            var value = await _genericFactory.DetailsById<ReportViewModel>(id);
            return View(value);
        }
        public override async Task<IActionResult> Update(int id, ReportViewModel model)
        {
            var value = await _genericFactory.Update(id, model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public override async Task<IActionResult> Details(int id)
        {
            var data = await _genericFactory.DetailsById<ReportViewModel>(id);
            return View(data);
        }
    }
}
