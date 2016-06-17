using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymnast
{
    class Secretary
    {
        
        string _name;
        double _score;
        double _teamScore;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public Secretary(string name, double score)
        {
            Name = name;
            Score = score;
        }
        public string  ScoreString() // returnera namn och poäng
        {
            return String.Format("Namn {0}: {1} poäng", _name, _score);
        }
        public string TeamScore() // returnera lagets poäng
        {
            _teamScore += _score;
            return String.Format("Lagets total poäng: {0}:",_teamScore);
        }
    }
}
