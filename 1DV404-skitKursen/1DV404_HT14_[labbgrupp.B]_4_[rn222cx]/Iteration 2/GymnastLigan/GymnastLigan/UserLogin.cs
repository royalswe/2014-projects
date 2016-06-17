using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastLigan
{
    class UserLogin
    {

        string _loginName;
        string _loginPassword;

        public string LoginName
        {
            get { return _loginName; }
            set 
            {
                if (value == "")
                {
                    throw new ArgumentException("Loginnamnet får inte lämnas tomt");
                }

               _loginName = value; 
            }
        }
        public string LoginPassword
        {
            get { return _loginPassword; }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Lösenordet får inte lämnas tomt");
                }

                _loginPassword = value;
            }
        }
        public void Login(string userEmail, string password)
        {
            using (StreamReader sr = new StreamReader("users.txt"))
            {
                userEmail = userEmail.ToLower();
                LoginName = sr.ReadLine();
                LoginPassword = sr.ReadLine();
                sr.Close();

                if (LoginName == userEmail && LoginPassword == password)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Innloggning lyckades! ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Innloggning misslyckades! ");
                }

                Console.ResetColor();
            }

        }
    }
}
