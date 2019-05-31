using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet set = new SortedSet();
            FileStream file = null;
            StreamReader reader = null;
            try
            {
                file = new FileStream("input.txt", FileMode.Open, FileAccess.Read);
                reader = new StreamReader(file);

                while (!reader.EndOfStream)
                {
                    List<string> newList = new List<string>();
                    string newString = reader.ReadLine();
                    string[] wordArray = newString.Split(' ');
                    foreach (var i in wordArray)
                    {
                        newList.Add(i);
                    }
                    set.Insert(newList);
                }

                set.PrintAll();
                Console.Read();
            }
            finally
            {
                reader?.Close();
                file?.Close();
            }
            
        }
    }
}
