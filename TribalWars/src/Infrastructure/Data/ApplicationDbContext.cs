using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ArmyUnitRequiredMaterial> ArmyUnitRequiredMaterials { get; set; }
        public virtual DbSet<ArmyUnitType> ArmyUnitTypes { get; set; }
        public virtual DbSet<Attack> Attacks { get; set; }
        public virtual DbSet<AttackReport> AttackReports { get; set; }
        public virtual DbSet<BattleUnit> BattleUnits { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<BuildingQueue> BuildingQueues { get; set; }
        public virtual DbSet<BuildingRequiredBuilding> BuildingRequiredBuildings { get; set; }
        public virtual DbSet<BuildingRequiredMaterial> BuildingRequiredMaterials { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<RecruitmentQueue> RecruitmentQueues { get; set; }
        public virtual DbSet<StolenMaterial> StolenMaterials { get; set; }
        public virtual DbSet<Tribe> Tribes { get; set; }
        public virtual DbSet<Village> Villages { get; set; }
        public virtual DbSet<VillageBuilding> VillageBuildings { get; set; }
        public virtual DbSet<VillageMaterial> VillageMaterials { get; set; }
        public virtual DbSet<VillageStatistic> VillageStatistics { get; set; }
        public virtual DbSet<VillageUnit> VillageUnits { get; set; }
        public virtual DbSet<TribePlayer> TribePlayers { get; set; }


    }
}