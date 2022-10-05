using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Report : BaseEntity
    {
        public string Path { set; get; }
        public string ApiUrl { set; get; }
        public string ReportName { set; get; }
    }
}
