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
    public partial class SetSellprice : Form
    {
        StockAdd stockadd;
        StockList stocklist;
        public int index;
        public String bookid;
        String constr;
        SqlConnection consql;

        public SetSellprice(StockAdd stockadd)
        {
            InitializeComponent();
            this.stockadd = stockadd;

        }

        public SetSellprice(StockList stocklist)
        {
            InitializeComponent();
            this.stocklist = stocklist;

        }

        public void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }


        private void btnSet_Click(object sender, EventArgs e)
        {

            if (stocklist == null)
            {
                String sellPrice;
                Boolean isValid = true;
                sellPrice = txtSellprice.Text;

                if (sellPrice.Equals("0"))
                {
                    MessageBox.Show("Enter Sell Price !");
                    isValid = false;
                }

                if (isValid)
                {
                    stockadd.bookListView.Items[index].SubItems[4].Text = sellPrice;
                }

                this.Close();
            }
            else
            {
                String sellPrice;
                Boolean isValid = true;
                sellPrice = txtSellprice.Text;

                if (sellPrice.Equals("0") || sellPrice.Equals(null))
                {
                    MessageBox.Show("Enter Sell Price !");
                    isValid = false;
                }

                if (isValid)
                {
                    connection();
                    String changePrice = "UPDATE STOCK SET SELL_PRICE ='" + sellPrice + "' WHERE BOOK_ID ='" + bookid + "'";
                    SqlCommand changePricecmd = new SqlCommand(changePrice, consql);
                    changePricecmd.ExecuteNonQuery();
                    stocklist.refreshform();
                    MessageBox.Show("FINISH");
                    this.Close();
                }
            }
            

        }


    }
}
