using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class WarehouseAvailability
    {
        public WarehouseAvailability()
        {
            Materials = new List<Material>();
            MaterialAvailabilities = new List<MaterialAvailability>();
        }

        public List<Material> Materials { get; private set; }
        public List<MaterialAvailability> MaterialAvailabilities { get; private set; }
    }


    public class Material
    {
        public Material(string name, string id)
        {
            Name = name;
            Id = id;
        }
        public string Name { get; private set; }
        public string Id { get; private set; }

    }

    public class MaterialAvailability
    {
        public MaterialAvailability(string materialId, string warehouse, long quantity)
        {
            MaterialId = materialId;
            Warehouse = warehouse;
            Quantity = quantity;
        }

        public string MaterialId { get; private set; }
        public string Warehouse { get; private set; }
        public long Quantity { get; private set; }
    }
}
