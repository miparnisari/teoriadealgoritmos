namespace TP2.Test
{
    using NUnit.Framework;
    using TP2.InventoryManager;

    [TestFixture]
    public class InventoryManagerTest
    {
        [Test]
        public void ShouldBuildCorrectCostsMatrix()
        {
            // arrange
            var data = new InventoryData
            {
                MonthlyDemand = new[] { 2, 1, 1, 4 },
                HoldingCost = 10,
                MaxStock = 2,
                Months = 4,
                OrderCost = 30
            };

            // act
            var matrix = InventoryManager.GetPurchaseData(data.MaxStock, data.HoldingCost, data.OrderCost, data.MonthlyDemand);

            // assert
            var expectedSizes = new[,]
            {
                {2, 0, 0, 4},
                {3, 0, 2, 5},
                {4, 3, 3, 6}
            };

            var expectedCosts = new[,]
            {
                {30, 40, 60, 90},
                {40, 60, 80, 100},
                {50, 80, 90, 110}
            };

            for (int row = 0; row <= data.MaxStock; row++)
            {
                for (int col = 0; col < data.Months; col++)
                {
                    Assert.AreEqual(expectedSizes[row, col], matrix[row, col].Size, "Size is wrong for [" + row + "][" + col + "]");
                    Assert.AreEqual(expectedCosts[row, col], matrix[row, col].Cost, "Cost is wrong for [" + row + "][" + col + "]");
                }
            }
        }

        [Test]
        public void ShouldGetOptimalSolution()
        {
            // arrange
            var data = new InventoryData
            {
                MonthlyDemand = new[] { 2, 1, 1, 4 },
                HoldingCost = 10,
                MaxStock = 2,
                Months = 4,
                OrderCost = 30
            };

            // act
            int[] optimalSolution = InventoryManager.GetOrderQuantities(data);

            // assert
            var expectedOptimalSolution = new[]
            {
                4, 0, 0, 4
            };

            CollectionAssert.AreEqual(expectedOptimalSolution, optimalSolution);
        }

        [Test]
        public void ShouldGetOptimalSolutionWhenOrderCostIsLowerThanHoldingCost()
        {
            // arrange
            var data = new InventoryData
            {
                MonthlyDemand = new[] { 10, 12, 9 },
                HoldingCost = 4,
                MaxStock = 20,
                Months = 3,
                OrderCost = 2
            };

            // act
            int[] optimalSolution = InventoryManager.GetOrderQuantities(data);

            // assert
            var expectedOptimalSolution = new[]
            {
                10, 12, 9
            };

            CollectionAssert.AreEqual(expectedOptimalSolution, optimalSolution);
        }
    }
}