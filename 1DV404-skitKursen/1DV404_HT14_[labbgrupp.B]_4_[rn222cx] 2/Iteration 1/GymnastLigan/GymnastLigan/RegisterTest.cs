using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastLigan
{
    class RegisterTest
    {
        public static void Test1()
        {
            try
            {
                var person = new UserRegister("roye", "haxx0r", "haxx0r", "roy@lnu.se", "lAg LeDaRE", "871131-2739");
                person.Registered();
                Message("Test lyckadades!", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void Test2()
        {
            var person2 = new UserRegister();
            try
            {
                person2.Fullname = "roy";
                Message("Test to set name to accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }

        public static void Test3()
        {
            var person = new UserRegister();
            try
            {
                person.Password = "haxxor";
                Message("Test to set password to accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void Test4()
        {
            var person = new UserRegister();
            try
            {
                person.Email = "roy.87@msn.com";
                Message("Test to set email to accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void Test5()
        {
            var person = new UserRegister();
            try
            {
                person.Actor = "domare";
                Message("Test to set actor to accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void Test6()
        {
            var person = new UserRegister();
            try
            {
                person.Pin = "871331-2739";
                Message("Test to set personal identification number to accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void Test7()
        {
            var person = new UserRegister();
            try
            {
                person.Password2 = "hej";
                Message("Test to set repeat password to accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }



        public static void newGymnast()
        {
            //Secretary sec = new Secretary("Birgitta", 4.0);
            //Console.Write("{0}: {1} poäng", sec.Name, sec.Score);
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
