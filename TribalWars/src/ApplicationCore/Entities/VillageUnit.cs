namespace ApplicationCore.Entities
{
    public class VillageUnit
    {
        public int Id { get; set; }
        public int ArmyUnitTypeId { get; set; }
        public int VillageId { get; set; }
        public int Quantity { get; set; }
        public virtual Village Village { get; set; }
        public virtual ArmyUnitType ArmyUnitType { get; set; }
    }
}