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
using BMIT.DatabaseTools;
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

#if DEBUG
            txtMDD.Text = @"C:/Development/Brandon/btmods/BTMechDBUpdater/BTMechDBUpdater/test/MetadataDatabase.db";
            txtPath.Text = @"C:/Development/Brandon/btmods/BTMechDBUpdater/BTMechDBUpdater/test/mechs";
            txtVehiclePath.Text = @"C:\Development\Brandon\btmods\BTMechDBUpdater\BTMechDBUpdater\test\vehicle";
#endif
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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
            
            if (File.Exists(txtMDD.Text))
            {
                File.Copy(txtMDD.Text, txtMDD.Text + "-Backup-" + DateTime.Now.ToString("yyyyMMddhhmmss.bak"), false);
            }


            
            using (var mdData = new BMIT.DatabaseTools.MDData(txtMDD.Text))
            {
                string[] files;

                if (!String.IsNullOrEmpty(txtPath.Text))
                {
                    files = Directory.GetFiles(txtPath.Text);
                    toolStripProgressBar1.Minimum = 0;
                    toolStripProgressBar1.Maximum = files.Length;
                    toolStripProgressBar1.Value = 0;

                    toolStripStatusLabel1.Text = "Processing mechs...";

                    Application.DoEvents();

                    foreach (var f in files)
                    {
                        if (f.EndsWith("json"))
                        {
                            var mechdef = LoadMechDef(f);
                            //UpdateDB(mechdef, db);
                            mdData.UpdateUnitDefs(mechdef, UnitType.Mech);
                        }
                        toolStripProgressBar1.Value++;
                        Application.DoEvents();
                    }
                }

                if (!String.IsNullOrEmpty(txtVehiclePath.Text))
                {
                    files = Directory.GetFiles(txtVehiclePath.Text);
                    toolStripProgressBar1.Minimum = 0;
                    toolStripProgressBar1.Maximum = files.Length;
                    toolStripProgressBar1.Value = 0;

                    toolStripStatusLabel1.Text = "Processing vehicles...";
                    Application.DoEvents();

                    foreach (var f in files)
                    {
                        if (f.EndsWith("json"))
                        {
                            var def = LoadMechDef(f);
                            //UpdateDB(mechdef, db);
                            mdData.UpdateUnitDefs(def, UnitType.Vehicle);
                        }
                        toolStripProgressBar1.Value++;
                        Application.DoEvents();
                    }

                }
            }
               
         

            toolStripStatusLabel1.Text = "Complete";

        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
           
            AddOrUpdateAppSettings("DefaultMechDir", txtPath.Text);
            AddOrUpdateAppSettings("DefaultMDDir", txtMDD.Text);
            AddOrUpdateAppSettings("DefaultVehicleDir", txtVehiclePath.Text);
        }

        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

    }
}
