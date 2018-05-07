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

        public void UpdateLanceDefs(Newtonsoft.Json.Linq.JObject lanceDef)
        {
            //SqliteTransaction trans = db.BeginTransaction();

            try
            {
                string tagSetID = "";
                using (var checkcmd = db.CreateCommand())
                {
                    checkcmd.CommandText = "Select * from LanceDef where LanceDefid = '" + lanceDef["Description"]["Id"] + "'";
                    //checkcmd.Transaction = trans;
                    using (var query = checkcmd.ExecuteReader())
                    {
                        if (query.HasRows)
                        {
                            // Do an update
                            query.Read();
                            tagSetID = query.GetString(3);
                        }
                        else
                        {
                            // Do an insert
                            tagSetID = Guid.NewGuid().ToString();
                            using (var cmd = db.CreateCommand())
                            {
                                //cmd.Transaction = trans;
                                cmd.CommandText = "INSERT INTO TagSet('TagSetID','TagSetTypeID') VALUES ('" + tagSetID.ToString() + "'," + ((int)TagSetType.LanceDef).ToString() + ")";
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                using (var cmd1 = db.CreateCommand())
                {
                    //cmd1.Transaction = trans;
                    cmd1.CommandText = "INSERT OR REPLACE INTO LanceDef('LanceDefID', FriendlyName, Difficulty,'TagSetID', 'Cost') VALUES ('" + lanceDef["Description"]["Id"].ToString() + "', '" + lanceDef["Description"]["Name"].ToString() + "', " + lanceDef["Difficulty"].ToString() + ", '" + tagSetID + "', " + lanceDef["Description"]["Cost"].ToString() + ")";
                    cmd1.ExecuteNonQuery();

                    cmd1.CommandText = "Delete from TagSetTag where TagSetID = '" + tagSetID + "'";
                    cmd1.ExecuteNonQuery();

                    foreach (var tag in lanceDef["LanceTags"]["items"])
                    {
                        cmd1.Parameters.Clear();
                        cmd1.CommandText = " INSERT INTO TagSetTag('TagSetID','TagName') VALUES ('" + tagSetID + "', '" + tag.ToString() + "')";
                        cmd1.ExecuteNonQuery();
                    }
                }
                //trans.Commit();
            }
            catch (Exception ex)
            {
                //trans.Rollback();
            }
        }

        public void UpdatePilotDefs(Newtonsoft.Json.Linq.JObject pilotDef)
        {
            try
            {
                string tagSetID = "";
                using (var checkcmd = db.CreateCommand())
                {
                    checkcmd.CommandText = "Select * from PilotDef where PilotDefID = '" + pilotDef["Description"]["Id"] + "'";
                    //checkcmd.Transaction = trans;
                    using (var query = checkcmd.ExecuteReader())
                    {
                        if (query.HasRows)
                        {
                            // Do an update
                            query.Read();
                            tagSetID = query.GetString(3);
                        }
                        else
                        {
                            // Do an insert
                            tagSetID = Guid.NewGuid().ToString();
                            using (var cmd = db.CreateCommand())
                            {
                                //cmd.Transaction = trans;
                                cmd.CommandText = "INSERT INTO TagSet('TagSetID','TagSetTypeID') VALUES ('" + tagSetID.ToString() + "'," + ((int)TagSetType.PilotDef).ToString() + ")";
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                using (var cmd1 = db.CreateCommand())
                {
                    //cmd1.Transaction = trans;
                    cmd1.CommandText = "INSERT OR REPLACE INTO PilotDef('PilotDefID', 'FriendlyName', 'IconID','TagSetID', 'IsRonin') VALUES ('" + pilotDef["Description"]["Id"].ToString() + "', '" + pilotDef["Description"]["Name"].ToString() + "', '" + pilotDef["Description"]["Icon"].ToString() + "', '" + tagSetID + "', " + Convert.ToInt32(Convert.ToBoolean(pilotDef["IsRonin"].ToString())).ToString() + ")";
                    cmd1.ExecuteNonQuery();

                    cmd1.CommandText = "Delete from TagSetTag where TagSetID = '" + tagSetID + "'";
                    cmd1.ExecuteNonQuery();

                    foreach (var tag in pilotDef["PilotTags"]["items"])
                    {
                        cmd1.Parameters.Clear();
                        cmd1.CommandText = " INSERT INTO TagSetTag('TagSetID','TagName') VALUES ('" + tagSetID + "', '" + tag.ToString() + "')";
                        cmd1.ExecuteNonQuery();
                    }
                }
                //trans.Commit();
            }
            catch (Exception ex)
            {
                //trans.Rollback();
            }
        }
        #endregion

        #region Select Defs
        public List<UnitDef> GetUnitDefs(UnitType defType)
        {
            var lst = new List<UnitDef>();

            using (var checkcmd = db.CreateCommand())
            {
                checkcmd.CommandText = "Select UnitDefID, FriendlyName, IconID, UnitTypeID, TagSetID, Cost from UnitDef where UnitTypeID = " + ((int)defType).ToString();
                using (var query = checkcmd.ExecuteReader())
                {
                    while (query.Read())
                    {
                        lst.Add(new UnitDef() {
                               UnitDefID = query.GetString(0),
                               FriendlyName = query.GetString(1),
                               IconID = query.GetString(2),
                               UnitType = (UnitType)query.GetInt32(3),
                               TagSetID = query.GetString(4),
                               Cost = query.GetInt32(5),
                        });
                    }
                }
            }
            return lst;
        }
        #endregion

        #region PlaceHolder/NotImplemented
        /* Placeholder functions for now */
        

        public void UpdateEventDefs(Newtonsoft.Json.Linq.JObject eventDef)
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




/*
using(TransactionScope scope = new TransactionScope(TransactionScopeOptions.RequiresNew))
{
  ...
  scope.Complete()
}

    public void Commit()
    {
        using (SQLiteConnection conn = new SQLiteConnection(this.connString))
        {
            conn.Open();
            SQLiteTransaction trans = conn.BeginTransaction();
            try
            {
                using (SQLiteCommand command = conn.CreateCommand())
                {
                    command.Transaction = trans; // Now the command is linked to the transaction and don't try to create a new one (which is probably why your database gets locked)
                    command.CommandText = "INSERT OR IGNORE INTO [MY_TABLE] (col1, col2) VALUES (?,?)";

                    command.Parameters.Add(this.col1Param);
                    command.Parameters.Add(this.col2Param);

                    foreach (Data o in this.dataTemp)
                    {
                        this.col1Param.Value = o.Col1Prop;
                        this. col2Param.Value = o.Col2Prop;

                        command.ExecuteNonQuery();
                    }
                }

                trans.Commit();
            }
            catch (SQLiteException ex)
            {
                // You need to rollback in case something wrong happened in command.ExecuteNonQuery() ...
                trans.Rollback();
                throw;
            }
        }
    }
 */
