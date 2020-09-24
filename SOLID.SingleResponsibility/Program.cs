using System;
using static System.Console;

namespace SOLID.SingleResponsibility
{
    public class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I am BATMAN");
            j.AddEntry("I refactored the code.");
            WriteLine(j);

            var p = new Persistence();
            var filename = @"h:\journal.txt";
            p.SaveToFile(j, filename);

            Console.ReadLine();
        }
    }
}
