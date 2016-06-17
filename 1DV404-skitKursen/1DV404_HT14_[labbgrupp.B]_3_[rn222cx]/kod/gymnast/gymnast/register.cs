using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymnast
{
    class Register
    {
        string _username;
        string _password;
        string _email;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
       
        public string Password
        {
            get { return _password; }
            set 
            {
                if (!passValid(value))
                {
                    throw new ArgumentException("Lösenordet ska vara mellan 8-15 tecken samt minst en siffra");
                }
                _password = value; 
            }
        }
        public string Email
        {
            get { return _email; }
            set 
            {
                if (!emailValid(value))
                {
                    throw new ArgumentException("Email är inte valid");
                }
                _email = value; 
            }
        }
        public Register()
        {
 
        }
        public Register(string username, string password, string email) 
        {
            Username = username;
            Password = password;
            Email = email;
        }
        static bool emailValid(string Email)
        {
            //Validering för email
            return Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        static bool passValid(string Password)
        {
            //Minst en bokstav 4-8 tecken.
            return Regex.IsMatch(Password, @"^(?=.*\d).{4,8}$");
        }
        public bool Registered()
        {
            bool register;
            if (Username != "" && Password != "" && Email != "")
            {
                register = true;
            }
            else
            {
                register = false;
            }
            return register;
        }
     
    }
}
