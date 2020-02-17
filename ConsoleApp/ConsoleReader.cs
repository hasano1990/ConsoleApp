using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class ConsoleReader
    {
        public static List<string> ReadUserMultilineInput()
        {
            var data = new List<string>();
            string line;
            while (!"q".Equals((line = Console.ReadLine()), StringComparison.InvariantCultureIgnoreCase))
            {
                data.Add(line);
            }

            return data;
        }
    }
}
