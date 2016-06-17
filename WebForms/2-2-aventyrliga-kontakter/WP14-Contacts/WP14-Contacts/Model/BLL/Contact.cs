using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WP14_Contacts.Model.BLL
{
    public class Contact
    {
        public int ContactID { get  ; set; }


        [Required(ErrorMessage="Epost krävs")]
        [StringLength(50, ErrorMessage="Epost får max vara 50 tecken")]
        [EmailAddress(ErrorMessage = "Invalid Epost.")]
        public string EmailAdress { get; set; }
        [Required(ErrorMessage = "Förnamn krävs")]
        [StringLength(50, ErrorMessage = "Förnam får max vara 50 tecken")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Efternamn krävs")]
        [StringLength(50, ErrorMessage = "Efternamn får max vara 50 tecken")]
        public string LastName { get; set; }
    }
}