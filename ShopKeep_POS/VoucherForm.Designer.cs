namespace ShopKeep_POS
{
    partial class VoucherForm
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
            this.VouchercrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // VouchercrystalReportViewer
            // 
            this.VouchercrystalReportViewer.ActiveViewIndex = -1;
            this.VouchercrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VouchercrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.VouchercrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VouchercrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.VouchercrystalReportViewer.Name = "VouchercrystalReportViewer";
            this.VouchercrystalReportViewer.Size = new System.Drawing.Size(984, 561);
            this.VouchercrystalReportViewer.TabIndex = 0;
            this.VouchercrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // VoucherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.VouchercrystalReportViewer);
            this.Name = "VoucherForm";
            this.Text = "VoucherForm";
            this.Load += new System.EventHandler(this.VoucherForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer VouchercrystalReportViewer;
    }
}