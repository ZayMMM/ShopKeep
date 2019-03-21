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
    public partial class StockAdd : Form
    {
        StockList stocklist;
        
        public String eachSellPrice;
        

        public StockAdd(StockList stocklist)
        {
            InitializeComponent();
            this.stocklist = stocklist;
            
        }

        string constr;
        SqlConnection consql;
        DataTable dtOrder,dtBook;
        DataTable dtprice;
        public void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        void FillOrder()
        {
            String strOrder = "SELECT PO.ORDER_ID,PO.PUB_ID,P.PUB_NAME FROM PURCHASE_ORDER PO "
            +"INNER JOIN PUBLISHER P ON P.PUB_ID=PO.PUB_ID WHERE ORDER_STATUS = 'Success'";
            SqlDataAdapter daOrder = new SqlDataAdapter(strOrder, consql);
            DataSet dsOrder = new DataSet();
            daOrder.Fill(dsOrder, "Order");
            dtOrder = dsOrder.Tables["Order"];
            if(dtOrder.Rows.Count > 0){
                cbOrderid.DataSource = dtOrder;
                cbOrderid.DisplayMember = dtOrder.Columns["ORDER_ID"].ToString();
                cbOrderid.ValueMember = dtOrder.Columns["PUB_NAME"].ToString();
                txtPubName.Text = cbOrderid.SelectedValue.ToString();
            }

           
        }

        void refreshform()
        {
            connection();
            FillOrder();
        }

        void FillBook()
        {
            bookListView.Items.Clear();
            String strBook = "SELECT B.BOOK_ID,B.BK_TITLE,B.BK_PURCHASE_PRICE,OD.QUANTITY FROM ORDER_DETAIL OD INNER JOIN BOOK B ON OD.BOOK_ID = B.BOOK_ID WHERE OD.ORDER_ID = '" + cbOrderid.Text + "'";
            
            SqlDataAdapter daBook = new SqlDataAdapter(strBook, consql);
            DataSet dsBook = new DataSet();    //DataSet For Booklist
            daBook.Fill(dsBook, "Book");
            dtBook = dsBook.Tables["Book"];
            for (int j = 0; j < dtBook.Rows.Count; j++)
            {
                ListViewItem booklistviewitem = new ListViewItem(dtBook.Rows[j].ItemArray[0].ToString());
                for (int k = 1; k < dtBook.Columns.Count; k++)
                {
                    booklistviewitem.SubItems.Add(dtBook.Rows[j].ItemArray[k].ToString());
                }
                String strprice = "SELECT BOOK_ID,SELL_PRICE FROM STOCK WHERE BOOK_ID = '" + dtBook.Rows[j].ItemArray[0].ToString() + "'";
                SqlDataAdapter daprice = new SqlDataAdapter(strprice,consql);
                DataSet dsprice = new DataSet();
                daprice.Fill(dsprice, "Sell");
                dtprice = dsprice.Tables["Sell"];
                if (dtprice.Rows.Count == 0)
                {
                    booklistviewitem.SubItems.Add("0");
                    bookListView.Items.Add(booklistviewitem);
                }
                else
                {
                    string price = dtprice.Rows[0].ItemArray[1].ToString();
                    booklistviewitem.SubItems.Add(price);
                    bookListView.Items.Add(booklistviewitem);
                    
                }
                
            }
        
        }

        private void StockAdd_Load(object sender, EventArgs e)
        {
            refreshform();
        }

        private void cbOrderid_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPubName.Text = cbOrderid.SelectedValue.ToString();
            FillBook();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            String stockid,bookid, bookname, price, quantity, selPrice;
            String format = "0000000";
            Boolean isValid = true;
            for (int i = 0; i < bookListView.Items.Count; i++)
            {
                bookid = bookListView.Items[i].SubItems[0].Text;
                bookname = bookListView.Items[i].SubItems[1].Text;
                price = bookListView.Items[i].SubItems[2].Text;
                quantity = bookListView.Items[i].SubItems[3].Text;
                selPrice = bookListView.Items[i].SubItems[4].Text;

                if (selPrice.Equals("0"))
                {
                    SetSellprice setsell = new SetSellprice(this);
                    setsell.txtBook.Text = bookname;
                    setsell.txtPurPrice.Text = price;
                    setsell.index = i;
                    isValid = false; //
                    setsell.Show();

                }

                if (isValid)
                {
                    stockid = "S" + (int.Parse(bookid.Substring(1, (bookid.Length - 1))).ToString(format));
                    String strQty = "SELECT BOOK_QTY FROM STOCK WHERE BOOK_ID = '" + bookid + "'";
                    SqlDataAdapter daQty = new SqlDataAdapter(strQty, consql);
                    DataSet dsQty = new DataSet();
                    daQty.Fill(dsQty, "QTY");
                    DataTable dtQty = dsQty.Tables["QTY"];
                    String addStock;
                    if (dtQty.Rows.Count > 0)
                    {
                        quantity = (int.Parse(quantity) + int.Parse(dtQty.Rows[0].ItemArray[0].ToString())).ToString();
                        addStock = "UPDATE STOCK SET BOOK_QTY ='" + quantity + "' WHERE BOOK_ID ='" + bookid + "'";
                    }
                    else
                    {
                        addStock = "INSERT INTO STOCK VALUES('" + stockid + "','" + bookid + "','" + quantity + "','" + selPrice + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                    }                   

                    SqlCommand stockcmd = new SqlCommand(addStock, consql);
                    stockcmd.ExecuteNonQuery();

                    MessageBox.Show("FINISH");
                    stocklist.refreshform();

                    String updateOrder = "UPDATE PURCHASE_ORDER SET ORDER_STATUS = 'Done' WHERE ORDER_ID = '" + cbOrderid.Text + "'";
                    SqlCommand upOrderstatus = new SqlCommand(updateOrder, consql);
                    upOrderstatus.ExecuteNonQuery();
                    this.Close();
                    
                }
            }        

        }

    }

}

