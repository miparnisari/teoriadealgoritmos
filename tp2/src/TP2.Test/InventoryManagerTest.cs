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
                Demands = new[] { 2, 1, 1, 4 },
                HoldingCost = 10,
                MaxStock = 2,
                NumberOfPeriods = 4,
                OrderCost = 30
            };

            // act
            var actualCosts = InventoryManager.BuildCostsMatrix(data);

            // assert
            var expectedCosts = new[,]
            {
                {30, 40, 60, 90},
                {40, 60, 80, 100},
                {50, 80, 90, 110}
            };

            Assert.AreEqual(expectedCosts, actualCosts);
        }
    }
}

