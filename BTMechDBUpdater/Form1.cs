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
using Newtonsoft.Json.Linq;
using Telerik.WinControls.UI;

namespace BTMechDBUpdater
{
    public partial class Form1 : Telerik.WinControls.UI.RadForm
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


            try { txtGamePath.Text = ConfigurationManager.AppSettings["DefaultGameDir"]; } catch { }

            this.Text = "BMIT - Version " + major + "." + minor + "." + build;

#if DEBUG
            //txtMDD.Text = @"C:/Development/Brandon/btmods/BTMechDBUpdater/BTMechDBUpdater/test/MetadataDatabase.db";
            //txtPath.Text = @"C:/Development/Brandon/btmods/BTMechDBUpdater/BTMechDBUpdater/test/mechs";
            //txtVehiclePath.Text = @"C:\Development\Brandon\btmods\BTMechDBUpdater\BTMechDBUpdater\test\vehicle";
            txtGamePath.Text = @"C:\Development\Brandon\BATTLETECH";
#endif
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = lbMechDefs.SelectedItems.Count;
            toolStripProgressBar1.Value1 = 0;

            toolStripStatusLabel1.Text = "Processing...";
            Application.DoEvents();

            if (!txtGamePath.Text.EndsWith(@"\"))
            {
                txtGamePath.Text += @"\";
            }
            var mddPath = txtGamePath.Text + @"\BattleTech_Data\StreamingAssets\MDD\MetadataDatabase.db";
            if (File.Exists(mddPath))
            {
                File.Copy(mddPath, mddPath + "-Backup-" + DateTime.Now.ToString("yyyyMMddhhmmss.bak"), false);
            }

            using (var mdData = new BMIT.DatabaseTools.MDData(mddPath))
            {
                foreach (var def in lbMechDefs.SelectedItems)
                {
                    if (def.Tag != null)
                    {
                        switch (ddlDefType.SelectedItem.ToString())
                        {
                            case "MechDef":
                                mdData.UpdateUnitDefs((JObject)def.Tag, UnitType.Mech);
                                break;
                            case "VehicleDef":
                                mdData.UpdateUnitDefs((JObject)def.Tag, UnitType.Vehicle);
                                break;
                            case "LanceDef":
                                mdData.UpdateLanceDefs((JObject)def.Tag);
                                break;
                            case "PilotDef":
                                mdData.UpdatePilotDefs((JObject)def.Tag);
                                break;
                            case "SimGameEventDef":
                                break;
                            default:
                                MessageBox.Show("Only Mech, Vehicles, Pilot and Lances are currently supported.  Other types are coming soon.");
                                break;
                        }
                    }
                    toolStripProgressBar1.Value1++;
                    Application.DoEvents();
                }
            }
            toolStripStatusLabel1.Text = "Complete";
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
            lbMechDefs.Items.Clear();

            if (!txtGamePath.Text.EndsWith(@"\"))
            {
                txtGamePath.Text += @"\";
            }
            var csvPath = txtGamePath.Text + @"BattleTech_Data\StreamingAssets\data\VersionManifest.csv";
            var basePath = txtGamePath.Text + @"BattleTech_Data\StreamingAssets\";
            var mddPath = txtGamePath.Text + @"\BattleTech_Data\StreamingAssets\MDD\MetadataDatabase.db";
            var unitType = UnitType.Mech;
            switch (ddlDefType.SelectedItem.ToString())
            {
                case "MechDef":
                    unitType = UnitType.Mech;
                    break;
                case "VehicleDef":
                    unitType = UnitType.Vehicle;
                    break;
            }

            List<UnitDef> existingDefs = new List<UnitDef>();
            //using (var mdData = new BMIT.DatabaseTools.MDData(mddPath))
            //{
            //    existingDefs = mdData.GetUnitDefs(unitType);
            //}

            using (var sr = new StreamReader(csvPath))
            {
                while (!sr.EndOfStream)
                {
                    var strline = sr.ReadLine();

                    if (!string.IsNullOrEmpty(strline.Trim()))
                    {
                        var lineData = strline.Split(',');
                        if (lineData.Length >= 10)
                        {
                            var fileName = basePath + lineData[2];
                            if (lineData[1].Trim() == ddlDefType.SelectedItem.ToString())
                            {
                                if (File.Exists(fileName))
                                {
                                    try
                                    {
                                        bool bAdd = true;
                                        if (cbOnlyNew.Checked)
                                        {
                                            foreach (var x in existingDefs)
                                            {
                                                if (x.UnitDefID.Trim().ToLower() == lineData[0].Trim().ToLower())
                                                {
                                                    bAdd = false;
                                                    break;
                                                }
                                            }
                                        }

                                        if (bAdd)
                                        {
                                            var mechdef = LoadMechDef(fileName);
                                            //lbMechDefs.Items.Add(new MechDefListItem()
                                            //{
                                            //    MechDef = mechdef,
                                            //});
                                            lbMechDefs.Items.Add(new RadListDataItem() {
                                                Tag = mechdef,
                                                Text = mechdef["Description"]["Id"].ToString(),
                                            });
                                        }


                                    }
                                    catch
                                    {
                                        lbMechDefs.Items.Add(new RadListDataItem()
                                        {
                                            Tag = null,
                                            Text = lineData[0].Trim(),
                                            ForeColor = Color.Red,
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
            }


            //    var files = Directory.GetFiles(txtPath.Text);
            //lbMechDefs.Items.Clear();
            //lbUnitDefs.Items.Clear();

            //toolStripProgressBar1.Minimum = 0;
            //toolStripProgressBar1.Maximum = files.Length;
            //toolStripProgressBar1.Value = 0;

            //Application.DoEvents();




            //foreach (var f in files)
            //{
            //    if (f.EndsWith("json"))
            //    {
            //        var mechdef = LoadMechDef(f);
            //        //UpdateDB(mechdef);
            //        lbMechDefs.Items.Add(new MechDefListItem()
            //        {
            //            MechDef = mechdef,
            //        });

            //    }
            //    toolStripProgressBar1.Value++;
            //    Application.DoEvents();
            //}

            //using (SqliteConnection db = new SqliteConnection("Filename=Test\\MetadataDatabase.db"))
            //{
            //    db.Open();
            //    var checkcmd = new SqliteCommand("Select * from UnitDef", db);

            //    SqliteDataReader query = checkcmd.ExecuteReader();
            //    while (query.Read())
            //    {
            //        lbUnitDefs.Items.Add(query.GetString(0));
            //    }
            //}
        }


        //private  void button2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (File.Exists(txtMDD.Text))
        //        {
        //            File.Copy(txtMDD.Text, txtMDD.Text + "-Backup-" + DateTime.Now.ToString("yyyyMMddhhmmss.bak"), false);
        //        }



        //        using (var mdData = new BMIT.DatabaseTools.MDData(txtMDD.Text))
        //        {
        //            string[] files;

        //            if (!String.IsNullOrEmpty(txtPath.Text))
        //            {
        //                files = Directory.GetFiles(txtPath.Text);
        //                toolStripProgressBar1.Minimum = 0;
        //                toolStripProgressBar1.Maximum = files.Length;
        //                toolStripProgressBar1.Value = 0;

        //                toolStripStatusLabel1.Text = "Processing mechs...";

        //                Application.DoEvents();

        //                foreach (var f in files)
        //                {
        //                    if (f.EndsWith("json"))
        //                    {
        //                        try
        //                        {
        //                            var mechdef = LoadMechDef(f);
        //                            //UpdateDB(mechdef, db);
        //                            mdData.UpdateUnitDefs(mechdef, UnitType.Mech);
        //                        }
        //                        catch(Exception ex)
        //                        {
        //                            MessageBox.Show("Error Loading MechDef: " + Path.GetFileName(f), "ERROR");
        //                            MessageBox.Show(ex.Message);
        //                            MessageBox.Show(ex.InnerException.Message);
        //                        }
        //                    }
        //                    toolStripProgressBar1.Value++;
        //                    Application.DoEvents();
        //                }
        //            }

        //            if (!String.IsNullOrEmpty(txtVehiclePath.Text))
        //            {
        //                files = Directory.GetFiles(txtVehiclePath.Text);
        //                toolStripProgressBar1.Minimum = 0;
        //                toolStripProgressBar1.Maximum = files.Length;
        //                toolStripProgressBar1.Value = 0;

        //                toolStripStatusLabel1.Text = "Processing vehicles...";
        //                Application.DoEvents();

        //                foreach (var f in files)
        //                {
        //                    if (f.EndsWith("json"))
        //                    {
        //                        try
        //                        {
        //                            var def = LoadMechDef(f);
        //                            //UpdateDB(mechdef, db);
        //                            mdData.UpdateUnitDefs(def, UnitType.Vehicle);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            MessageBox.Show("Error Loading VehicleDef: " + Path.GetFileName(f), "ERROR");
        //                            MessageBox.Show(ex.Message);
        //                            MessageBox.Show(ex.InnerException.Message);
        //                        }
        //                    }
        //                    toolStripProgressBar1.Value++;
        //                    Application.DoEvents();
        //                }

        //            }
        //        }



        //        toolStripStatusLabel1.Text = "Complete";
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "ERROR");
        //        MessageBox.Show(ex.InnerException.Message, "ERROR");
        //    }
        //}

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {

            //AddOrUpdateAppSettings("DefaultMechDir", txtPath.Text);
            //AddOrUpdateAppSettings("DefaultMDDir", txtMDD.Text);
            //AddOrUpdateAppSettings("DefaultVehicleDir", txtVehiclePath.Text);
            AddOrUpdateAppSettings("DefaultGameDir", txtGamePath.Text);
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

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (lbMechDefs.SelectedItems.Count > 0)
            {
                if (lbMechDefs.SelectedItems.First().Tag != null)
                {
                    var frm = new DefViewer((JObject)lbMechDefs.SelectedItems.First().Tag);
                    frm.ShowDialog();
                }
            }
        }
    }
}
