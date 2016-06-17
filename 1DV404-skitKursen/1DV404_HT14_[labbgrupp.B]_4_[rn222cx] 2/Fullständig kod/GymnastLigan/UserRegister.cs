using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastLigan
{
    class UserRegister
    {

        string _fullName;
        string _password;
        string _password2;
        string _email;
        string _actor;
        string _pin;


        public string Fullname
        {
            get { return _fullName; }
            set 
            {
                if (value.Length < 4 || value.Length > 25)
                {
                    throw new ArgumentException("Namnet får inte vara mindre än 4 tecken eller högre än 25.");
                }

                _fullName = value; 
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (!PasswordIsValid(value))
                {
                    throw new ArgumentException("Lösenordet måste vara mellan 6-20 tecken samt minst en siffra");
                }

                _password = value;
            }
        }
        public string Password2
        {
            get { return _password2; }
            set
            {
                if (Password != value)
                {
                    throw new ArgumentException("Lösenorden måste vara identiska");
                }

                _password2 = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set 
            {
                if (!EmailIsValid(value))
                {
                    throw new ArgumentException("Mailen är inte giltlig");
                }

                _email = value;
            }
        }
        public string Actor
        {
            get { return _actor; }
            set
            {
                if (value == "lag ledare")
                {
                    _actor = value;
                }
                else if (value == "sekreterare")
                {
                    _actor = value;
                }
                else if (value == "domare")
                {
                    _actor = value;
                }
                else
                {
                    throw new ArgumentException("Inte giltlig aktör");
                }
            }
        }
        public string Pin
        {
            get { return _pin; }
            set
            {
                if (!PinIsValid(value))
                {
                    throw new ArgumentException("Pin är inte giltlig");
                }

                _pin = value;
            }
        }
        public UserRegister()
        {

        }
        public UserRegister(string fullname, string password, string password2, string email, string actor, string pin)
        {
            Fullname = fullname;
            Password = password;
            Password2 = password2;
            Email = email.ToLower();
            Actor = actor.ToLower();
            Pin = pin;
        }

        static bool PasswordIsValid(string Password)
        {
            return Regex.IsMatch(Password, @"^(?=.*\d).{6,25}$");
        }
        static bool EmailIsValid(string Email)
        {
            return Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        static bool PinIsValid(string Pin)
        {
            return Regex.IsMatch(Pin, @"^(\d{2})(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])-(\d{4})$");
        }
        public void AddUser()
        {
            using (StreamWriter sw = new StreamWriter("users.txt"))
            {
                sw.Write(Email + "\r\n" + Password + "\r\n" + Fullname + "\r\n" + Actor + "\r\n" + Pin);
                sw.Close();
                Console.WriteLine("user added");
            }
            using (StreamWriter sw = new StreamWriter("league.txt"))
            {
                sw.WriteLine("Behörighet: " + Actor);
                sw.Close();
            }
        }
        public bool Registered()
        {
            bool register;
            if (Pin != "")
            {
                AddUser();
                register = true;
            }
            else
            {
                register = false;
            }
            return register;
        }

        //Små simpla konstruktorer för att testa koderna lite kvickt
 
        //public UserRegister(string fullname)
        //{
        //    Fullname = fullname;
        //}
        //public UserRegister(string password)
        //{
        //    Password = password;
        //}
        //public UserRegister(string email)
        //{
        //    Email = email;
        //}
        //public UserRegister(string actor)
        //{
        //    Actor = actor.ToLower();   
        //}
        //public UserRegister(string pin)
        //{
        //    Pin = pin;
        //}
        
    }
}
