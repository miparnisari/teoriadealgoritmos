namespace TP2.InventoryManager
{
    using System.Linq;

    public struct InventoryData
    {
        public int NumberOfPeriods { get; set; }
        public int MaxStock { get; set; }
        public int HoldingCost { get; set; }
        public int OrderCost { get; set; }
        public int[] Demands { get; set; }

        public override bool Equals(object obj)
        {
            var isInventory = obj is InventoryData;
            if (isInventory)
            {
                InventoryData other = (InventoryData)obj;
                return this.Demands.SequenceEqual(other.Demands) &&
                       this.NumberOfPeriods == other.NumberOfPeriods &&
                       this.OrderCost == other.OrderCost &&
                       this.HoldingCost == other.HoldingCost &&
                       this.MaxStock == other.MaxStock;
            }
            return false;
        }
    }
}
