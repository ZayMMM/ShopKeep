namespace ShopKeep_POS
{
    partial class StaffReportForm
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
            this.StaffcrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // StaffcrystalReportViewer
            // 
            this.StaffcrystalReportViewer.ActiveViewIndex = -1;
            this.StaffcrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StaffcrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.StaffcrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StaffcrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.StaffcrystalReportViewer.Name = "StaffcrystalReportViewer";
            this.StaffcrystalReportViewer.Size = new System.Drawing.Size(984, 561);
            this.StaffcrystalReportViewer.TabIndex = 0;
            this.StaffcrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // StaffReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.StaffcrystalReportViewer);
            this.Name = "StaffReportForm";
            this.Text = "StaffReportForm";
            this.Load += new System.EventHandler(this.StaffReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer StaffcrystalReportViewer;
    }
}