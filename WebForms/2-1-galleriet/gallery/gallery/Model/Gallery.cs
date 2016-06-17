using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace gallery.Model
{
    public class Gallery
    {
        static readonly Regex ApprovedExenstions;
        static string PhysicalUploadImagePath;
        static readonly Regex SantizePath;

        static string PhysicalUploadThumbPath;
        string thumbPath = "Content/Thumb/";
        int thumbWidth = 60;
        int thumbHeight = 45;


        static Gallery()
        {
            ApprovedExenstions = new Regex(@"^.*\.(gif|jpg|png)$", RegexOptions.IgnoreCase);

            PhysicalUploadImagePath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), "Content/Img/");

            PhysicalUploadThumbPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), "Content/Thumb/");

            var invalidChars = new string(Path.GetInvalidFileNameChars());
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));
        }

        public IEnumerable<Gallery> GetImagesNames()
        {
            var di = new DirectoryInfo(PhysicalUploadImagePath);
            return (from fi in di.GetFiles()
                    where ApprovedExenstions.IsMatch(fi.Name)
                    select new Gallery
                    {
                        Name = fi.Name,
                        Thumb = thumbPath + fi.Name,
                    }).AsEnumerable();
        }
        public static bool ImageExists(string name)
        {
            return File.Exists(Path.Combine(PhysicalUploadImagePath, name));
        }
        public bool IsValidImage(Image image)
        {
            if(image.RawFormat.Guid == ImageFormat.Gif.Guid ||
               image.RawFormat.Guid == ImageFormat.Jpeg.Guid||
               image.RawFormat.Guid == ImageFormat.Png.Guid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string SaveImage(Stream stream, string fileName)
        {
            var image = System.Drawing.Image.FromStream(stream); // stream -> ström med bild
            if (!IsValidImage(image) || !ApprovedExenstions.IsMatch(fileName))
            {
                throw new ArgumentException("Fil formatet är ogiltligt.");
            }

            SantizePath.Replace(fileName, "");

            // Kolla om filnamnet existerar.
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            int counter = 0;

            while (ImageExists(fileName))
            {
                counter++;
                fileName = string.Format("{0}({1}){2}", nameWithoutExtension, counter, extension);
            }


            var thumbnail = image.GetThumbnailImage(thumbWidth, thumbHeight, null, System.IntPtr.Zero);
            image.Save(PhysicalUploadImagePath + fileName);
            thumbnail.Save(PhysicalUploadThumbPath + fileName); // path -> fullständig fysisk filnamn inklusive sökväg

            return fileName;
        }



        public object Name { get; set; }

        public string Thumb { get; set; }

    }

}



  