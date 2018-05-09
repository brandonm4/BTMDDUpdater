using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIT.DatabaseTools
{
   
    public class Hardpoint
    {
        public string WeaponMount { get; set; }
        public bool Omni { get; set; }
    }

    public class ChassisLocation
    {
        public string Location { get; set; }
        public IList<Hardpoint> Hardpoints { get; set; }
        public int Tonnage { get; set; }
        public int InventorySlots { get; set; }
        public int MaxArmor { get; set; }
        public int MaxRearArmor { get; set; }
        public int InternalStructure { get; set; }
    }

    public class LOSSourcePosition
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }

    public class LOSTargetPosition
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }

    public class ChassisTags
    {
        public IList<object> items { get; set; }
        public string tagSetSourceFile { get; set; }
    }

    public class ChassisDef
    {
        public Description Description { get; set; }
        public string MovementCapDefID { get; set; }
        public string PathingCapDefID { get; set; }
        public string HardpointDataDefID { get; set; }
        public string PrefabIdentifier { get; set; }
        public string PrefabBase { get; set; }
        public int Tonnage { get; set; }
        public int InitialTonnage { get; set; }
        public string weightClass { get; set; }
        public int BattleValue { get; set; }
        public int Heatsinks { get; set; }
        public int TopSpeed { get; set; }
        public int TurnRadius { get; set; }
        public int MaxJumpjets { get; set; }
        public int Stability { get; set; }
        public IList<int> StabilityDefenses { get; set; }
        public int SpotterDistanceMultiplier { get; set; }
        public int VisibilityMultiplier { get; set; }
        public int SensorRangeMultiplier { get; set; }
        public int Signature { get; set; }
        public int Radius { get; set; }
        public bool PunchesWithLeftArm { get; set; }
        public int MeleeDamage { get; set; }
        public int MeleeInstability { get; set; }
        public int MeleeToHitModifier { get; set; }
        public int DFADamage { get; set; }
        public int DFAToHitModifier { get; set; }
        public int DFASelfDamage { get; set; }
        public int DFAInstability { get; set; }
        public IList<ChassisLocation> Locations { get; set; }
        public IList<LOSSourcePosition> LOSSourcePositions { get; set; }
        public IList<LOSTargetPosition> LOSTargetPositions { get; set; }
        public string VariantName { get; set; }
        public ChassisTags ChassisTags { get; set; }
        public string StockRole { get; set; }
        public string YangsThoughts { get; set; }
    }
}
