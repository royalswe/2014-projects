using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastLigan
{
    class LoginTest
    {
        public static void Test8()
        {
            UserLogin roy = new UserLogin();
            try
            {
                roy.Login("roy@lnu.se", "haxx0r");
                Message("Test to login accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void Test9()
        {
            UserLogin roy = new UserLogin();

                roy.Login("roye", "haxx0r");
        }
        public static void Test10()
        {
            UserLogin roy = new UserLogin();

            roy.Login("roy@lnu.se", "password");
        }
        public static void Test11()
        {
            UserLogin roy = new UserLogin();

            roy.Login("roy@lnu.se", "Haxx0r");
        }
        public static void Test12()
        {
            UserLogin roy = new UserLogin();

            roy.Login("Roy@lnu.se", "haxx0r");
        }
        public static void Test13()
        {
            UserLogin roy = new UserLogin();

            roy.Login("", "");
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
