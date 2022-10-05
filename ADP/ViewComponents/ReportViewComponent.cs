using ADP.Factory;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.ViewComponents
{
    public class ReportViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IReportFactory _reportFactory;
        public ReportViewComponent(IHttpContextAccessor httpContextAccessor,
            IReportFactory reportFactory
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _reportFactory = reportFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var actionPath = _httpContextAccessor.HttpContext.Request.Path.Value;
            var report = await _reportFactory.GetReportByPath(actionPath);
            return await Task.FromResult((IViewComponentResult)View("Report", report));
        }
    }
}
