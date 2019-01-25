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
    public partial class StockEnty : Form
    {

        StockList stocklist;

        public StockEnty(StockList stocklist)
        {
            InitializeComponent();
            this.stocklist = stocklist;
        }

        string constr;
        SqlConnection consql;
        String strStock;
        DataTable dtOrder,dtODT;
        public void connection()
        {
            constr = "Data Source=DESKTOP-3ONRIPK;Initial Catalog=BOOK;Integrated Security=True";
            consql = new SqlConnection(constr);
            consql.Open();
        }

        public void FillData()
        {
            strStock = "SELECT PO.ORDER_ID,P.PUB_NAME FROM PURCHASE_ORDER PO INNER JOIN PUBLISHER P ON P.PUB_ID=PO.PUB_ID WHERE ORDER_STATUS = 'Success'";
            
            SqlDataAdapter daOrder = new SqlDataAdapter(strStock,consql);
            DataSet dsOrder = new DataSet();
            daOrder.Fill(dsOrder, "Order");
            dtOrder = dsOrder.Tables["Order"];
            cbOrderid.DataSource = dtOrder;
            cbOrderid.DisplayMember = dtOrder.Columns["ORDER_ID"].ToString();     

        }

        public void FillODetail()
        {
            String strdetail = "SELECT OD.ORDER_DT_ID,B.BK_TITLE,OD.QUANTITY,B.BK_PURCHASE_PRICE,B.BOOK_ID FROM ORDER_DETAIL OD INNER JOIN BOOK B ON OD.BOOK_ID = B.BOOK_ID WHERE OD.ORDER_ID = '" + cbOrderid.Text + "'";
            SqlDataAdapter daODT = new SqlDataAdapter(strdetail, consql);
            DataSet dsODT = new DataSet();//DataSet For OrderDetail
            daODT.Fill(dsODT, "Detail");
            dtODT = dsODT.Tables["Detail"];
            cbOrderdetail.DataSource = dtODT;
            cbOrderdetail.DisplayMember = dtODT.Columns["ORDER_DT_ID"].ToString();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection();
            String stockid,bookid, quantity, sellprice, strStock;
            String format = "0000000";
            bookid = dtODT.Rows[cbOrderdetail.SelectedIndex][4].ToString();
            stockid = "S" + (int.Parse(bookid.Substring(1, (bookid.Length - 1))).ToString(format));

            quantity = txtQty.Text;
            sellprice = txtSellprice.Text;

            String test = "SELECT BOOK_ID,BOOK_QTY FROM STOCK WHERE STOCK_ID = '" + stockid + "'";
            SqlDataAdapter daTest = new SqlDataAdapter(test, consql);
            DataSet dsTest = new DataSet();//DataSet For OrderDetail
            daTest.Fill(dsTest, "Test");
            DataTable dtTest = new DataTable();
            dtTest = dsTest.Tables["Test"];
            int i = dtTest.Rows.Count;
            

            if(i == 0)
            {
                strStock = "INSERT INTO STOCK VALUES('" + stockid + "','" + bookid + "','" + quantity + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
            }
            else
            {
                int qty = int.Parse(dtTest.Rows[0][1].ToString());
                quantity = (int.Parse(quantity)+qty).ToString();
                strStock = "UPDATE STOCK SET BOOK_QTY ='" + quantity + "'";
            }
            SqlCommand stockCmd = new SqlCommand(strStock, consql);
            stockCmd.ExecuteNonQuery();


            MessageBox.Show("FINISH");
                

            

        }

        private void StockEnty_Load(object sender, EventArgs e)
        {
            connection();
            FillData();
            FillODetail();
        }

        private void cbOrderid_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillODetail();
            txtPublisher.Text = dtOrder.Rows[cbOrderid.SelectedIndex][1].ToString();


        }

        private void cbOrderdetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBookTitle.Text = dtODT.Rows[cbOrderdetail.SelectedIndex][1].ToString();
            txtQty.Text = dtODT.Rows[cbOrderdetail.SelectedIndex][2].ToString();
            txtPurchaseprice.Text = dtODT.Rows[cbOrderdetail.SelectedIndex][3].ToString();
        }

        


    }
}
