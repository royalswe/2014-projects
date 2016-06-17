using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cashReceipt.Model;

namespace cashReceipt
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InputBox.Focus();
        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Visa kvittot
                PlaceHolder.Visible = true;

                Receipt input = new Receipt(Convert.ToDouble(InputBox.Text));
                CalculatedReceipt.Text = String.Format(CalculatedReceipt.Text, input.ToString());

            }

        }
    }
}