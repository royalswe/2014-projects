using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymnast
{
    class Program
    {
        static void Main(string[] args)
        {

            Register test = new Register("roy", "Bru11", "roy@hotmail.se");
            Console.WriteLine("Gick registreringen igenom: {0}",test.Registered());


            Secretary score = new Secretary("Roy", 2.8);
            Console.WriteLine(score.ScoreString());
            Console.WriteLine(score.TeamScore());

            Console.WriteLine();
            Console.WriteLine("Skapa aktör");
            TestSecretary.newActor();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Skapa birgitta och ge henne poäng");
            TestRegister.newGymnast();
            Console.WriteLine();

            Console.WriteLine("\nTester av regestrering");
            TestRegister.TestConstructor();
            TestRegister.TestEmail();
            TestRegister.TestConstructor2();
            TestRegister.TestEmptyConstructor();

            Console.WriteLine();
            Console.WriteLine("\nTester av poäng");
            TestSecretary.TestPoints();
            TestSecretary.TestPoints2();
            TestSecretary.TestPoints3();
            //TestSecretary.TestPoints4();
        }

    }
}
