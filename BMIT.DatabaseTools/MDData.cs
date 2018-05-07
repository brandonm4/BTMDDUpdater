using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIT.DatabaseTools
{
    public class MDData : IDisposable
    {
        #region Private Vars
        private static SqliteConnection db;
        #endregion

        #region Events
        public MDData(string pathToMdd)
        {
            db = new SqliteConnection("Filename=" + pathToMdd);
            db.Open();
        }
        public void Dispose()
        {
            try { db.Close(); } catch { }
        }
        #endregion

        #region Update Defs
        public void UpdateUnitDefs(Newtonsoft.Json.Linq.JObject unitDef, UnitType defType)
        {
            // db.Open();
            string tagSetID = "";
            var checkcmd = new SqliteCommand("Select * from UnitDef where UnitDefid = '" + unitDef["Description"]["Id"] + "'", db);
            SqliteDataReader query = checkcmd.ExecuteReader();
            if (query.HasRows)
            {
                // Do an update
                query.Read();
                tagSetID = query.GetString(4);
            }
            else
            {
                // Do an insert
                tagSetID = Guid.NewGuid().ToString();
                var cmd = new SqliteCommand("INSERT INTO TagSet('TagSetID','TagSetTypeID') VALUES ('" + tagSetID.ToString() + "',5)", db);
                cmd.ExecuteReader();
            }

            //Now do insert/replace for supporting rows
            //UnitDef table    
            // INSERT INTO UnitDef('UnitDefID','FriendlyName','IconID','UnitTypeID','TagSetID','Cost') VALUES ('ID_from_mechdef','Name_from_mechdef','Icon_from_mech_def',1,'UUID_from_step_one',Cost_from_mech_def);
            var cmd1 = new SqliteCommand("INSERT or REPLACE INTO UnitDef('UnitDefID', 'FriendlyName', 'IconID', 'UnitTypeID', 'TagSetID', 'Cost') " + "VALUES(" + "'" + unitDef["Description"]["Id"].ToString() + "', " + "'" + unitDef["Description"]["Name"].ToString() + "', " + "'" + unitDef["Description"]["Icon"].ToString() + "', " + ((int)defType).ToString() + ", " + "'" + tagSetID + "', " + unitDef["Description"]["Cost"].ToString() + ")", db);         
            cmd1.ExecuteReader();


            //TagSetTags - first clear out the old ones incase some were removed from def
            cmd1 = new SqliteCommand("Delete from TagSetTag where TagSetID = '" + tagSetID + "'", db);
            cmd1.ExecuteReader();
            //Now add them all back
            switch(defType)
            {
                case UnitType.Mech:
                    foreach (var tag in unitDef["MechTags"]["items"])
                    {
                        cmd1.Parameters.Clear();
                        cmd1 = new SqliteCommand(" INSERT INTO TagSetTag('TagSetID','TagName') VALUES ('" + tagSetID + "', '" + tag.ToString() + "')", db);
                        cmd1.ExecuteReader();
                    }
                    break;
                case UnitType.Vehicle:
                    foreach (var tag in unitDef["VehicleTags"]["items"])
                    {
                        cmd1.Parameters.Clear();
                        cmd1 = new SqliteCommand(" INSERT INTO TagSetTag('TagSetID','TagName') VALUES ('" + tagSetID + "', '" + tag.ToString() + "')", db);
                        cmd1.ExecuteReader();
                    }
                    break;
            }
             
        }
        #endregion

        #region PlaceHolder/NotImplemented
        /* Placeholder functions for now */
        public void UpdateLanceDefs(Newtonsoft.Json.Linq.JObject lanceDef)
        {
            throw new NotImplementedException();
        }

        public void UpdateEventDefs(Newtonsoft.Json.Linq.JObject eventDef)
        {
            throw new NotImplementedException();
        }

        public void UpdatePilotDefs(Newtonsoft.Json.Linq.JObject pilotDef)
        {
            throw new NotImplementedException();
        }
        public void UpdateRequirementDefs(Newtonsoft.Json.Linq.JObject reqDef)
        {
            throw new NotImplementedException();
        }
        public void UpdateUpgradeDefs(Newtonsoft.Json.Linq.JObject upgradeDef)
        {
            throw new NotImplementedException();
        }
        public void UpdateWeaponDefs(Newtonsoft.Json.Linq.JObject weaponDef)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
