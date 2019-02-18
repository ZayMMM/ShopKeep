namespace ShopKeep_POS
{
    partial class PurOrderReportForm
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
            this.purordercrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // purordercrystalReportViewer
            // 
            this.purordercrystalReportViewer.ActiveViewIndex = -1;
            this.purordercrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.purordercrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.purordercrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purordercrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.purordercrystalReportViewer.Name = "purordercrystalReportViewer";
            this.purordercrystalReportViewer.Size = new System.Drawing.Size(984, 561);
            this.purordercrystalReportViewer.TabIndex = 0;
            this.purordercrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PurOrderReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.purordercrystalReportViewer);
            this.Name = "PurOrderReportForm";
            this.Text = "PurOrderReportForm";
            this.Load += new System.EventHandler(this.PurOrderReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer purordercrystalReportViewer;
    }
}