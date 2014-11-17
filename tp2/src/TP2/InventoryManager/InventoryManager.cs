using System;
using System.Collections.Generic;
using System.Linq;

namespace TP2.InventoryManager
{
    public class InventoryManager
    {

        public int[,] CalculateCosts(InventoryData inventoryData)
        {
            return this.CalculateCosts(inventoryData.NumberOfPeriods,
                inventoryData.MaxStock,
                inventoryData.HoldingCost,
                inventoryData.OrderCost,
                inventoryData.Demands);
        }

        private int FindMinimum(int[,] matrix, int size, int column)
        {
            int min = matrix[0, column];
            for (int i = 0; i < size; i++)
            {
                if (matrix[i, column] < min)
                {
                    min = matrix[i, column];
                }
            }
            return min;
        }

        private int[,] CalculateCosts(int numberOfPeriods, int maxStock, int holdingCost, int orderCost, IList<int> demands)
        {
            if (demands.Count() != numberOfPeriods)
            {
                throw new Exception("Values for demands should be # of periods");
            }
            if (maxStock < demands[0])
            {
                throw new Exception("Can't meet demand for period 1");
            }

            int[,] costs = new int[numberOfPeriods + 1, numberOfPeriods]; //last row contains the minimum
            int[,] lots = new int[numberOfPeriods, numberOfPeriods]; //last row contains the minimum
            int INDEX_MINIMUM_OF_PERIOD = numberOfPeriods;

            //iterate over the matrix
            for (int col = 0; col < numberOfPeriods; col++)
            {
                for (int row = 0; row < numberOfPeriods; row++)
                {
                    if (row > col)
                    {
                        //infeasible solution
                        costs[row, col] = int.MaxValue;
                    }
                    else
                    {
                        if (row == 0 && col == 0) //first period
                        {
                            costs[row, col] = orderCost;
                            lots[row, col] = demands[col];
                            //store the minimum cost
                            costs[INDEX_MINIMUM_OF_PERIOD, col] = costs[row, col];
                        }
                        else
                        {
                            if (row == col) // diagonal
                            {
                                costs[row, col] = costs[INDEX_MINIMUM_OF_PERIOD, col - 1] + orderCost;
                                
                            }
                            else //upper triangle
                            {
                                var costPrevious = costs[row, col - 1];
                                var lotFromLastPeriod = lots[row, col - 1];
                                var lotForThisPeriod = (lotFromLastPeriod > demands[col]) ? 0 : orderCost;
                                costs[row, col] = costPrevious + lotFromLastPeriod * holdingCost + lotForThisPeriod;
                                lots[row, col] = lotForThisPeriod;
                            }

                        }
                    }
                }
                costs[INDEX_MINIMUM_OF_PERIOD, col] = FindMinimum(costs, numberOfPeriods, col);
            }

            return costs;
        }
    }
}
