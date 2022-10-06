using ADP.Factory;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IReportFactory _reportFactory;
        public ReportMenuViewComponent(IReportFactory reportFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _reportFactory = reportFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var actionPath = _httpContextAccessor.HttpContext.Request.Path.Value;
            var list = new List<ReportViewModel>();
            if(actionPath.Equals("/api/Report/ReportList"))
                list = await _reportFactory.Get<ReportViewModel>();
            else
                list = await _reportFactory.Get<ReportViewModel>(x=> x.Path==actionPath);
            return View("ReportMenu", list);
        }
    }
}
