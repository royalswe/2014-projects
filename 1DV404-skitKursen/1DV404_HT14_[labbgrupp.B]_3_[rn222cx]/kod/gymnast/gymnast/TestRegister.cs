using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymnast
{
    class TestRegister
    {
        public static void TestConstructor()
        {
            try
            {
                var person = new Register("Åke", "pass12", "roy.lnu.se");
                Message("Test lyckadades!", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void TestEmail()
        {
            var person2 = new Register();
            try
            {
                person2.Email = "roy@hotmail.com";
                Message("Test to set Email to accepted value succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void TestConstructor2()
        {
            try
            {
                var person3 = new Register("Roy", "Brun1", "roy@lnu.se");
                Message("Test lyckadades!", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void TestEmptyConstructor()
        {
            try
            {
                var person4 = new Register("", "", "");
                Message("Test lyckadades!", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void newGymnast()
        {
            Secretary sec = new Secretary("Birgitta", 4.0);
            Console.Write("{0}: {1} poäng",sec.Name, sec.Score);
        }
        
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
