namespace ShopKeep_POS
{
    partial class BookReportForm
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
            this.BookcrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // BookcrystalReportViewer
            // 
            this.BookcrystalReportViewer.ActiveViewIndex = -1;
            this.BookcrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BookcrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.BookcrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BookcrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.BookcrystalReportViewer.Name = "BookcrystalReportViewer";
            this.BookcrystalReportViewer.Size = new System.Drawing.Size(984, 561);
            this.BookcrystalReportViewer.TabIndex = 0;
            this.BookcrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // BookReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.BookcrystalReportViewer);
            this.Name = "BookReportForm";
            this.Text = "BookReportForm";
            this.Load += new System.EventHandler(this.BookReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer BookcrystalReportViewer;
    }
}