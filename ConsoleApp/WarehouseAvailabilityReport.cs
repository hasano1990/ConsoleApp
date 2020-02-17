using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    static class WarehouseAvailabilityReport
    {
        public static void Print(WarehouseAvailability warehouseAvailability)
        {
            var warehousesData = warehouseAvailability.MaterialAvailabilities.GroupBy(x => x.Warehouse, (warehouse, materialAvailability) => new
            {
                Warehouse = warehouse,
                Total = materialAvailability.Sum(x => x.Quantity),
                Materials = materialAvailability.OrderBy(x => x.MaterialId)
            }).OrderByDescending(x => x.Total).ThenByDescending(x => x.Warehouse);

            foreach (var warehouseData in warehousesData)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine($"{warehouseData.Warehouse}(total {warehouseData.Total})");
                foreach (var materialAvailability in warehouseData.Materials)
                {
                    Console.WriteLine($"{materialAvailability.MaterialId}:{materialAvailability.Quantity}");
                }
            }
        }
    }
}
