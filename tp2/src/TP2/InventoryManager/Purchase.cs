namespace TP2.InventoryManager
{
    using System.Diagnostics;

    [DebuggerDisplay("Buy {Size} at ${Cost}. Prev stock {StockFromLastMonth}")]
    public class Purchase
    {
        public int Cost { get; set; }

        public int StockFromLastMonth { get; set; }

        public int Size { get; set; }
    }
}
