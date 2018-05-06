using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTMechDBUpdater
{
    class MechDefListItem
    {

        public Newtonsoft.Json.Linq.JObject MechDef { get; set; }

        public override string ToString()
        {
            if (MechDef != null)
            {
                return MechDef["Description"]["Id"].ToString();
            }
            return "No MechDef Assigned";
        }
    }
}
