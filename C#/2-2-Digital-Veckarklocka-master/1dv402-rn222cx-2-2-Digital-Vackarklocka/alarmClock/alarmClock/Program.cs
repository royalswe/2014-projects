using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alarmClock
{
    class Program
    {
        static void Main(string[] args)
        {

            ViewTestHeader("Test 1\nTest av standardkonstruktor.");
            AlarmClock time = new AlarmClock();
            Console.WriteLine(time.ToString());

            ViewTestHeader("Test 2\nTest av konstruktorn med två parametrar.");
            AlarmClock time2 = new AlarmClock(9, 42);
            Console.WriteLine(time2.ToString());

            ViewTestHeader("Test 3\nTest av konstruktorn med fyra parametrar");
            AlarmClock time3 = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(time3.ToString());

            ViewTestHeader("Test 4\nTest av metoden TickTock() som ska låta klockan gå en minut. ");
            time3.Hour = 23;
            time3.Minute = 58;
            Run(time3, 13);

            ViewTestHeader("Test 5\nStäller befintligt AlarmClock-objekt till tiden 6:12 och alarmtiden till 6:15 och låter den gå 6 minuter.");
            AlarmClock time5 = new AlarmClock(6, 12, 6, 15);
            Run(time5, 13);

            ViewTestHeader("Test 6\nTest av egenskaperna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.");
            AlarmClock time6 = new AlarmClock();
            try
            {
                time6.Hour = 24;
            }
            catch (ArgumentException m)
            {
                ViewErrorMessage(m.Message);
            }
            try
            {
                time6.Minute = 60;
            }
            catch (ArgumentException m)
            {
                ViewErrorMessage(m.Message);
            }
            try
            {
                time6.AlarmHour = -1;
            }
            catch (ArgumentException m)
            {
                ViewErrorMessage(m.Message);
            }
            try
            {
                time6.AlarmMinute = -1;
            }
            catch (ArgumentException m)
            {
                ViewErrorMessage(m.Message);
            }

            ViewTestHeader("Test 7\nTest av konstruktorer så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.");
            try
            { 
                AlarmClock time7Constructor = new AlarmClock(24, 0); 
            }
            catch (ArgumentException m)
            { 
                ViewErrorMessage(m.Message); 
            }
            try
            {
                AlarmClock time7Constructor = new AlarmClock(0, 0, 24, 0); 
            }
            catch (ArgumentException m)
            { 
                ViewErrorMessage(m.Message); 
            } 


        }

        private static string HorizontalLine = "════════════════════════════════════════════════════════════════════════════════";
        private static void Run(AlarmClock ac, int minutes)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" ╔══════════════════════════════════════╗ ");
            Console.WriteLine(" ║      Väckarkloclan URLED <TM>        ║ ");
            Console.WriteLine(" ║       modellnr: 1DV402S2L2A          ║ ");
            Console.WriteLine(" ╚══════════════════════════════════════╝ ");
            Console.ResetColor();
            Console.WriteLine();
           
            for (int i = 0; i < minutes; i++)
            {
                 //Kör metoden TickTock, om värdet är true returneras strängen BEEP!
                if (ac.TickTock() == true)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0}\t BEEP! BEEP! BEEP! BEEP!", ac.ToString());
                    Console.ResetColor();
                }
                else
                {
                //Skriver ut tiden
                Console.WriteLine(ac.ToString());
                }
            }

        }


        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void ViewTestHeader(string header)
        {
            //Istället för console.writeLine ?
            Console.WriteLine(HorizontalLine + header);
        }


        
    }
}
