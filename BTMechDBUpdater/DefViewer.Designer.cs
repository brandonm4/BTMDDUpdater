namespace BTMechDBUpdater
{
    partial class DefViewer
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
            this.jsonExplorer = new Telerik.WinControls.UI.RadTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.jsonExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // jsonExplorer
            // 
            this.jsonExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jsonExplorer.Location = new System.Drawing.Point(0, 0);
            this.jsonExplorer.Name = "jsonExplorer";
            this.jsonExplorer.Size = new System.Drawing.Size(292, 270);
            this.jsonExplorer.SpacingBetweenNodes = -1;
            this.jsonExplorer.TabIndex = 0;
            this.jsonExplorer.Text = "radTreeView1";
            // 
            // DefViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 270);
            this.Controls.Add(this.jsonExplorer);
            this.Name = "DefViewer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "DefViewer";
            ((System.ComponentModel.ISupportInitialize)(this.jsonExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView jsonExplorer;
    }
}
