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
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        DataSet Dset;
        public void FillData()
        {
            string query = "SELECT S.STOCK_ID,B.BK_TITLE,P.PUB_NAME,S.BOOK_QTY,S.SELL_PRICE FROM STOCK S INNER JOIN BOOK B ON S.BOOK_ID = B.BOOK_ID INNER JOIN PUBLISHER P ON B.PUB_ID=P.PUB_ID";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
            adapter.Fill(Dset, "Stock");
            dtStock = Dset.Tables["Stock"];
            stockdataGridView.DataSource = dtStock;


            stockdataGridView.Columns[0].HeaderText = "STOCK_ID";
            stockdataGridView.Columns[1].HeaderText = "TITLE";
            stockdataGridView.Columns[2].HeaderText = "PUBLISHER";
            stockdataGridView.Columns[3].HeaderText = "Quantity";
            stockdataGridView.Columns[4].HeaderText = "Price";

            stockdataGridView.Columns[0].Width = 80;
            stockdataGridView.Columns[1].Width = 250;
            stockdataGridView.Columns[2].Width = 250;
            stockdataGridView.Columns[3].Width = 250;
            stockdataGridView.Columns[4].Width = 180;

            stockdataGridView.Columns[0].Visible = false;


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
            
           // StockEnty stockEnty = new StockEnty(this);
           // stockEnty.Show();
             

            StockAdd stockAdd = new StockAdd(this);
            stockAdd.Show();


            /* for avaliable stock
            AvalibleStock avalibleStock = new AvalibleStock(this);
            avalibleStock.Show();
             */
        }


        private void stockdataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void stockdataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = stockdataGridView.CurrentRow.Index;
            dr = dtStock.Rows[i];
            SetSellprice setsell = new SetSellprice(this);
            String stockid = dr[0].ToString();
            String format = "0000000";
            String bookid = "B" + (int.Parse(stockid.Substring(1, (stockid.Length - 1))).ToString(format));
            setsell.bookid = bookid;
            setsell.txtBook.Text = dr[2].ToString();
            setsell.txtSellprice.Text = dr[4].ToString();

            

            String strPurprice = "SELECT BK_PURCHASE_PRICE FROM BOOK WHERE BOOK_ID = '" + bookid + "'";
            SqlDataAdapter daPurprice = new SqlDataAdapter(strPurprice, consql);
            DataTable dtPurprice = new DataTable();
            daPurprice.Fill(dtPurprice);
            setsell.txtPurPrice.Text = dtPurprice.Rows[0].ItemArray[0].ToString();
            setsell.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = Dset.Tables["Stock"].DefaultView;
            dv.RowFilter = "BK_TITLE LIKE '%" + txtSearch.Text.Trim() + "%'";
        }

        
    }
}
