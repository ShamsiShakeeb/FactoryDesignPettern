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
        private readonly IMapper _mapper;
        public ReportViewComponent(IHttpContextAccessor httpContextAccessor,
            IReportFactory reportFactory,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _reportFactory = reportFactory;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var actionPath = _httpContextAccessor.HttpContext.Request.Path.Value;
            var report = await _reportFactory.GetReportByPath(actionPath);
            var model = _mapper.Map<ReportViewModel>(report);
            return await Task.FromResult((IViewComponentResult)View("Report", model));
        }
    }
}
