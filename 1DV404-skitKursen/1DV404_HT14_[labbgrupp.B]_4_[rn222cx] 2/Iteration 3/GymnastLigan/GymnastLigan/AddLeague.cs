using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastLigan
{
    class AddLeague
    {
        string _league;

        public string League
        {
            get{ return _league; }
            set{ _league = value; }
        }

        public AddLeague(string league)
        {
            League = league;
        }
        public void AddLeagues()
        {
            using (StreamReader sr = new StreamReader("league.txt"))
            {
                string contents = sr.ReadToEnd();
                if (!contents.Contains("lag ledare"))
                {
                    throw new ArgumentException("Du har inte behörighet");
                }
            }
            using (StreamWriter sw = new StreamWriter("league.txt", true))
            {
                sw.WriteLine("Liga: " + League);
                sw.Close();
                Console.WriteLine("League added");
            }
        }
        public void AddMembers()
        {
            using (StreamReader sr = new StreamReader("league.txt"))
            {
                string contents = sr.ReadToEnd();
                if (!contents.Contains("lag ledare"))
                {
                    throw new ArgumentException("Du har inte behörighet");
                }
            }
            using (StreamWriter sw = new StreamWriter("league.txt", true))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Skriv in medlemmar, avslutar med esc");
                Console.ResetColor();
                 do
                {
                string names = Console.ReadLine();
                sw.WriteLine("Namn: " + names);
                Console.WriteLine("user added");
                }
                 while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        }

    }
}
