namespace ShopKeep_POS
{
    partial class GeneralPurOrderRptForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbxdate = new System.Windows.Forms.CheckBox();
            this.checkView = new System.Windows.Forms.CheckBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.cbView = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbViewBy = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(279, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "Start Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(163, 207);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(94, 20);
            this.dtpStartDate.TabIndex = 31;
            this.dtpStartDate.Value = new System.DateTime(2019, 2, 1, 0, 0, 0, 0);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(364, 207);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(94, 20);
            this.dtpEndDate.TabIndex = 30;
            this.dtpEndDate.Value = new System.DateTime(2019, 2, 12, 6, 20, 55, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(390, 31);
            this.label2.TabIndex = 29;
            this.label2.Text = "Pruchase Order Report Form";
            // 
            // ckbxdate
            // 
            this.ckbxdate.AutoSize = true;
            this.ckbxdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbxdate.Location = new System.Drawing.Point(190, 158);
            this.ckbxdate.Name = "ckbxdate";
            this.ckbxdate.Size = new System.Drawing.Size(121, 20);
            this.ckbxdate.TabIndex = 28;
            this.ckbxdate.Text = "Search By Date";
            this.ckbxdate.UseVisualStyleBackColor = true;
            this.ckbxdate.CheckedChanged += new System.EventHandler(this.ckbxdate_CheckedChanged);
            // 
            // checkView
            // 
            this.checkView.AutoSize = true;
            this.checkView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkView.Location = new System.Drawing.Point(190, 117);
            this.checkView.Name = "checkView";
            this.checkView.Size = new System.Drawing.Size(56, 20);
            this.checkView.TabIndex = 27;
            this.checkView.Text = "View";
            this.checkView.UseVisualStyleBackColor = true;
            this.checkView.CheckedChanged += new System.EventHandler(this.checkView_CheckedChanged);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(423, 247);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(110, 43);
            this.btnReport.TabIndex = 26;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // cbView
            // 
            this.cbView.Enabled = false;
            this.cbView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbView.FormattingEnabled = true;
            this.cbView.Location = new System.Drawing.Point(267, 113);
            this.cbView.Name = "cbView";
            this.cbView.Size = new System.Drawing.Size(121, 24);
            this.cbView.TabIndex = 25;
            this.cbView.Text = "Choose anyone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "View By";
            // 
            // cbViewBy
            // 
            this.cbViewBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbViewBy.FormattingEnabled = true;
            this.cbViewBy.Items.AddRange(new object[] {
            "Publisher",
            "Order Status"});
            this.cbViewBy.Location = new System.Drawing.Point(267, 70);
            this.cbViewBy.Name = "cbViewBy";
            this.cbViewBy.Size = new System.Drawing.Size(121, 24);
            this.cbViewBy.TabIndex = 23;
            this.cbViewBy.Text = "Choose anyone";
            this.cbViewBy.SelectedIndexChanged += new System.EventHandler(this.cbViewBy_SelectedIndexChanged);
            // 
            // GeneralPurOrderRptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 301);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckbxdate);
            this.Controls.Add(this.checkView);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.cbView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbViewBy);
            this.Name = "GeneralPurOrderRptForm";
            this.Text = "GeneralPurOrderRptForm";
            this.Load += new System.EventHandler(this.GeneralPurOrderRptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbxdate;
        private System.Windows.Forms.CheckBox checkView;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.ComboBox cbView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbViewBy;
    }
}