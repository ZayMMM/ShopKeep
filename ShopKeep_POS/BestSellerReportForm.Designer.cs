namespace ShopKeep_POS
{
    partial class BestSellerReportForm
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
            this.BestSellercrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // BestSellercrystalReportViewer
            // 
            this.BestSellercrystalReportViewer.ActiveViewIndex = -1;
            this.BestSellercrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BestSellercrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.BestSellercrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BestSellercrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.BestSellercrystalReportViewer.Name = "BestSellercrystalReportViewer";
            this.BestSellercrystalReportViewer.Size = new System.Drawing.Size(984, 561);
            this.BestSellercrystalReportViewer.TabIndex = 0;
            // 
            // BestSellerReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.BestSellercrystalReportViewer);
            this.Name = "BestSellerReportForm";
            this.Text = "BestSellerReportForm";
            this.Load += new System.EventHandler(this.BestSellerReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer BestSellercrystalReportViewer;
    }
}