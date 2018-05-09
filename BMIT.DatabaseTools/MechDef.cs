using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIT.DatabaseTools
{
    public class MechTags
    {
        public IList<string> items { get; set; }
        public string tagSetSourceFile { get; set; }
    }

    public class Description
    {
        public int Cost { get; set; }
        public int Rarity { get; set; }
        public bool Purchasable { get; set; }
        public object Manufacturer { get; set; }
        public object Model { get; set; }
        public string UIName { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Icon { get; set; }
    }

    public class MechLocation
    {
        public string DamageLevel { get; set; }   
        public string Location { get; set; }
        public int CurrentArmor { get; set; }
        public int CurrentRearArmor { get; set; }
        public int CurrentInternalStructure { get; set; }
        public int AssignedArmor { get; set; }
        public int AssignedRearArmor { get; set; }
    }

    public class Inventory
    {
        public string MountedLocation { get; set; }
        public string ComponentDefID { get; set; }
        public object SimGameUID { get; set; }
        public string ComponentDefType { get; set; }
        public int HardpointSlot { get; set; }
        public object GUID { get; set; }
        public string DamageLevel { get; set; }
        public object prefabName { get; set; }
        public bool hasPrefabName { get; set; }
    }

    public class MechDef
    {
        public MechTags MechTags { get; set; }
        public string ChassisID { get; set; }
        public object HeraldryID { get; set; }
        public Description Description { get; set; }
        public int simGameMechPartCost { get; set; }
        public int Version { get; set; }
        public IList<MechLocation> Locations { get; set; }
        public IList<Inventory> inventory { get; set; }
    }
}
