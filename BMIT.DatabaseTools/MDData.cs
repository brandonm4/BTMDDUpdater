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
        public MDData(string pathToMdd)
        {
            db = new SqliteConnection("Filename=" + pathToMdd);
            db.Open();
        }
        //~MDData()
        //{
        //    try { db.Close(); } catch { }
        //}
        private static SqliteConnection db;

        public void UpdateUnitDefs(Newtonsoft.Json.Linq.JObject unitDef, int defType = 1)
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
            var cmd1 = new SqliteCommand("INSERT or REPLACE INTO UnitDef('UnitDefID', 'FriendlyName', 'IconID', 'UnitTypeID', 'TagSetID', 'Cost') " + "VALUES(" + "'" + unitDef["Description"]["Id"].ToString() + "', " + "'" + unitDef["Description"]["Name"].ToString() + "', " + "'" + unitDef["Description"]["Icon"].ToString() + "', " + defType.ToString() + ", " + "'" + tagSetID + "', " + unitDef["Description"]["Cost"].ToString() + ")", db);         
            cmd1.ExecuteReader();

            //TagSetTags - first clear out the old ones incase some were removed from def
            cmd1 = new SqliteCommand("Delete from TagSetTag where TagSetID = '" + tagSetID + "'", db);
            cmd1.ExecuteReader();
            //Now add them all back
            foreach (var tag in unitDef["MechTags"]["items"])
            {
                cmd1.Parameters.Clear();
                cmd1 = new SqliteCommand(" INSERT INTO TagSetTag('TagSetID','TagName') VALUES ('" + tagSetID + "', '" + tag.ToString() + "')", db);
                cmd1.ExecuteReader();
            }            
        }

        public void Dispose()
        {
            try { db.Close(); } catch { }
        }
    }
}
