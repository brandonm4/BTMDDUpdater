namespace BTMechDBUpdater
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem7 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem8 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem9 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem10 = new Telerik.WinControls.UI.RadListDataItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new Telerik.WinControls.UI.RadButton();
            this.lblComplete = new Telerik.WinControls.UI.RadLabel();
            this.tabControl1 = new Telerik.WinControls.UI.RadPageView();
            this.tabPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.cbOnlyNew = new Telerik.WinControls.UI.RadCheckBox();
            this.ddlDefType = new Telerik.WinControls.UI.RadDropDownList();
            this.label8 = new Telerik.WinControls.UI.RadLabel();
            this.btnLoad = new Telerik.WinControls.UI.RadButton();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.lbMechDefs = new Telerik.WinControls.UI.RadListControl();
            this.tabPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.label7 = new Telerik.WinControls.UI.RadLabel();
            this.txtGamePath = new Telerik.WinControls.UI.RadTextBox();
            this.btnSaveConfig = new Telerik.WinControls.UI.RadButton();
            this.tabPage4 = new Telerik.WinControls.UI.RadPageViewPage();
            this.richTextBox1 = new Telerik.WinControls.UI.RadRichTextEditor();
            this.statusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.toolStripProgressBar1 = new Telerik.WinControls.UI.RadProgressBarElement();
            this.toolStripStatusLabel1 = new Telerik.WinControls.UI.RadLabelElement();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOnlyNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDefType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbMechDefs)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGamePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveConfig)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.richTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Import Selected";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblComplete
            // 
            this.lblComplete.Location = new System.Drawing.Point(733, 488);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(55, 18);
            this.lblComplete.TabIndex = 6;
            this.lblComplete.Text = "Complete";
            this.lblComplete.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.radPageViewPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedPage = this.tabPage2;
            this.tabControl1.Size = new System.Drawing.Size(800, 575);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.radButton1);
            this.tabPage2.Controls.Add(this.cbOnlyNew);
            this.tabPage2.Controls.Add(this.ddlDefType);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btnLoad);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.lbMechDefs);
            this.tabPage2.ItemSize = new System.Drawing.SizeF(70F, 28F);
            this.tabPage2.Location = new System.Drawing.Point(10, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(779, 527);
            this.tabPage2.Text = "Processing";
            // 
            // cbOnlyNew
            // 
            this.cbOnlyNew.Location = new System.Drawing.Point(376, 32);
            this.cbOnlyNew.Name = "cbOnlyNew";
            this.cbOnlyNew.Size = new System.Drawing.Size(99, 18);
            this.cbOnlyNew.TabIndex = 13;
            this.cbOnlyNew.Text = "Only Show New";
            // 
            // ddlDefType
            // 
            radListDataItem6.Text = "MechDef";
            radListDataItem7.Text = "VehicleDef";
            radListDataItem8.Text = "LanceDef";
            radListDataItem9.Text = "PilotDef";
            radListDataItem10.Text = "SimGameEventDef";
            this.ddlDefType.Items.Add(radListDataItem6);
            this.ddlDefType.Items.Add(radListDataItem7);
            this.ddlDefType.Items.Add(radListDataItem8);
            this.ddlDefType.Items.Add(radListDataItem9);
            this.ddlDefType.Items.Add(radListDataItem10);
            this.ddlDefType.Location = new System.Drawing.Point(249, 5);
            this.ddlDefType.Name = "ddlDefType";
            this.ddlDefType.Size = new System.Drawing.Size(121, 20);
            this.ddlDefType.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(195, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "DefType";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(376, 55);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(101, 44);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load Files";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Def Files";
            // 
            // lbMechDefs
            // 
            this.lbMechDefs.Location = new System.Drawing.Point(3, 32);
            this.lbMechDefs.Name = "lbMechDefs";
            this.lbMechDefs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbMechDefs.Size = new System.Drawing.Size(367, 472);
            this.lbMechDefs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtGamePath);
            this.tabPage1.Controls.Add(this.btnSaveConfig);
            this.tabPage1.ItemSize = new System.Drawing.SizeF(56F, 28F);
            this.tabPage1.Location = new System.Drawing.Point(10, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(779, 527);
            this.tabPage1.Text = "Settings";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(22, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Game Path";
            // 
            // txtGamePath
            // 
            this.txtGamePath.Location = new System.Drawing.Point(120, 21);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.Size = new System.Drawing.Size(587, 20);
            this.txtGamePath.TabIndex = 14;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(120, 155);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(101, 23);
            this.btnSaveConfig.TabIndex = 11;
            this.btnSaveConfig.Text = "Save Settings";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.richTextBox1);
            this.tabPage4.ItemSize = new System.Drawing.SizeF(40F, 28F);
            this.tabPage4.Location = new System.Drawing.Point(10, 37);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(779, 527);
            this.tabPage4.Text = "Help";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            this.richTextBox1.IsReadOnly = true;
            this.richTextBox1.LayoutMode = Telerik.WinForms.Documents.Model.DocumentLayoutMode.Flow;
            this.richTextBox1.Location = new System.Drawing.Point(8, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.SelectionFill = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(78)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.richTextBox1.Size = new System.Drawing.Size(781, 512);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 549);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 26);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.Bounds = new System.Drawing.Rectangle(0, 0, 300, 18);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.SeparatorColor1 = System.Drawing.Color.White;
            this.toolStripProgressBar1.SeparatorColor2 = System.Drawing.Color.White;
            this.toolStripProgressBar1.SeparatorColor3 = System.Drawing.Color.White;
            this.toolStripProgressBar1.SeparatorColor4 = System.Drawing.Color.White;
            this.toolStripProgressBar1.SeparatorGradientAngle = 0;
            this.toolStripProgressBar1.SeparatorGradientPercentage1 = 0.4F;
            this.toolStripProgressBar1.SeparatorGradientPercentage2 = 0.6F;
            this.toolStripProgressBar1.SeparatorNumberOfColors = 2;
            this.statusStrip1.SetSpring(this.toolStripProgressBar1, false);
            this.toolStripProgressBar1.StepWidth = 14;
            this.toolStripProgressBar1.SweepAngle = 90;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Bounds = new System.Drawing.Rectangle(0, 0, 200, 17);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.statusStrip1.SetSpring(this.toolStripStatusLabel1, false);
            this.toolStripStatusLabel1.Text = "Ready";
            this.toolStripStatusLabel1.TextWrap = true;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(37F, 28F);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(779, 527);
            this.radPageViewPage1.Text = "Test";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(376, 105);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(101, 44);
            this.radButton1.TabIndex = 11;
            this.radButton1.Text = "View";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 575);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblComplete);
            this.Name = "Form1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "BMIT";
            ((System.ComponentModel.ISupportInitialize)(this.button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblComplete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOnlyNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDefType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbMechDefs)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGamePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveConfig)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.richTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton button1;
        private Telerik.WinControls.UI.RadLabel lblComplete;
        private Telerik.WinControls.UI.RadPageView tabControl1;
        private Telerik.WinControls.UI.RadPageViewPage tabPage1;
        private Telerik.WinControls.UI.RadPageViewPage tabPage2;
        private Telerik.WinControls.UI.RadStatusStrip statusStrip1;
        private Telerik.WinControls.UI.RadProgressBarElement toolStripProgressBar1;
        private Telerik.WinControls.UI.RadListControl lbMechDefs;
        private Telerik.WinControls.UI.RadLabel label3;
        private Telerik.WinControls.UI.RadButton btnLoad;
        private Telerik.WinControls.UI.RadLabelElement toolStripStatusLabel1;
        private Telerik.WinControls.UI.RadButton btnSaveConfig;
        private Telerik.WinControls.UI.RadPageViewPage tabPage4;
        private Telerik.WinControls.UI.RadRichTextEditor richTextBox1;
        private Telerik.WinControls.UI.RadLabel label7;
        private Telerik.WinControls.UI.RadTextBox txtGamePath;
        private Telerik.WinControls.UI.RadDropDownList ddlDefType;
        private Telerik.WinControls.UI.RadLabel label8;
        private Telerik.WinControls.UI.RadCheckBox cbOnlyNew;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}

