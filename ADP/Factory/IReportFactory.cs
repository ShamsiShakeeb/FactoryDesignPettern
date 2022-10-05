using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.Factory
{
    public interface IReportFactory : IGenericFactory<Report>
    {
        Task<ReportViewModel> GetReportByPath(string path);
    }
}
