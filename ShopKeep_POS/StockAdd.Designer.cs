namespace ShopKeep_POS
{
    partial class StockAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockAdd));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sellprice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.purchaseprice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bookname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bookid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bookListView = new System.Windows.Forms.ListView();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPubName = new System.Windows.Forms.TextBox();
            this.cbOrderid = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 101);
            this.pictureBox1.TabIndex = 122;
            this.pictureBox1.TabStop = false;
            // 
            // sellprice
            // 
            this.sellprice.Text = "Sell Price";
            this.sellprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sellprice.Width = 194;
            // 
            // qty
            // 
            this.qty.Text = "Quantity";
            this.qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qty.Width = 172;
            // 
            // purchaseprice
            // 
            this.purchaseprice.Text = "Price";
            this.purchaseprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.purchaseprice.Width = 174;
            // 
            // bookname
            // 
            this.bookname.Text = "Book Name";
            this.bookname.Width = 199;
            // 
            // bookid
            // 
            this.bookid.Text = "Book ID";
            this.bookid.Width = 218;
            // 
            // bookListView
            // 
            this.bookListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bookid,
            this.bookname,
            this.purchaseprice,
            this.qty,
            this.sellprice});
            this.bookListView.FullRowSelect = true;
            this.bookListView.Location = new System.Drawing.Point(12, 119);
            this.bookListView.Name = "bookListView";
            this.bookListView.Size = new System.Drawing.Size(960, 407);
            this.bookListView.TabIndex = 121;
            this.bookListView.UseCompatibleStateImageBehavior = false;
            this.bookListView.View = System.Windows.Forms.View.Details;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(233, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 16);
            this.label9.TabIndex = 120;
            this.label9.Text = "Order No";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.Info;
            this.btnAdd.Location = new System.Drawing.Point(776, 83);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(79, 30);
            this.btnAdd.TabIndex = 113;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(233, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 106;
            this.label2.Text = "Publisher";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(217, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(755, 31);
            this.label10.TabIndex = 119;
            this.label10.Text = "Stock Entry Form";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPubName
            // 
            this.txtPubName.Enabled = false;
            this.txtPubName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPubName.Location = new System.Drawing.Point(356, 87);
            this.txtPubName.Name = "txtPubName";
            this.txtPubName.Size = new System.Drawing.Size(173, 22);
            this.txtPubName.TabIndex = 123;
            // 
            // cbOrderid
            // 
            this.cbOrderid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOrderid.FormattingEnabled = true;
            this.cbOrderid.Location = new System.Drawing.Point(356, 53);
            this.cbOrderid.Name = "cbOrderid";
            this.cbOrderid.Size = new System.Drawing.Size(173, 24);
            this.cbOrderid.TabIndex = 124;
            this.cbOrderid.SelectedIndexChanged += new System.EventHandler(this.cbOrderid_SelectedIndexChanged);
            // 
            // StockAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.cbOrderid);
            this.Controls.Add(this.txtPubName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bookListView);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Name = "StockAdd";
            this.Text = "StockAdd";
            this.Load += new System.EventHandler(this.StockAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ColumnHeader sellprice;
        public System.Windows.Forms.ColumnHeader qty;
        public System.Windows.Forms.ColumnHeader purchaseprice;
        public System.Windows.Forms.ColumnHeader bookname;
        public System.Windows.Forms.ColumnHeader bookid;
        public System.Windows.Forms.ListView bookListView;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtPubName;
        private System.Windows.Forms.ComboBox cbOrderid;
    }
}