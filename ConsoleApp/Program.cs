using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter warehouse availiabilities then enter command 'q' to finish input and print report");

            var userInput = ConsoleReader.ReadUserMultilineInput();
            var warehouseAvailability = WarehouseAvailabilityParser.Parse(userInput);
            WarehouseAvailabilityReport.Print(warehouseAvailability);

            Console.ReadKey();
        }
    }
}
