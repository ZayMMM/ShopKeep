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
    public partial class Sale : Form
    {
        public Sale()
        {
            InitializeComponent();
        }

        String constr;
        SqlConnection consql;
        String saleID, sellprice;
        int totalAmount;
        double Discount,tempDiscount;
        double discount = 0;
        int index = -1;
        Dictionary<String,int> dictionary = new Dictionary<String, int>();

        void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        void SaleGenerateId()
        {
            string OID = "SELECT SALE_ID FROM SALE ORDER BY SALE_ID";
            string SName;
            int SID;
            string format = "0000000";
            SqlDataAdapter adSale = new SqlDataAdapter(OID, consql);
            DataSet dsSale = new DataSet();
            adSale.Fill(dsSale, "Sale");
            if (dsSale.Tables["Sale"].Rows.Count > 0)
            {
                SName = dsSale.Tables["Sale"].Rows[dsSale.Tables["Sale"].Rows.Count - 1][0].ToString();
                SID = int.Parse(SName.Substring(1, (SName.Length - 1)));
                saleID = "S" + ((SID + 1).ToString(format));
            }
            else
            {
               saleID = "S0000001";
            }
        }

        public void FillBook()
        {
            connection();
            SqlDataAdapter daBook = new SqlDataAdapter("SELECT BOOK_ID FROM STOCK", consql);
            DataSet dsBook = new DataSet();
            DataTable dtBook;
            daBook.Fill(dsBook, "Book");
            dtBook = dsBook.Tables["Book"];
            cbBookid.DataSource = dtBook;
            cbBookid.DisplayMember = dtBook.Columns["BOOK_ID"].ToString();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection();
            String qty, stockQtyStr;
            int Amount = 0;
            int tempAmount = 0;
            int currentStockQty;
            qty = txtQuantity.Text;
            String strStock = "SELECT B.BK_TITLE,S.SELL_PRICE,S.BOOK_QTY FROM STOCK S INNER JOIN BOOK B ON B.BOOK_ID = S.BOOK_ID WHERE S.BOOK_ID = '" + cbBookid.Text + "'";
            SqlDataAdapter daSale = new SqlDataAdapter(strStock, consql);
            DataSet dsSale = new DataSet();
            DataTable dtSale;
            Boolean isValid = true;
            

            if (string.IsNullOrEmpty(txtQuantity.Text.Trim()) || txtQuantity.Text=="0")
            {
                MessageBox.Show(MessageConstant.PURCAHSE.PURCHASE_QTY);
                isValid = false;
            }

            try
            {
                int.Parse(qty);
            }
            catch (FormatException ex)
            {
                isValid = false;
                Console.WriteLine(ex.Message);
                MessageBox.Show("Please Check Your Quantity !");
            }

            if (isValid)
            {
                try
                {
                    int.Parse(txtDiscount.Text.Trim());
                }
                catch (FormatException ex)
                {
                    isValid = false;
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Please Check Your Discount !");
                }
            }
            
            if (isValid)
            {
                daSale.Fill(dsSale, "Sale");
                dtSale = dsSale.Tables["Sale"];
                sellprice = dtSale.Rows[0][1].ToString(); 

                if (!dictionary.ContainsKey(cbBookid.Text))
                {
                    stockQtyStr = dtSale.Rows[0][2].ToString();
                    currentStockQty = Int32.Parse(stockQtyStr); ;
                    dictionary.Add(cbBookid.Text,currentStockQty);
                }

                if (int.Parse(qty) > dictionary[cbBookid.Text])
                {
                    MessageBox.Show("Not Enough Quantity ! \nAvailable Quantity is : " + dictionary[cbBookid.Text].ToString());
                    txtQuantity.Focus();
                }
                else
                {
                    String selectBookId = cbBookid.Text;
                    String bookId;
                    int qtyOld,qtyNew;
                    Boolean sameID = false;

                    for (int i = 0; i < SaleListView.Items.Count; i++)
                    {
                         bookId = SaleListView.Items[i].SubItems[0].Text;
                        

                        if (selectBookId.Equals(bookId))
                        {
                            String qtyList = SaleListView.Items[i].SubItems[4].Text;
                            try
                            {                               
                                qtyOld = Int32.Parse(qtyList);
                                qtyNew = Int32.Parse(txtQuantity.Text);

                                qty = (qtyOld + qtyNew).ToString();
                                SaleListView.Items[i].SubItems[4].Text = qty;

                                sellprice = SaleListView.Items[i].SubItems[2].Text;
                                discount = double.Parse(txtDiscount.Text.Trim());
                                //Amount = (int.Parse(sellprice)) * (int.Parse(qty));

                                if (discount != 0)
                                {
                                    discount = double.Parse(txtDiscount.Text.Trim());
                                    discount = discount / 100;
                                    tempDiscount = Int32.Parse(sellprice) * discount;
                                    Discount = (Int32.Parse(sellprice) - tempDiscount);
                                    SaleListView.Items[i].SubItems[3].Text = Discount.ToString();

                                    tempAmount = int.Parse(SaleListView.Items[i].SubItems[5].Text);
                                    Amount = tempAmount + (Convert.ToInt16(Discount) * qtyNew);
                                    //Amount = (qtyNew * Amount);
                                    SaleListView.Items[i].SubItems[5].Text = Amount.ToString();
                                    Amount = Amount - tempAmount;

                                    txtDiscount.Text = "0";
                                    
                                }
                                else
                                {
                                    Discount = 0;
                                    Amount = (int.Parse(sellprice)) * (int.Parse(qty));
                                    SaleListView.Items[i].SubItems[5].Text = Amount.ToString();
                                    Amount = (qtyNew * int.Parse(sellprice));
                                }

                                txtTotAmt.Text = ((int.Parse(txtTotAmt.Text)) + Amount).ToString();
                                //txtNetAmt.Text = ((int.Parse(txtTotAmt.Text)) - Discount).ToString();
                                
                                dictionary[cbBookid.Text] = dictionary[cbBookid.Text] - Int32.Parse(txtQuantity.Text);
                                sameID = true;
                                txtQuantity.Clear();

                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                //MessageBox.Show("Please Check Your Quantity !");
                            }

                            break;
                        }
                    }

                    if (SaleListView.Items.Count == 0)
                    {
                        txtTotAmt.Text = "0";
                    }

                    if (!sameID)
                    {
                        
                        ListViewItem lvSale = new ListViewItem(cbBookid.Text);
                        lvSale.SubItems.Add(dtSale.Rows[0][0].ToString());
                        lvSale.SubItems.Add(sellprice);

                        if (!string.IsNullOrEmpty(txtDiscount.Text.Trim()))
                        {
                            discount = double.Parse(txtDiscount.Text.Trim());
                            discount = discount / 100;
                            tempDiscount = Int32.Parse(sellprice) * discount;
                            Discount = (Int32.Parse(sellprice) - tempDiscount);

                            Amount = (Convert.ToInt16(Discount) * (int.Parse(txtQuantity.Text)));

                            txtDiscount.Text = "0";
                        }
                        else
                        {
                            Discount = 0;
                            Amount = (int.Parse(sellprice)) * (int.Parse(qty));
                        }
                                
                        lvSale.SubItems.Add(Discount.ToString());
                        lvSale.SubItems.Add(qty);
                        lvSale.SubItems.Add(Amount.ToString());
                        SaleListView.Items.Add(lvSale);
                        txtTotAmt.Text = ((int.Parse(txtTotAmt.Text)) + Amount).ToString();
                        dictionary[cbBookid.Text] = dictionary[cbBookid.Text] - Int32.Parse(txtQuantity.Text);
                        txtQuantity.Clear();
                    }
                }
            }
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            connection();
            SaleGenerateId();
            txtSlipNo.Text = saleID;
            FillBook();
            txtSlipNo.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (index != -1) { 
               dictionary[cbBookid.Text] = dictionary[cbBookid.Text] + Int32.Parse(txtQuantity.Text);
               txtTotAmt.Text = ((Int32.Parse(txtTotAmt.Text)) - totalAmount).ToString();
               txtQuantity.Text = "0";            
               SaleListView.Items[index].Remove();
               index = -1;
            }
            else
            {
                MessageBox.Show(MessageConstant.SELECT_ONE);
            }


            //UpDate ကိုဖြုတ်မလား
        }

        private void SaleListView_Click(object sender, EventArgs e)
        {
            index = SaleListView.FocusedItem.Index;
            sellprice = SaleListView.Items[index].SubItems[2].Text;

            cbBookid.Text = SaleListView.Items[index].SubItems[0].Text;
            txtQuantity.Text = SaleListView.Items[index].SubItems[4].Text;
            totalAmount = Int32.Parse(SaleListView.Items[index].SubItems[5].Text);
            //Discount = Int32.Parse(sellprice) * Int32.Parse(SaleListView.Items[index].SubItems[4].Text);
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            String saleQuery, saleID,bookID, title, price, quantity, amount, totalAmount,discountAmount,discountRate;
            Boolean isValid = true;

            discountRate = (discount * 100).ToString() + "%";

            saleID = txtSlipNo.Text.Trim();
            totalAmount = txtTotAmt.Text.Trim();

            if (SaleListView.Items.Count > 0)
            {
                saleQuery = "Insert into SALE Values('" + saleID + "','" + totalAmount + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                SqlCommand mycmd = new SqlCommand(saleQuery, consql);
                mycmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show(MessageConstant.SALE.SALE_CONFIRM);
                isValid = false;
            }

            if (isValid)
            {
                for (int i = 0; i < SaleListView.Items.Count; i++)
                {
                    String format = "000000";
                    bookID = SaleListView.Items[i].SubItems[0].Text;
                    title = SaleListView.Items[i].SubItems[1].Text;
                    price = SaleListView.Items[i].SubItems[2].Text;
                    discountAmount = SaleListView.Items[i].SubItems[3].Text;
                    quantity = SaleListView.Items[i].SubItems[4].Text;
                    amount = SaleListView.Items[i].SubItems[5].Text;
                    connection();

                    String saleDetailQuery = "Insert into SALE_DETAIL Values('" + "SD" + (i + 1).ToString(format) + "','" + saleID + "','" + bookID + "','" + quantity + "','" + price + "','" + discountRate + "','" + discountAmount + "','" + amount + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                    SqlCommand saleCmd = new SqlCommand(saleDetailQuery, consql);
                    saleCmd.ExecuteNonQuery();

                    //aung
                    String saleQuantity = "SELECT BOOK_QTY FROM STOCK WHERE BOOK_ID = '" + bookID + "'";
                    SqlDataAdapter daSaleQty = new SqlDataAdapter(saleQuantity, consql);
                    DataSet dsSaleQty = new DataSet();
                    daSaleQty.Fill(dsSaleQty,"QTY");

                    int stockqty = int.Parse(dsSaleQty.Tables["QTY"].Rows[0].ItemArray[0].ToString());
                    quantity = (stockqty - int.Parse(quantity)).ToString();

                    String stockQtyQuery = "UPDATE STOCK SET BOOK_QTY='" + quantity + "',LAST_UPDATED_DATE = '" + DateTime.Now + "' WHERE BOOK_ID='"+ bookID +"'";
                    SqlCommand stockCmd = new SqlCommand(stockQtyQuery, consql);
                    stockCmd.ExecuteNonQuery();

                }
                VoucherForm voucher = new VoucherForm(this,saleID);
                voucher.Show();
            } 

        }
       
    }
}
