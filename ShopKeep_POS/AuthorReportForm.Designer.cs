namespace ShopKeep_POS
{
    partial class AuthorReportForm
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
            this.AuthorcrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // AuthorcrystalReportViewer
            // 
            this.AuthorcrystalReportViewer.ActiveViewIndex = -1;
            this.AuthorcrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AuthorcrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.AuthorcrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AuthorcrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.AuthorcrystalReportViewer.Name = "AuthorcrystalReportViewer";
            this.AuthorcrystalReportViewer.Size = new System.Drawing.Size(984, 561);
            this.AuthorcrystalReportViewer.TabIndex = 0;
            this.AuthorcrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // AuthorReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.AuthorcrystalReportViewer);
            this.Name = "AuthorReportForm";
            this.Text = "AuthorReportForm";
            this.Load += new System.EventHandler(this.AuthorReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer AuthorcrystalReportViewer;
    }
}