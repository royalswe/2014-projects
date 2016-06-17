using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace alwex.Model.BLL
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [RegularExpression(@"\d+", ErrorMessage = "Kundnummer är inte korrekt.")]
        public int CustomerNUM { get; set; }
        [Required(ErrorMessage = "Namn krävs")]
        [StringLength(25, ErrorMessage = "Namnet får max vara 25 tecken")]
        [RegularExpression(@"^[a-zåäöA-ZÅÄÖ -]+$", ErrorMessage = "Namn är inte korrekt.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ort krävs")]
        [StringLength(25, ErrorMessage = "Orten får max vara 25 tecken")]
        [RegularExpression(@"^[a-zåäöA-ZÅÄÖ -]+$", ErrorMessage = "Ort är inte korrekt.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Postnumer krävs")]
        [RegularExpression(@"^[1-9]\d{2} ?\d{2}", ErrorMessage = "Postnumret är inte av korrekt typ.")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Telefonnummer krävs")]
        [RegularExpression(@"^(\+|0)\d{6,15}", ErrorMessage = "Telefonnumret är inte av korrekt typ.")]
        public string Phone { get; set; }
        
        
    }
}