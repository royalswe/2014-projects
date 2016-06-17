using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WP14_Contacts.Model;
using WP14_Contacts.Model.BLL;

namespace WP14_Contacts
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

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


        public IEnumerable<Contact> ContactListView_GetData(int maximumRows, int StartRowIndex, out int totalRowCount)
        {
            try
            {
                return Service.GetContactsPageWise(maximumRows, StartRowIndex, out totalRowCount);
            }
            catch (Exception)
            {                
                ModelState.AddModelError(String.Empty, "oväntat fel vid hämtning av kund.");
                totalRowCount = 0;
                return null;
            }
        }

        public void ContactListView_DeleteItem(int ContactID)
        {
            try
            {
                Service.DeleteContact(ContactID);
                Session["succes"] = "Användaren togs bort";
                Response.Redirect("/Default.aspx");
            }
            catch (Exception)
            {           
                ModelState.AddModelError(String.Empty, "oväntat fel när kunden skulle tas bort.");
            }
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveContact(contact);
                    Session["succes"] = "Användaren lades till";
                    Response.Redirect("/Default.aspx");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "oväntat fel när kunden skulle Läggas till.");
                }
            }
        }

        public void ContactListView_UpdateItem(int contactId)
        {
            try 
            { 
                var contact = Service.GetContact(contactId);
                if (contact == null)
                {
                    // Om kunden inte hittades
                    ModelState.AddModelError(String.Empty,
                        String.Format("Kunden {0} hittades inte", contactId));
                    return;
                }

                if (TryUpdateModel(contact))
                {
                    Service.SaveContact(contact);
                    Session["succes"] = "Användaren uppdaterades";
                    Response.Redirect("/Default.aspx");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "oväntat fel när kunden skulle uppdateras");
            }
        }

        protected void ErrorImageButton_Click(object sender, ImageClickEventArgs e)
        {
            SuccesPrompt.Visible = false;
        }
    }
}