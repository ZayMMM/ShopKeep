using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShopKeep_POS
{
    public partial class Discount : Form
    {


        public Discount()
        {
            InitializeComponent();
        }
        string constr;
        SqlConnection consql;
        DataTable datatablediscount;
        void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        void FillData()
        {
            string query = "SELECT * FROM DISCOUNT";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet Dset = new DataSet();
            adapter.Fill(Dset, "Discount");
            datatablediscount = Dset.Tables["Discount"];
            discountDataGridView.DataSource = datatablediscount;

            discountDataGridView.Columns[0].HeaderText = "DiscountID";
            discountDataGridView.Columns[1].HeaderText = "BookID";
            discountDataGridView.Columns[2].HeaderText = "Discount Range";
            discountDataGridView.Columns[3].HeaderText = "Created By";
            discountDataGridView.Columns[4].HeaderText = "Created Date";
            discountDataGridView.Columns[5].HeaderText = "Last Update Date";

            discountDataGridView.Columns[0].Width = 100;
            discountDataGridView.Columns[1].Width = 100;
            discountDataGridView.Columns[2].Width = 100;
            discountDataGridView.Columns[3].Width = 100;
            discountDataGridView.Columns[4].Width = 100;
            discountDataGridView.Columns[5].Width = 100;
            

        }

        public void refreshform()
        {
            connection();
            FillData();
        }
       

        private void Discount_Load(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DiscountEntry discountentry = new DiscountEntry(this,CommonConstant.DB_INSERT);
            discountentry.Show();

        }
    }
}
