using ADP.Factory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.ViewComponents
{
    public class ReportDetailsViewComponent :ViewComponent
    {
        private readonly IReportFactory _reportFactory;
        public ReportDetailsViewComponent(IReportFactory reportFactory)
        {
            _reportFactory = reportFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var model = new ReportViewModel();
            model.Id = id;
            return await Task.FromResult((IViewComponentResult)View("ReportDetailsViewComponent", model));
        }
    }
}
