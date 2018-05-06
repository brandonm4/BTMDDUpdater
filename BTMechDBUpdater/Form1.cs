using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;


namespace BTMechDBUpdater
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            txtPath.Text = ConfigurationManager.AppSettings["DefaultMechDir"];
            txtMDD.Text = ConfigurationManager.AppSettings["DefaultMDDir"];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var files = Directory.GetFiles("C:\\Development\\Brandon\\btmods\\BTMechDBUpdater\\BTMechDBUpdater\\test\\mechs");
            progressBar1.Minimum = 0;
            progressBar1.Maximum = files.Length;
            progressBar1.Value = 0;

            Application.DoEvents();

            foreach (var f in files)
            {
                var mechdef = LoadMechDef(f);
                UpdateDB(mechdef);
                progressBar1.Value++;
                Application.DoEvents();
            }
        }

        private Newtonsoft.Json.Linq.JObject LoadMechDef(string filename)
        {
            var s = "";
            using (var sr = new StreamReader(filename))
            {
                s = sr.ReadToEnd();
            }

            return Newtonsoft.Json.Linq.JObject.Parse(s);
        }

        private void UpdateDB(Newtonsoft.Json.Linq.JObject mechdef)
        {
            //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

            using (SqliteConnection db = new SqliteConnection("Filename=Test\\MetadataDatabase.db"))
            {
                db.Open();
                string tagSetID = "";
                var checkcmd = new SqliteCommand("Select * from UnitDef where UnitDefid = '" + mechdef["Description"]["Id"] + "'", db);
                SqliteDataReader query = checkcmd.ExecuteReader();
                if (query.HasRows)
                {
                    // Do an update
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
                var cmd1 = new SqliteCommand("INSERT or REPLACE INTO UnitDef('UnitDefID', 'FriendlyName', 'IconID', 'UnitTypeID', 'TagSetID', 'Cost') " + "VALUES(" + "'" + mechdef["Description"]["Id"].ToString() + "', " + "'" + mechdef["Description"]["Name"].ToString() + "', " + "'" + mechdef["Description"]["Icon"].ToString() + "', " + "1, " + "'" + tagSetID + "', " + mechdef["Description"]["Cost"].ToString() + ")", db);
                //"                //cmd1.Parameters.AddWithValue("@MechId", mechdef["Description"]["Id"].ToString());
                //cmd1.Parameters.AddWithValue("@Cost", Convert.ToInt32(mechdef["Description"]["Cost"].ToString()));
                //cmd1.Parameters.AddWithValue("@Name", mechdef["Description"]["Name"].ToString());
                //cmd1.Parameters.AddWithValue("@Icon", mechdef["Description"]["Icon"].ToString());
                //cmd1.Parameters.AddWithValue("@tagId", tagSetID);
                cmd1.ExecuteReader();


                //TagSetTags - first clear out the old ones incase some were removed from def
                cmd1 = new SqliteCommand("Delete from TagSetTag where TagSetID = '" + tagSetID + "'", db);
                cmd1.ExecuteReader();
                //Now add them all back
                foreach (var tag in mechdef["MechTags"]["items"])
                {
                    cmd1.Parameters.Clear();
                    cmd1 = new SqliteCommand(" INSERT INTO TagSetTag('TagSetID','TagName') VALUES ('" + tagSetID + "', '" + tag.ToString() + "')", db);
                    cmd1.ExecuteReader();                    
                }
            }
        }
    }
}
