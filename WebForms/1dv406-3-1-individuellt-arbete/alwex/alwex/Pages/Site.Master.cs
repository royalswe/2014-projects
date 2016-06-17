using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace alwex.Pages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // visa rättmeddelanden
            if (Session["succes"] != null)
            {
                SuccesPrompt.Visible = true;
                SuccesText.Text = string.Format(SuccesText.Text, Session["succes"]);
                Session.Remove("succes");
            }
        }

        protected void ErrorImageButton_Click(object sender, ImageClickEventArgs e)
        {
            SuccesPrompt.Visible = false;
        }
    }
}