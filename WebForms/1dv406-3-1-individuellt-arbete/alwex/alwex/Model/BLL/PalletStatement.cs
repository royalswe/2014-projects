using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace alwex.Model.BLL
{
    public class PalletStatement
    {
        public int PsID { get; set; }

        [Required(ErrorMessage = "Kundnummer krävs")]
        public int CustomerNUM { get; set; }
        [Required(ErrorMessage = "Utgående datum krävs")]
        [RegularExpression(@"(20)?\d\d[- /.:](0[1-9]|1[012])[- /.:](0[1-9]|[12]\d|3[01])([- /.:]([01]?[0-9]|2[0-3])[- /.:][0-5][0-9])?([- /.:][0-5][0-9])?", ErrorMessage = "Ut datum är i fel format")]
        public DateTime OutDate { get; set; }
        [Required(ErrorMessage = "Ingående datum krävs")]
        [RegularExpression(@"(20)?\d\d[- /.:](0[1-9]|1[012])[- /.:](0[1-9]|[12]\d|3[01])([- /.:]([01]?[0-9]|2[0-3])[- /.:][0-5][0-9])?([- /.:][0-5][0-9])?", ErrorMessage = "In datum är i fel format")]
        public DateTime InDate { get; set; }
        [Required(ErrorMessage = "A pallar krävs")]
        public int Apallet { get; set; }
        [Required(ErrorMessage = "B pallar krävs")]
        public int Bpallet { get; set; }
        [Required(ErrorMessage = "Utgående A pallar krävs")]
        public int ApalletOUT { get; set; }

    }
}
