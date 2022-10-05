using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADP.ViewComponents
{
    public class ReportViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var url = _httpContextAccessor.HttpContext.Request.Host.Value;
            return await Task.FromResult((IViewComponentResult)View("Report"));
        }
    }
}
