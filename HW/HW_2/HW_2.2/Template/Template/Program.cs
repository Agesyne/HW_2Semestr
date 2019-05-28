using System;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Structures.HashMap();
            map.Add(0);
            map.Add(4);
            map.Add(3);
            map.Add(1);
            map.Add(2);
            Console.WriteLine(map.Exist(4));
            Console.WriteLine(map.Exist(0));
            Console.WriteLine(map.Exist(1));
            Console.WriteLine(map.Exist(-1));
            Console.WriteLine(map.Exist(5));
            Console.WriteLine(map.Exist(16));
            Console.WriteLine(map.Exist(14));
            Console.WriteLine();
            map.Delete(4);
            map.Delete(1);
            map.Delete(0);
            Console.WriteLine(map.Exist(4));
            Console.WriteLine(map.Exist(1));
            Console.WriteLine(map.Exist(0));
            Console.ReadKey();

        }
    }
}
