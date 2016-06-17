using alwex.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace alwex.Pages
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void CustomerFormView_InsertItem(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveContact(customer);
                    Session["succes"] = "Användaren sparades";
                    Response.Redirect("/Pages/AddCustomer.aspx");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "oväntat fel när kunden skulle Läggas till.");
                }
            }
        }
    }
}