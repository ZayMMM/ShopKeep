namespace ShopKeep_POS
{
    partial class GeneralBookReport
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
            this.cbViewBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbView = new System.Windows.Forms.ComboBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.checkView = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbViewBy
            // 
            this.cbViewBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbViewBy.FormattingEnabled = true;
            this.cbViewBy.Items.AddRange(new object[] {
            "Publisher",
            "Category",
            "Author"});
            this.cbViewBy.Location = new System.Drawing.Point(118, 37);
            this.cbViewBy.Name = "cbViewBy";
            this.cbViewBy.Size = new System.Drawing.Size(121, 24);
            this.cbViewBy.TabIndex = 0;
            this.cbViewBy.Text = "Choose anyone";
            this.cbViewBy.SelectedIndexChanged += new System.EventHandler(this.cbViewBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "View By";
            // 
            // cbView
            // 
            this.cbView.Enabled = false;
            this.cbView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbView.FormattingEnabled = true;
            this.cbView.Location = new System.Drawing.Point(118, 80);
            this.cbView.Name = "cbView";
            this.cbView.Size = new System.Drawing.Size(121, 24);
            this.cbView.TabIndex = 2;
            this.cbView.Text = "Choose anyone";
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(164, 123);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // checkView
            // 
            this.checkView.AutoSize = true;
            this.checkView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkView.Location = new System.Drawing.Point(41, 84);
            this.checkView.Name = "checkView";
            this.checkView.Size = new System.Drawing.Size(56, 20);
            this.checkView.TabIndex = 5;
            this.checkView.Text = "View";
            this.checkView.UseVisualStyleBackColor = true;
            this.checkView.CheckedChanged += new System.EventHandler(this.checkView_CheckedChanged);
            // 
            // GeneralBookReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 167);
            this.Controls.Add(this.checkView);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.cbView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbViewBy);
            this.Name = "GeneralBookReport";
            this.Text = "GeneralBookReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbViewBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbView;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.CheckBox checkView;

    }
}