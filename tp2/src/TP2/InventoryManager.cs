using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2
{
    public class InventoryManager
    {
        public int[] Calculate(int periods, int maxStock, double storageCost, double orderCost, int[] demands)
        {
            if (demands.Count() != periods)
            {
                throw new Exception("Values for demands should be # of periods");
            }
            if (maxStock < demands[0])
            {
                throw new Exception("Can't meet demand for period 1");
            }

            int[,] results = new int[periods + 1, periods]; //last row contains the minimum

            //iterate over the matrix
            for (int col = 0; col < periods; col++)
            {
                for (int row = 0; row < periods; row++)
                {
                    if (row > col)
                    {
                        //getting rid of infeasible solutions
                        results[row, col] = int.MaxValue;
                    }
                    else
                    {
                        if (row == 0 && col == 0)
                        {
                            results[row, col] = demands[0];
                            results[periods, col] = results[row, col]; //store the minimum
                        }
                        else
                        {
                            if (row == col)
                            {
                                //TODO
                            }
                        }
                    }
                }
            }
        }
    }
}
