using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriska_figurer
{
    class Ellipse : Shape
    {
        public override double Area
        {
            //Beräkna en ellipse area
            get { return Math.PI * (Length / 2) * (Width / 2); }
        }

        public override double Perimeter
        {   
            //Beräkna en ellipse omkrets
            get { return Math.PI * Math.Sqrt(2 * (Length / 2) * (Length / 2) + 2 * (Width / 2) * (Width / 2)); }
        }

        public Ellipse(double length, double width)
            :base (length, width)
        {
        }
    }
}
