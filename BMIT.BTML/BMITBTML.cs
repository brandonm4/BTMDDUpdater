using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMIT.BTML
{
    public static class BMITBTML
    {
        public static void Init()
        {
            var harmony = HarmonyInstance.Create("io.github.brandonm4.BMITBTML");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public static void Reset()
        {
            
        }
    }
}


