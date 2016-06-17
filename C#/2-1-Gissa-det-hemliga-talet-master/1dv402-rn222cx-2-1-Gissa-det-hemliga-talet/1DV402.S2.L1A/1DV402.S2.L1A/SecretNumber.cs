using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    class SecretNumber
    {
        //Deklarera fält enligt labb 2-1
        int _count;
        int _number;
        public const int MaxNumberOfGuesses = 7;

        public SecretNumber()
        {
            Initialize();
        }
        public void Initialize()
        {
            //Ger _number ett slumpvist nummer
            _number = new Random().Next(1, 101); 
            _count = 0;
        }

        public bool MakeGuess(int number)
        {
            
           if(number < 1 || number > 100)
           {
               //Är det gissade talet inte i det slutna intervallet mellan 1 och 100 ska ett undantag kastas.
               throw new ArgumentOutOfRangeException();
            }
            if(_count < 7)
            {
                //_count ökas eftrer varje gissning och kommer fortsätta i if blocket 7 gånger, om inte rätt nummer gissas då true returneras.
                _count++;
                if (number == _number)
                {
                    Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försöket", _count);
                    return true;
                }
                else if (number < _number)
                { 
                    Console.WriteLine("{0} är för lågt. Du har {1} gisningar kvar.", number, 7 - _count);
                }
                else if (number > _number)
                { 
                    Console.WriteLine("{0} är för högt. Du har {1} gisningar kvar.", number, 7 - _count);
                }
                if (_count == 7)
                {
                    Console.WriteLine("Det hemliga talet är {0}", _number);
                }
                return false;
           }
           else
           {
                //Görs ytterligare försök utöver de stipulerade sju ska ett undantag kastas.
               throw new ApplicationException();
           }
            
        }
  
    }
}
