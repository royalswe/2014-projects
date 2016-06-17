using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Versaler.Model;

namespace Versaler
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            //TextBox.CssClass = ".textarea";
            int numOfUppercase = TextAnalyzer.GetNumberOfCapitals(TextBox.Text);
            Result.Text = String.Format(Result.Text, numOfUppercase);

            TextBox.Enabled = false;
            PlaceHolder1.Visible = true; // Visa texten antal versaler
            SendButton.Visible = false;
        }
    }
}