namespace TP2.Test
{
    using NUnit.Framework;
    using TP2.InventoryManager;

    [TestFixture]
    public class InventoryManagerReaderTest
    {
        [Test]
        public void ShouldReadInventoryInput()
        {
            // arrange
            var reader = new InventoryManagerReader();

            // act
            InventoryData data = reader.GetDataFromFile("Input/inventory.txt");

            // assert
            var expected = new InventoryData
            {
                NumberOfPeriods = 4,
                OrderCost = 30,
                HoldingCost = 10,
                Demands = new[] { 2, 1, 1, 4 },
                MaxStock = 2
            };

            Assert.AreEqual(expected, data);
        }
    }
}
