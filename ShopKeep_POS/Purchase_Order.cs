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
    public partial class Purchase_Order : Form
    {
        public String publisher;
        PurOrderList purchaseorderlist;
        String test;
        String constr;
        SqlConnection consql;
        String bkprice;
        int index;
        int Amount = 0;
        int Disamount = 0;
        int totalamount = 0;
        public String bookname,pubid;

        public Purchase_Order(PurOrderList purchaseorderlist,String test)
        {
            InitializeComponent();
            this.purchaseorderlist = purchaseorderlist;
            this.test = test;
        }

        void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        public void FillPublisher()
        {
            connection();
            SqlDataAdapter daPublisher = new SqlDataAdapter("select PUB_ID,PUB_NAME from PUBLISHER", consql);
            DataSet dsPublisher = new DataSet();
            DataTable dtPublisher;
            daPublisher.Fill(dsPublisher, "Publisher");
            dtPublisher = dsPublisher.Tables["Publisher"];
            cbPublisher.DataSource = dtPublisher;
            cbPublisher.DisplayMember = dtPublisher.Columns["PUB_NAME"].ToString();
            cbPublisher.ValueMember = dtPublisher.Columns["PUB_ID"].ToString();
        }

        public void FillBook()
        {
            connection();
            SqlDataAdapter daBook = new SqlDataAdapter("SELECT BOOK_ID,BK_TITLE,BK_PURCHASE_PRICE from BOOK where PUB_ID = '" + cbPublisher.SelectedValue.ToString() + "'", consql);
            DataSet dsBook = new DataSet();
            DataTable dtBook;
            daBook.Fill(dsBook, "Book");
            dtBook = dsBook.Tables["Book"];
            cbBookname.DataSource = dtBook;

            if(dtBook.Rows.Count > 0){              
              cbBookname.DisplayMember = dtBook.Columns["BK_TITLE"].ToString();
              cbBookname.ValueMember = dtBook.Columns["BOOK_ID"].ToString();
              txtBookid.Text = cbBookname.SelectedValue.ToString();
            }
            else
            {
                cbBookname.DisplayMember = "";
                cbBookname.ValueMember = "";
                txtBookid.Text = "";
            }
            
        }

        private void cbPublisher_SelectedIndexChanged(object sender, EventArgs e)
        {            
            FillBook();
        }


        private void purorderList_Click(object sender, EventArgs e)
        {
            index = purorderList.FocusedItem.Index;
            bkprice = purorderList.Items[index].SubItems[2].Text;

            txtBookid.Text = purorderList.Items[index].SubItems[0].Text;
            cbBookname.Text = purorderList.Items[index].SubItems[1].Text;
            Disamount = int.Parse(purorderList.Items[index].SubItems[2].Text) * int.Parse(purorderList.Items[index].SubItems[3].Text);
            txtQty.Text = purorderList.Items[index].SubItems[3].Text;
        }

        private void Purchase_Order_Load(object sender, EventArgs e)
        {
            connection();
            FillPublisher();
            FillBook();
            if (test.Equals(CommonConstant.DB_UPDATE))
            {
                cbPublisher.SelectedValue = pubid;
                cbBookname.Text = bookname;
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            connection();
            SqlDataAdapter daBookprice = new SqlDataAdapter("select BK_PURCHASE_PRICE from BOOK where BOOK_ID = '"+txtBookid.Text+"'", consql);
            DataSet dsBookprice = new DataSet();
            Boolean isValid = true;
            Boolean sameID = false;
            String selectBookId;
            int tempQty = 0;

            if (string.IsNullOrEmpty(txtQty.Text.Trim()))
            {
                MessageBox.Show(MessageConstant.PURCAHSE.PURCHASE_QTY);
                isValid = false;
            }

            if (isValid)
            {
                daBookprice.Fill(dsBookprice, "BookPrice");
                bkprice = dsBookprice.Tables["BookPrice"].Rows[0][0].ToString();

                for (int i = 0; i < purorderList.Items.Count; i++)
                {
                    selectBookId = purorderList.Items[i].SubItems[0].Text;

                    if (selectBookId.Equals(txtBookid.Text))
                    {
                        try
                        {
                            tempQty = (int.Parse(txtQty.Text)) + int.Parse(purorderList.Items[i].SubItems[3].Text);
                            Amount = (int.Parse(bkprice)) * tempQty;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            MessageBox.Show("Please Check Your Qty Format !");
                        }

                        purorderList.Items[i].SubItems[3].Text = tempQty.ToString();
                        purorderList.Items[i].SubItems[4].Text = Amount.ToString();
                        sameID = true;
                    }
                }

                if(!sameID){
                    try
                    {
                        Amount = (int.Parse(bkprice)) * (int.Parse(txtQty.Text));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show("Please Check Your Qty Format !");
                    }
                    ListViewItem lvOrder = new ListViewItem(txtBookid.Text);
                    lvOrder.SubItems.Add(cbBookname.Text.ToString());
                    lvOrder.SubItems.Add(bkprice);
                    lvOrder.SubItems.Add(txtQty.Text);
                    lvOrder.SubItems.Add(Amount.ToString());
                    purorderList.Items.Add(lvOrder);
                    txtTotalAmount.Text = ((int.Parse(txtTotalAmount.Text)) + Amount).ToString();
                    }

                cbPublisher.Enabled = false;
                txtQty.Clear();

                //cleartxt();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            totalamount = int.Parse(txtTotalAmount.Text);
            try
            {
                if (string.IsNullOrEmpty(bkprice))
                {
                    bkprice = "error";
                }
                Amount = (int.Parse(bkprice)) * (int.Parse(txtQty.Text));
            }catch(FormatException ex){
                Console.WriteLine(ex.Message);
                MessageBox.Show("Please Select One Record !");
            }
            purorderList.Items[index].SubItems[0].Text = txtBookid.Text;
            purorderList.Items[index].SubItems[1].Text = cbBookname.Text;
            purorderList.Items[index].SubItems[3].Text = txtQty.Text;
            purorderList.Items[index].SubItems[4].Text = Amount.ToString();
            txtTotalAmount.Text = ((int.Parse(txtTotalAmount.Text)) + Amount - Disamount).ToString();
            cleartxt();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (purorderList.SelectedItems.Count == 0)
            {
                MessageBox.Show(MessageConstant.PURCAHSE.SELECT_ONE);
            }
            else
            {
                
                totalamount = int.Parse(txtTotalAmount.Text);
                Amount = (int.Parse(purorderList.Items[purorderList.FocusedItem.Index].SubItems[4].Text));
                purorderList.Items[purorderList.FocusedItem.Index].Remove();
                txtTotalAmount.Text = (totalamount - Amount).ToString();
                cleartxt();

                if (purorderList.Items.Count == 0)
                {
                    cbPublisher.Enabled = true;
                }
                
            }          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cleartxt();
        }

        void cleartxt()
        {
            txtBookid.Text = "";
            txtQty.Text = "";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            String orderid, pubid, orDate, dueDate, strorder, status;
            orderid = txtOrderNo.Text;
            pubid = cbPublisher.SelectedValue.ToString();
            status = "Progress";
            orDate = DateTime.Now.ToString();
            dueDate = dtpDuedate.Text;
            Boolean isValid = true;

            if (purorderList.Items.Count > 0 ) 
            {
        
                if (test.Equals(CommonConstant.DB_INSERT))
                {
                  strorder = "Insert into PURCHASE_ORDER Values('" + orderid + "','" + pubid + "','" + status + "','" + orDate + "','" + dueDate + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                  SqlCommand mycmd = new SqlCommand(strorder, consql);
                  mycmd.ExecuteNonQuery();

                }
                else if (test.Equals(CommonConstant.DB_UPDATE))
                {
                 strorder = "UPDATE PURCHASE_ORDER SET PUB_ID='" + pubid + "',ORDER_STATUS = '" + status + "',DUE_DATE = '" + dueDate + "',LAST_UPDATED_DATE = '" + DateTime.Now + "' WHERE ORDER_ID = '" + orderid + "'";
                 SqlCommand mycmd = new SqlCommand(strorder, consql);
                 mycmd.ExecuteNonQuery();
              }
            }
            else
            {
                MessageBox.Show(MessageConstant.PURCAHSE.ORDER_CONFIRM);
                isValid = false;
            }


            if (isValid)
            {
                purchaseorderlist.connection();
                purchaseorderlist.FillData();

                String bookid, quantity;

                for (int i = 0; i < purorderList.Items.Count; i++)
                {
                    String format = "000000";
                    bookid = purorderList.Items[i].SubItems[0].Text;
                    quantity = purorderList.Items[i].SubItems[3].Text;
                    connection();

                    if (test.Equals(CommonConstant.DB_INSERT))
                    {

                        String strOrDT = "Insert into ORDER_DETAIL Values('" + "OT" + (i + 1).ToString(format) + "','" + orderid + "','" + bookid + "','" + quantity + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                        SqlCommand OrDTcmd = new SqlCommand(strOrDT, consql);
                        OrDTcmd.ExecuteNonQuery();
                       // MessageBox.Show(CommonConstant.DB_INSERT);
                    }
                    else if (test.Equals(CommonConstant.DB_UPDATE))
                    {
                        String ODTid = "OT" + (i + 1).ToString(format);
                        String strOrDT = "UPDATE ORDER_DETAIL SET BOOK_ID='" + bookid + "',QUANTITY ='" + quantity + "',STATUS = 'Progress',LAST_UPDATED_DATE = '" + DateTime.Now + "' WHERE ORDER_DT_ID='" + ODTid + "' AND ORDER_ID='" + orderid + "'";
                        SqlCommand OrDTcmd = new SqlCommand(strOrDT, consql);
                        OrDTcmd.ExecuteNonQuery();
                        //  MessageBox.Show(CommonConstant.DB_UPDATE);
                    }

                    cleartxt();
                }
                MessageBox.Show(MessageConstant.PURCAHSE.ORDER_FINISHED);
                this.Close();
            }
            
        }

        private void cbBookname_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBookid.Text = cbBookname.SelectedValue.ToString();
        }

    }
}
