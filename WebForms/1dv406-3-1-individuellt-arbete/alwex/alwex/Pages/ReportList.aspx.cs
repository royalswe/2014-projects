using alwex.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace alwex.Pages
{
    public partial class ReportList : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Report> ReportListView_GetData(int maximumRows, int StartRowIndex, out int totalRowCount) // Hämtar raporterna
        {
            try
            {
                return Service.GetReports(maximumRows, StartRowIndex, out totalRowCount);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då Rapporterna skulle hämtas.");
                totalRowCount = 0;
                return null;
            }
        }

    }
}