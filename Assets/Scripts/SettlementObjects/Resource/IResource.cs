namespace SettlementObjects.Resource
{
    public interface IResource
    {
        public string Name { get; }
        public float CollectionTime { get; }
        public int Quantity { get; }
        public int AmountOfFoodConsumedByOneUnit { get; }
    }
}