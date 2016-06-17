using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace alwex.Model.BLL
{
    public class Report
    {
        public int ReportID { get; set; }
        public int PsID { get; set; }
        public int CustomerNUM { get; set; }
        public string Name { get; set; }
        public int CustomerDebt { get; set; }

    }
}