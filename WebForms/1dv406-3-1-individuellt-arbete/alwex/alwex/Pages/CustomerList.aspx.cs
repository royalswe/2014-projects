using alwex.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace alwex.Pages
{
    public partial class CustomerList : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Customer> CustomerListView_GetData()
        {
            try
            {
                return Service.GetCustomers();
            }            
            catch
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då kunderna skulle hämtas.");
                return null;
            }
        }

        public void CustomerListView_DeleteItem(int CustomerID)
        {
            try
            {
                Service.DeleteCustomer(CustomerID);
                Session["succes"] = "Kunden togs bort";
                Response.Redirect("/Pages/CustomerList.aspx");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "oväntat fel när kunden skulle tas bort.");
            }
        }

        public void CustomerListView_UpdateItem(int customerID)
        {
            try
            {
                var customer = Service.GetCustomersById(customerID);
                if (customer == null)
                {
                    // Om kunden inte hittades
                    ModelState.AddModelError(String.Empty,
                        String.Format("Kunden {0} hittades inte", customerID));
                    return;
                }

                if (TryUpdateModel(customer))
                {
                    Service.SaveContact(customer);
                    Session["succes"] = "Användaren uppdaterades";
                    Response.Redirect("/Pages/CustomerList.aspx");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "oväntat fel när kunden skulle uppdateras");
            }
        }

    }
}