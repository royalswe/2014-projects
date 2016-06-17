using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriska_figurer
{
    enum ShapeType { Ellipse = 1, Rectangle = 2 }
    abstract class Shape
    {
        const int minNumber = 1;
        double _length;
        double _width;

        abstract public double Area { get; }

        public double Length
        {
            get { return _length; }
            set {
                    if (value < minNumber)
                    {
                        throw new ArgumentException();
                    }
                                
                    _length = value; }
        }

        abstract public double Perimeter
        {
            get;
        }

        public double Width
        {
            get { return _width; }
            set
            {
                if (value < minNumber)
                {
                    throw new ArgumentException();
                }

                _width = value;
            }
        }

        protected Shape(double length, double width)
        {
            Length = length;
            Width = width;
        }

        //public Shape()
        //{
        //    // TODO: Complete member initialization
        //}

        public override string ToString()
        {
            return string.Format("Längd  : {0,15}\nBredd  : {1,15}\nOmkrets: {2,15:f2}\nArea   : {3,15:f2}", Length, Width, Perimeter, Area);  
        }
    }
}
