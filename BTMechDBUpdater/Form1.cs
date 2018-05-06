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

            var major = System.Reflection.Assembly.GetExecutingAssembly()
                                          .GetName()
                                          .Version.Major
                                          .ToString();
            var minor = System.Reflection.Assembly.GetExecutingAssembly()
                                           .GetName()
                                           .Version.Minor
                                           .ToString();
            var build = System.Reflection.Assembly.GetExecutingAssembly()
                                           .GetName()
                                           .Version.Build
                                           .ToString();

            txtPath.Text = ConfigurationManager.AppSettings["DefaultMechDir"];
            txtMDD.Text = ConfigurationManager.AppSettings["DefaultMDDir"];

            this.Text = "BMIT - Version " + major + "." + minor + "." + build;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var files = Directory.GetFiles(txtPath.Text);
            //toolStripProgressBar1.Minimum = 0;
            //toolStripProgressBar1.Maximum = files.Length;
            //toolStripProgressBar1.Value = 0;
            //lblComplete.Visible = false;
            //Application.DoEvents();


            
             

            

            //lblComplete.Visible = true;
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

        private void UpdateDB(Newtonsoft.Json.Linq.JObject mechdef, SqliteConnection db)
        {
            //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            if (File.Exists(txtMDD.Text))
            {
                //File.Copy(txtMDD.Text, txtMDD.Text + "-Backup-" + DateTime.Now.ToString("yyyyMMddhhmmss.bak"), false);

                //using (SqliteConnection db = new SqliteConnection("Filename=" + txtMDD.Text))
                {
                   // db.Open();
                    string tagSetID = "";
                    var checkcmd = new SqliteCommand("Select * from UnitDef where UnitDefid = '" + mechdef["Description"]["Id"] + "'", db);
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
                 //   db.Close();
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(txtPath.Text);
            lbMechDefs.Items.Clear();
            lbUnitDefs.Items.Clear();

            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = files.Length;
            toolStripProgressBar1.Value = 0;

            Application.DoEvents();




            foreach (var f in files)
            {
                if (f.EndsWith("json"))
                {
                    var mechdef = LoadMechDef(f);
                    //UpdateDB(mechdef);
                    lbMechDefs.Items.Add(new MechDefListItem()
                    {
                        MechDef = mechdef,
                    });

                }
                toolStripProgressBar1.Value++;
                Application.DoEvents();
            }

            using (SqliteConnection db = new SqliteConnection("Filename=Test\\MetadataDatabase.db"))
            {
                db.Open();
                var checkcmd = new SqliteCommand("Select * from UnitDef", db);

                SqliteDataReader query = checkcmd.ExecuteReader();
                while (query.Read())
                {
                    lbUnitDefs.Items.Add(query.GetString(0));
                }
            }
        }
        private void lblComplete_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(txtPath.Text);
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = files.Length;
            toolStripProgressBar1.Value = 0;

            toolStripStatusLabel1.Text = "Processing files...";
            if (File.Exists(txtMDD.Text))
            {
                File.Copy(txtMDD.Text, txtMDD.Text + "-Backup-" + DateTime.Now.ToString("yyyyMMddhhmmss.bak"), false);
            }

            Application.DoEvents();

            using (SqliteConnection db = new SqliteConnection("Filename=" + txtMDD.Text))
            {
                db.Open();

                foreach (var f in files)
                {
                    if (f.EndsWith("json"))
                    {
                        var mechdef = LoadMechDef(f);
                        UpdateDB(mechdef, db);
                    }
                    toolStripProgressBar1.Value++;
                    Application.DoEvents();
                }

                db.Close();
            }


            toolStripStatusLabel1.Text = "Complete";

        }
    }
}
