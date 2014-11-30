namespace TP2.InventoryManager
{
    using System;
    using System.IO;
    using System.Linq;

    public class InventoryManagerReader
    {
        private const int VARIABLES = 5;

        public InventoryData GetDataFromFile(string path)
        {
            var inventoryData = new InventoryData();

            string[] lines = File.ReadAllLines(path);
            inventoryData.NumberOfPeriods = Convert.ToInt32(lines[0]);

            if (lines.Count() != VARIABLES + inventoryData.NumberOfPeriods)
            {
                throw new Exception("Invalid file format");
            }

            inventoryData.MaxStock = Convert.ToInt32(lines[1]);
            inventoryData.HoldingCost = Convert.ToInt32(lines[2]);
            inventoryData.OrderCost = Convert.ToInt32(lines[3]);

            inventoryData.Demands = new int[inventoryData.NumberOfPeriods];

            for (int i = VARIABLES; i < inventoryData.NumberOfPeriods + VARIABLES; i++)
            {
                inventoryData.Demands[i - VARIABLES] = Convert.ToInt32(lines[i]);
            }

            return inventoryData;
        }
    }
}
