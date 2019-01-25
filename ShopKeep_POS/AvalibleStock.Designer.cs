namespace ShopKeep_POS
{
    partial class AvalibleStock
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
            this.AvaliableDTGridView = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AvaliableDTGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AvaliableDTGridView
            // 
            this.AvaliableDTGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvaliableDTGridView.Location = new System.Drawing.Point(12, 12);
            this.AvaliableDTGridView.Name = "AvaliableDTGridView";
            this.AvaliableDTGridView.Size = new System.Drawing.Size(231, 345);
            this.AvaliableDTGridView.TabIndex = 0;
            this.AvaliableDTGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AvaliableDTGridView_CellClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(168, 369);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AvalibleStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 404);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.AvaliableDTGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AvalibleStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avaliable Order";
            this.Load += new System.EventHandler(this.AvalibleStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AvaliableDTGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView AvaliableDTGridView;
        private System.Windows.Forms.Button btnAdd;

    }
}