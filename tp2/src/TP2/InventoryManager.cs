using System;
using System.Collections.Generic;
using System.Linq;

namespace TP2
{
    public class InventoryManager
    {

        //public int[] CalculateResults(InventoryData inventoryData)
        //{
        //   return this.Calculate(inventoryData.NumberOfPeriods,
        //        inventoryData.MaxStock,
        //        inventoryData.HoldingCost,
        //        inventoryData.OrderCost,
        //        inventoryData.Demands);
        //}

        private int[] Calculate(uint numberOfPeriods, uint maxStock, double holdingCost, double orderCost, IList<uint> demands)
        {
            if (demands.Count() != numberOfPeriods)
            {
                throw new Exception("Values for demands should be # of periods");
            }
            if (maxStock < demands[0])
            {
                throw new Exception("Can't meet demand for period 1");
            }

            uint[,] results = new uint[numberOfPeriods + 1, numberOfPeriods]; //last row contains the minimum
            uint INDEX_MINIMUM_OF_PERIOD = numberOfPeriods;

            //iterate over the matrix
            for (int col = 0; col < numberOfPeriods; col++)
            {
                for (int row = 0; row < numberOfPeriods; row++)
                {
                    if (row > col)
                    {
                        //infeasible solution
                        results[row, col] = int.MaxValue;
                        
                    }
                    else
                    {
                        if (row == 0 && col == 0) //first period
                        {
                            results[row, col] = demands[0];
                            //store the minimum
                            results[INDEX_MINIMUM_OF_PERIOD, col] = results[row, col];
                        }
                        else
                        {
                            if (row == col)
                            {
                                //TODO
                            }
                            else
                            {
                                // (i-1) * demand * holding cost
                                var demand = demands[row];
                                //results[row,col] = results[row-1,col]+(row-col)*(results[])
                            }
                        }
                    }
                }
            }
        }
    }
}
