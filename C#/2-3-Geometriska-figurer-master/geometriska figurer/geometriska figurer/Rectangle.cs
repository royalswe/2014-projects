using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriska_figurer
{
    class Rectangle : Shape
    {
        public override double Area
        {
            //Beräkna arean på en rektangel
            get { return Length * Width; }
        }

        public override double Perimeter
        {
            //Beräkna omkrets på en rektangel
            get { return 2 * Length + 2 * Width; }
        }

        public Rectangle(double length, double width)
            :base (length, width)
        {
        }
    }
}
