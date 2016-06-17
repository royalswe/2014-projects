using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastLigan
{
    class LeagueTest
    {
        public static void Test14()
        {
            var person = new AddLeague("NewLeague");
            try
            {
                UserRegister Roy = new UserRegister("roye", "haxx0r", "haxx0r", "roy@lnu.se", "domare", "871131-2739");
                Roy.AddUser();
                person.AddLeagues();
                Message("Test to create league accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void Test15()
        {
            var person = new AddLeague("NewLeague");
            try
            {
                UserRegister Roy = new UserRegister("roye", "haxx0r", "haxx0r", "roy@lnu.se", "sekreterare", "871131-2739");
                Roy.AddUser();
                person.AddLeagues();
                Message("Test to create league accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void Test16()
        {
            var person = new AddLeague("NewLeague");
            try
            {
                UserRegister Roy = new UserRegister("roye", "haxx0r", "haxx0r", "roy@lnu.se", "sekreterare", "871131-2739");
                Roy.AddUser();
                person.AddMembers();
                Message("Test to create members accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void Test17()
        {
            var person = new AddLeague("NewLeague");
            try
            {
                UserRegister Roy = new UserRegister("roye", "haxx0r", "haxx0r", "roy@lnu.se", "lag ledare", "871131-2727");
                Roy.AddUser();
                person.AddLeagues();
                Message("Test to create league accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void Test18()
        {
            var person = new AddLeague("NewLeague");
            try
            {
                UserRegister Roy = new UserRegister("roye", "haxx0r", "haxx0r", "roy@lnu.se", "lag ledare", "871131-2739");
                Roy.AddUser();
                person.AddMembers();
                Message("Test to create league accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
        }
        public static void Test19()
        {
            var person = new AddLeague("NewLeague");
            try
            {
                UserRegister Roy = new UserRegister("roye", "haxx0r", "haxx0r", "roy@lnu.se", "lag ledare", "871131-2739");
                Roy.AddUser();
                person.AddLeagues();
                person.AddMembers();
                Message("Test to create league accepted value, succeeded", false);
            }
            catch (Exception)
            { Message("Test misslyckades", true); }
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
