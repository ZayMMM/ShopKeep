namespace ShopKeep_POS
{
    partial class SaleReportForm
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
            this.SalecrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // SalecrystalReportViewer
            // 
            this.SalecrystalReportViewer.ActiveViewIndex = -1;
            this.SalecrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SalecrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.SalecrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SalecrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.SalecrystalReportViewer.Name = "SalecrystalReportViewer";
            this.SalecrystalReportViewer.Size = new System.Drawing.Size(984, 561);
            this.SalecrystalReportViewer.TabIndex = 0;
            this.SalecrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // SaleReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.SalecrystalReportViewer);
            this.Name = "SaleReportForm";
            this.Text = "SaleReportForm";
            this.Load += new System.EventHandler(this.SaleReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer SalecrystalReportViewer;
    }
}