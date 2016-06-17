using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymnast
{
    class TestSecretary
    {

        public static void TestPoints()
        {
            try
            {
                var secretary = new Secretary("Roy", 5);
                Message("Test lyckadades!", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void TestPoints2()
        {
            try
            {
                var secretary2 = new Secretary("Roy Lnu", 10.4);
                Message("Test lyckadades!", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void TestPoints3()
        {
            try
            {
                var secretary3 = new Secretary("", 0);
                Message("Test lyckadades!", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void newActor()
        {
            Register reg = new Register("Berit", "pa55word", "ber@lnu.se");
            Console.Write("Namn: {0} Lösen: {1} email:{2}", reg.Username, reg.Password, reg.Email);
        }
        //public static void TestPoints4()
        //{
        //    try
        //    {
        //        var secretary4 = new Secretary(0, "lnu");
        //        Message("Test lyckadades!", false);
        //    }
        //    catch (Exception)
        //    { Message("Test misslyckades", true); }
        //}
        static void Message(string message, bool Error)
        {
            if (Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
