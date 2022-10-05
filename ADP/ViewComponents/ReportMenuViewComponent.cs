using ADP.Factory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.ViewComponents
{
    public class ReportMenuViewComponent : ViewComponent
    {
        private readonly IReportFactory _reportFactory;
        public ReportMenuViewComponent(IReportFactory reportFactory)
        {
            _reportFactory = reportFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _reportFactory.Get<ReportViewModel>();
            return View("ReportMenu", list);
        }
    }
}
