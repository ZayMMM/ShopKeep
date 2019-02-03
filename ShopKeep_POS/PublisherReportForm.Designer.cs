namespace ShopKeep_POS
{
    partial class PublisherReportForm
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
            this.PublishercrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // PublishercrystalReportViewer
            // 
            this.PublishercrystalReportViewer.ActiveViewIndex = -1;
            this.PublishercrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PublishercrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.PublishercrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PublishercrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.PublishercrystalReportViewer.Name = "PublishercrystalReportViewer";
            this.PublishercrystalReportViewer.Size = new System.Drawing.Size(984, 561);
            this.PublishercrystalReportViewer.TabIndex = 0;
            this.PublishercrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PublisherReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.PublishercrystalReportViewer);
            this.Name = "PublisherReportForm";
            this.Text = "PublisherReportForm";
            this.Load += new System.EventHandler(this.PublisherReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer PublishercrystalReportViewer;
    }
}