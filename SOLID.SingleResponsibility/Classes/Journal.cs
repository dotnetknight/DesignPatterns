using System;
using System.Collections.Generic;
using System.IO;

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
}
