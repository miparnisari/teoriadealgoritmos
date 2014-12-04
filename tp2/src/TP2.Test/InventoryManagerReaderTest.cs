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
            var reader = new InventoryManagerFileReader();

            // act
            InventoryData data = reader.GetDataFromFile("Input/inventory.txt");

            // assert
            var expected = new InventoryData
            {
                Months = 4,
                OrderCost = 30,
                HoldingCost = 10,
                MonthlyDemand = new[] { 2, 1, 1, 4 },
                MaxStock = 2
            };

            Assert.AreEqual(expected, data);
        }
    }
}
