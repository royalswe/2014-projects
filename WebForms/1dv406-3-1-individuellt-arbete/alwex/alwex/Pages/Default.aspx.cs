using alwex.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace alwex.Pages
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

        }

        public IEnumerable<PalletStatement> PsListView_GetData(int maximumRows, int StartRowIndex, out int totalRowCount) // Hämtar pallstansningarna
        {
            try
            {
                return Service.GetPalletStatements(maximumRows, StartRowIndex, out totalRowCount);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då pallstansningarna skulle hämtas.");
                totalRowCount = 0;
                return null;
            }
            
        }

        public void PsListView_DeleteItem(int PsID)// Tabort pallstansning
        {
            try
            {
                Service.DeletePalletStatement(PsID);
                Session["succes"] = "Pallstansningen togs bort";
                Response.Redirect("/Pages/Default.aspx");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "oväntat fel när Pallstansningen skulle tas bort.");
            }
        }

        public void PsListView_InsertItem(PalletStatement palletStatement)// lägg till pallstansning
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SavePalletStatement(palletStatement);
                    Session["succes"] = "pallstansningen sparades";
                    Response.Redirect("/Pages/Default.aspx");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "oväntat fel när pallstansningen skulle Läggas till.");
                }
            }
        }

        public void PsListView_UpdateItem(int PsID)//Redigera pallstansning
        {
            try
            {
                var palletStatement = Service.GetPalletById(PsID);
                if (palletStatement == null)
                {
                    // Om kunden inte hittades
                    ModelState.AddModelError(String.Empty,
                        String.Format("Pallstansningen {0} hittades inte", PsID));
                    return;
                }

                if (TryUpdateModel(palletStatement))
                {
                    Service.SavePalletStatement(palletStatement);
                    Session["succes"] = "Pallstansningen uppdaterades";
                    Response.Redirect("/Pages/Default.aspx");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "oväntat fel när kunden skulle uppdateras");
            }
        } 

    }
}