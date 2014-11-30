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
            inventoryData.Months = Convert.ToInt32(lines[0]);

            if (lines.Count() != VARIABLES + inventoryData.Months)
            {
                throw new Exception("Invalid file format");
            }

            inventoryData.MaxStock = Convert.ToInt32(lines[1]);
            inventoryData.HoldingCost = Convert.ToInt32(lines[2]);
            inventoryData.OrderCost = Convert.ToInt32(lines[3]);

            inventoryData.MonthlyDemand = new int[inventoryData.Months];

            for (int i = VARIABLES; i < inventoryData.Months + VARIABLES; i++)
            {
                inventoryData.MonthlyDemand[i - VARIABLES] = Convert.ToInt32(lines[i]);
            }

            return inventoryData;
        }
    }
}
