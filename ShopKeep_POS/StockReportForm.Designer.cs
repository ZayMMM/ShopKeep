namespace ShopKeep_POS
{
    partial class StockReportForm
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
            this.StockcrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // StockcrystalReportViewer
            // 
            this.StockcrystalReportViewer.ActiveViewIndex = -1;
            this.StockcrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockcrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.StockcrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockcrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.StockcrystalReportViewer.Name = "StockcrystalReportViewer";
            this.StockcrystalReportViewer.Size = new System.Drawing.Size(984, 561);
            this.StockcrystalReportViewer.TabIndex = 0;
            // 
            // StockReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.StockcrystalReportViewer);
            this.Name = "StockReportForm";
            this.Text = "StockReportForm";
            this.Load += new System.EventHandler(this.StockReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer StockcrystalReportViewer;
    }
}