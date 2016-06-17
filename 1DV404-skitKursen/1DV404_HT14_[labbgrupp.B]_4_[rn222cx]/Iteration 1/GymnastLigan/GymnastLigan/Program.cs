using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymnastLigan
{
    class Program
    {
        static void Main(string[] args)
        {
            UserRegister person = new UserRegister("roye", "haxx0r", "haxx0r", "roy@lnu.se", "domare", "871131-2739");
            Console.WriteLine(person.Email);
            Console.WriteLine(person.Password);
            person.Registered();

            RegisterTest.Test1();
            RegisterTest.Test2();
            RegisterTest.Test3();
            RegisterTest.Test4();
            RegisterTest.Test5();
            RegisterTest.Test6();
            RegisterTest.Test7();

            


        }
    }
}
