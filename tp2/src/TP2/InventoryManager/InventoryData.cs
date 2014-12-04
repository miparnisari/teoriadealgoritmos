namespace TP2.InventoryManager
{
    using System.Linq;

    public class InventoryData
    {
        public int Months { get; set; }
        public int MaxStock { get; set; }
        public int HoldingCost { get; set; }
        public int OrderCost { get; set; }
        public int[] MonthlyDemand { get; set; }

        public override bool Equals(object obj)
        {
            var isInventory = obj is InventoryData;
            if (isInventory)
            {
                InventoryData other = (InventoryData)obj;
                return this.MonthlyDemand.SequenceEqual(other.MonthlyDemand) &&
                       this.Months == other.Months &&
                       this.OrderCost == other.OrderCost &&
                       this.HoldingCost == other.HoldingCost &&
                       this.MaxStock == other.MaxStock;
            }
            return false;
        }
    }
}
