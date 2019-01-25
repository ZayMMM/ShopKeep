namespace ShopKeep_POS
{
    partial class PurOrderconfirm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCancel = new System.Windows.Forms.RadioButton();
            this.rbSuccess = new System.Windows.Forms.RadioButton();
            this.rbProgress = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCancel);
            this.groupBox1.Controls.Add(this.rbSuccess);
            this.groupBox1.Controls.Add(this.rbProgress);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 123);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Confirm";
            // 
            // rbCancel
            // 
            this.rbCancel.AutoSize = true;
            this.rbCancel.Location = new System.Drawing.Point(27, 89);
            this.rbCancel.Name = "rbCancel";
            this.rbCancel.Size = new System.Drawing.Size(58, 17);
            this.rbCancel.TabIndex = 2;
            this.rbCancel.TabStop = true;
            this.rbCancel.Text = "Cancel";
            this.rbCancel.UseVisualStyleBackColor = true;
            // 
            // rbSuccess
            // 
            this.rbSuccess.AutoSize = true;
            this.rbSuccess.Location = new System.Drawing.Point(27, 60);
            this.rbSuccess.Name = "rbSuccess";
            this.rbSuccess.Size = new System.Drawing.Size(66, 17);
            this.rbSuccess.TabIndex = 1;
            this.rbSuccess.TabStop = true;
            this.rbSuccess.Text = "Success";
            this.rbSuccess.UseVisualStyleBackColor = true;
            // 
            // rbProgress
            // 
            this.rbProgress.AutoSize = true;
            this.rbProgress.Location = new System.Drawing.Point(27, 30);
            this.rbProgress.Name = "rbProgress";
            this.rbProgress.Size = new System.Drawing.Size(66, 17);
            this.rbProgress.TabIndex = 0;
            this.rbProgress.TabStop = true;
            this.rbProgress.Text = "Progress";
            this.rbProgress.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(53, 147);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PurOrderconfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(149, 179);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurOrderconfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Confirm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rbCancel;
        public System.Windows.Forms.RadioButton rbSuccess;
        public System.Windows.Forms.RadioButton rbProgress;
        public System.Windows.Forms.Button btnSave;

    }
}