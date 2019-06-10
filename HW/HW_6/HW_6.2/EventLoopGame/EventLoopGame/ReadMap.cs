using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EventLoopGame
{
    public static class ReadMap
    {
        public static string[,] ReadMap(string fileName)
        {
            try
            {
                StreamReader sr = new StreamReader(fileName);

                int counter = 0;
                string line = sr.ReadLine();
                while (line != null)
                {

                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
