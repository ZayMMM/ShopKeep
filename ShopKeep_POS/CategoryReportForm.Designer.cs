namespace ShopKeep_POS
{
    partial class CategoryReportForm
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
            this.CategorycrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CategorycrystalReportViewer
            // 
            this.CategorycrystalReportViewer.ActiveViewIndex = -1;
            this.CategorycrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CategorycrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CategorycrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategorycrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CategorycrystalReportViewer.Name = "CategorycrystalReportViewer";
            this.CategorycrystalReportViewer.Size = new System.Drawing.Size(984, 561);
            this.CategorycrystalReportViewer.TabIndex = 0;
            this.CategorycrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // CategoryReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.CategorycrystalReportViewer);
            this.Name = "CategoryReportForm";
            this.Text = "CategoryReportForm";
            this.Load += new System.EventHandler(this.CategoryReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CategorycrystalReportViewer;
    }
}