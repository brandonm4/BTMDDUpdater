﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIT.DatabaseTools
{
    public class UnitDef
    {
        //UnitDefID', 'FriendlyName', 'IconID', 'UnitTypeID', 'TagSetID', 'Cost'
        public string UnitDefID { get; set; }
        public string FriendlyName { get; set; }
public string IconID { get; set; }
        public string TagSetID { get; set; }
        public int Cost { get; set; }
        public UnitType UnitType { get; set; }
        public UnitDef()
        {
        }
    }
}


