using AutoMapper;
using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.Factory
{
    public class ReportFactory : GenericFactory<Report> , IReportFactory
    {
        private readonly IGenericService<Report> _genericServiceReport;
        private readonly IMapper _mapper;
       
        public ReportFactory(IGenericService<Report> genericServiceReport, IMapper mapper
            ) : base(genericServiceReport, mapper)
        {
            _genericServiceReport = genericServiceReport;
            _mapper = mapper;
        }

        public async Task<ReportViewModel> GetReportByPath(string path)
        {
            var data = await _genericServiceReport.GetEntity(x => x.Path == path);
            var model = _mapper.Map<ReportViewModel>(data);
            return model;
        }


    }
}
