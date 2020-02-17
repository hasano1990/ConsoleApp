using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    static class WarehouseAvailabilityParser
    {
        public static WarehouseAvailability Parse(List<string> data)
        {
            var result = new WarehouseAvailability();

            for (var i = 0; i < data.Count; ++i)
            {
                if (string.IsNullOrWhiteSpace(data[i]) || data[i].StartsWith("#", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                var splittedData = data[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (splittedData.Length < 3)
                {
                    continue;
                }

                result.Materials.Add(new Material(splittedData[0], splittedData[1]));
                result.MaterialAvailabilities.AddRange(ParseMaterialAvailability(splittedData[1], splittedData[2]));
            }


            return result;
        }

        public static List<MaterialAvailability> ParseMaterialAvailability(string materialId, string data)
        {
            var result = new List<MaterialAvailability>();
            var materialsAvailabilityData = data.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < materialsAvailabilityData.Length; ++i)
            {
                var singleMaterialAvailabilityData = materialsAvailabilityData[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (singleMaterialAvailabilityData.Length != 2 || !Int64.TryParse(singleMaterialAvailabilityData[1], out var quantity))
                {
                    continue;
                }

                result.Add(new MaterialAvailability(materialId, singleMaterialAvailabilityData[0], quantity));
            }

            return result;
        }
    }
}
