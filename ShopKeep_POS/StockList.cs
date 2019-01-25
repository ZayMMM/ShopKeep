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
    public partial class StockList : Form
    {
        public StockList()
        {
            InitializeComponent();
        }

        string constr;
        SqlConnection consql;
        DataTable dtStock;
        public void connection()
        {
            constr = "Data Source=DESKTOP-3ONRIPK;Initial Catalog=BOOK;Integrated Security=True";
            consql = new SqlConnection(constr);
            consql.Open();
        }

        public void FillData()
        {
            string query = "SELECT * FROM STOCK";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet Dset = new DataSet();
            adapter.Fill(Dset, "Stock");
            dtStock = Dset.Tables["Stock"];
            stockdataGridView.DataSource = dtStock;

        }

        public void refreshform()
        {
            connection();
            FillData();
        }


        private void StockList_Load(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StockEnty stockEnty = new StockEnty(this);
            stockEnty.Show();




            /* for avaliable stock
            AvalibleStock avalibleStock = new AvalibleStock(this);
            avalibleStock.Show();
             */
        }

        
    }
}
