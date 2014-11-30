namespace TP2.InventoryManager
{
    using System;
    using System.Collections.Generic;

    public static class InventoryManager
    {
        public static int[] CalculateOrderQuantities(InventoryData inventoryData)
        {
            Purchase[,] matrix = GetPurchaseData(
                inventoryData.MaxStock,
                inventoryData.HoldingCost,
                inventoryData.OrderCost,
                inventoryData.MonthlyDemand);

            int[] orderQuantities = new int[inventoryData.Months];

            // Start from the last month and work backwards.
            // Take the first row because we're not allowed to keep stock
            // after the last month
            Purchase currentMonthPurchase = matrix[0, inventoryData.Months - 1];

            int currentMonth = inventoryData.Months - 1;

            while (currentMonth >= 0)
            {
                orderQuantities[currentMonth] = currentMonthPurchase.Size;
                if (currentMonth == 0)
                {
                    break;
                }
                currentMonthPurchase = matrix[currentMonthPurchase.StockFromLastMonth, currentMonth - 1];
                currentMonth--;
            }

            return orderQuantities;
        }

        public static Purchase[,] GetPurchaseData(int maxStock, int holdingCost, int orderCost, IList<int> demands)
        {
            Purchase[,] matrix = new Purchase[maxStock + 1, demands.Count];

            // initalize first column (month 1)
            for (int row = 0; row <= maxStock; row++)
            {
                matrix[row, 0] = new Purchase
                {
                    Cost = orderCost + row * holdingCost,
                    StockFromLastMonth = -1,
                    Size = demands[0] + row
                };
            }

            // complete rest of the months
            for (int month = 1; month < demands.Count; month++)
            {
                // the row is the amount we want to keep in stock for next month
                for (int row = 0; row <= maxStock; row++)
                {
                    int parentRow;
                    int amountToBuyNow = demands[month] + row;
                    int costBuyNow = matrix[0, month - 1].Cost + orderCost + holdingCost * row;

                    int costDontBuyNow = int.MaxValue;

                    // if last month's stock isn't enough, there is no choice but to buy now
                    if (row + demands[month] > maxStock)
                    {
                        parentRow = 0;
                    }
                    else
                    {
                        costDontBuyNow = matrix[row + 1, month - 1].Cost + holdingCost * row;
                        parentRow = row + 1;
                    }

                    var cost = Math.Min(costBuyNow, costDontBuyNow);

                    matrix[row, month] = new Purchase
                    {
                        Cost = cost,
                        StockFromLastMonth = parentRow,
                        Size = (cost != costBuyNow) ? 0 : amountToBuyNow
                    };

                }
            }
            return matrix;
        }
    }
}
