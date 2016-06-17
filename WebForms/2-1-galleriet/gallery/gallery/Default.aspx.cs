using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gallery.Model;

namespace gallery
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var urlQuery = Request.QueryString["name"];
            LargeImage.ImageUrl = String.Format("Content/Img/{0}", urlQuery);

            if (LargeImage.ImageUrl == "Content/Img/")
            {
                LargeImage.ImageUrl = String.Format("Content/Img/welcome.png");
            }

            if (Session["succes"] != null) 
            {
                FileName.Text = string.Format(FileName.Text, Session["succes"]);
                savedImg.Visible = true;
                Session.Remove("succes");
            }
        }

        protected void UpploadButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {               

                try
                {
                    var imgFile = new Gallery().SaveImage(FileUpload.FileContent, FileUpload.FileName);
                    Session["succes"] = imgFile;
                    Response.Redirect("?name=" + imgFile);                    
                }
                catch (Exception ex)
                {
                    StatusField.Visible = true;
                    StatusLabel.Text = ex.Message;                  
                }
                
            }
        }

        public IEnumerable<gallery.Model.Gallery> ImgRepeater_GetData()
        {
            return new Gallery().GetImagesNames();
        }

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            savedImg.Visible = false;
        }
    }
}