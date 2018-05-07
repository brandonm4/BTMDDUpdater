using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIT.DatabaseTools
{
    public enum UnitType
    {
        Mech = 1,
        Vehicle = 2,
        Turret = 4,
        Building = 8,
    }

    public enum TagSetType
    {
        UNDEFINED = 0,
        Map,
        Encounter,
        Contract,
        LanceDef,
        UnitDef,
        PilotDef,
        RequirementDefRequirement,
        RequirementDefExclusion,
        BiomeRequiredMood,
        Mood,
        EventDefRequired,
        EventDefExcluded,
        EventDefOptionRequired,
        EventDefOptionExcluded,
        EventDefAdded,
        EventDefRemoved,
    }
}
