namespace TP2.InventoryManager
{
    using System;
    using System.Collections.Generic;

    public static class InventoryManager
    {
        public static int[,] BuildCostsMatrix(InventoryData inventoryData)
        {
            return CalculateCosts(
                inventoryData.MaxStock,
                inventoryData.HoldingCost,
                inventoryData.OrderCost,
                inventoryData.Demands);
        }

        private static int[,] CalculateCosts(int maxStock, int holdingCost, int orderCost, IList<int> demands)
        {
            int[,] matrix = new int[maxStock + 1, demands.Count];

            // initalize first column (month 1)
            for (int remainingStock = 0; remainingStock <= maxStock; remainingStock++)
            {
                matrix[remainingStock, 0] = orderCost + remainingStock * holdingCost;
            }

            // complete rest of the months
            for (int month = 1; month < demands.Count; month++)
            {
                // the row is the amount we want to keep in stock for next month
                for (int row = 0; row <= maxStock; row++)
                {
                    var buyNow = matrix[0, month - 1] + orderCost + holdingCost * row;

                    // if last month's stock isn't enough, there is no choice but to buy now
                    if (row + demands[month] > maxStock)
                    {
                        matrix[row, month] = buyNow;
                    }
                    else
                    {
                        var dontBuyNow = matrix[row + 1, month - 1] + holdingCost * row;
                        matrix[row, month] = Math.Min(buyNow, dontBuyNow);
                    }
                }
            }
            return matrix;
        }

        public static int[] CalculateOrderQuantities(int[,] costs)
        {
            throw new NotImplementedException();
        }
    }
}
