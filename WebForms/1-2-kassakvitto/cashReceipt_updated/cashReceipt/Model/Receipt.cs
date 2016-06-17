using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cashReceipt.Model
{
    public class Receipt
    {
        double _subtotal;

        public double DiscountRate { get; private set; } //rabatten i procent
        public double MoneyOff { get; private set; } //rabatten i kronor
        public double Total { get; private set; } //beloppet efter att rabatten dragits från den totala köpesumman

   
        public double Subtotal
        {
            get { return _subtotal; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Talet måste vara större än 0");
                }

                _subtotal = value;
            }
        }

        public Receipt(double subtotal)
        {
            Calculate(subtotal);
        }

        public void Calculate(double subtotal)
        {
            Subtotal = subtotal;
            
            if (subtotal < 500)
            {
                DiscountRate = 0;
            }
            else if (Subtotal < 1000)
            {
                DiscountRate = 0.05;
            }
            else if (Subtotal < 5000)
            {
                DiscountRate = 0.10;
            }
            else
            {
                DiscountRate = 0.15;
            }


            MoneyOff = subtotal * DiscountRate;
            Total = subtotal - MoneyOff;
          
        }
        public override string ToString() // returnera i text
        {
            return String.Format("Totalt <span id='countSpan'>{0:c}</span><br />Rabattsats <span id='countSpan'>{1:p0}</span><br />Rabatt <span id='countSpan'>{2:c}</span><br />Att betala <span id='countSpan'>{3:c}</span>", Subtotal, DiscountRate, MoneyOff, Total);
        }
    
    }
}