namespace ShopKeep_POS
{
    partial class DamageLossReportForm
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
            this.dmgLoscrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // dmgLoscrystalReportViewer
            // 
            this.dmgLoscrystalReportViewer.ActiveViewIndex = -1;
            this.dmgLoscrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dmgLoscrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.dmgLoscrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dmgLoscrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.dmgLoscrystalReportViewer.Name = "dmgLoscrystalReportViewer";
            this.dmgLoscrystalReportViewer.Size = new System.Drawing.Size(984, 561);
            this.dmgLoscrystalReportViewer.TabIndex = 0;
            // 
            // DamageLossReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.dmgLoscrystalReportViewer);
            this.Name = "DamageLossReportForm";
            this.Text = "DamageLossReportForm";
            this.Load += new System.EventHandler(this.DamageLossReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer dmgLoscrystalReportViewer;
    }
}