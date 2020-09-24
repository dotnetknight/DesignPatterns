using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace SOLID.SingleResponsibility
{
    // stores a couple of journal entries and ways of working with them
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // breaks single responsibility principle, because the requirement came to save a journal
        //so typically would add that responsibility to the existing class which would obviously break the SRP. Instead of adding that
        //responsibility to Journal class, we can create a new class to handle that requirement.
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllText(filename, ToString());
        }

        public void Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }
    }

    // handles the responsibility of persisting objects
    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }

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
