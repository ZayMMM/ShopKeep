using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopKeep_POS
{
    public partial class DamageLossEntry : Form
    {
        SqlConnection conSql;
        String dataSource;
        DamageLoss damageloss;
        String test,DamageID;
        public DamageLossEntry(DamageLoss damageloss,String test)
        {
            InitializeComponent();
            this.damageloss = damageloss;
            this.test = test;

        }

        void damageGenerateId()
        {
            string OID = "SELECT DEMAGE_ID FROM DAMAGE ORDER BY DEMAGE_ID";
            string SName;
            int SID;
            string format = "0000000";
            SqlDataAdapter adSale = new SqlDataAdapter(OID, conSql);
            DataSet dsSale = new DataSet();
            adSale.Fill(dsSale, "Damage");
            if (dsSale.Tables["Damage"].Rows.Count > 0)
            {
                SName = dsSale.Tables["Damage"].Rows[dsSale.Tables["Damage"].Rows.Count - 1][0].ToString();
                SID = int.Parse(SName.Substring(1, (SName.Length - 1)));
                DamageID = "D" + ((SID + 1).ToString(format));
            }
            else
            {
                DamageID = "D0000001";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String bookName, bookQty, remark, stockID, stockQty;

            bookName = txtBookName.Text.Trim();
            bookQty = txtQty.Text.Trim();
            remark = txtRemark.Text.Trim();
            Boolean isNull = false; ;

            

            if (string.IsNullOrEmpty(bookName))
            {
                isNull = true;
                MessageBox.Show(MessageConstant.DAMAGE.BOOK_NAME);

            }else if(string.IsNullOrEmpty(bookQty)){

                isNull = true;
                MessageBox.Show(MessageConstant.DAMAGE.BOOK_QTY);

              }
              else if(string.IsNullOrEmpty(remark)){

                isNull = true;
                MessageBox.Show(MessageConstant.DAMAGE.BOOK_REMARK);
            }

            if(!string.IsNullOrEmpty(bookQty)){
                try
                {
                    int bQty = int.Parse(bookQty);
                    bookQty = bQty.ToString();
                }
                catch (Exception ex)
                {
                    isNull = true;
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(MessageConstant.DAMAGE.CHECK_QTY);
                }
            }

                stockID = "";                
                SqlDataAdapter daBookQuery = new SqlDataAdapter("SELECT STOCK_ID from STOCK WHERE BOOK_ID = '" + cbBookId.Text + "'", conSql);
                DataSet dsBookName = new DataSet();
                daBookQuery.Fill(dsBookName, "BOOK");

                stockQty = "";
                SqlDataAdapter daStockQty = new SqlDataAdapter("SELECT BOOK_QTY from STOCK WHERE BOOK_ID = '" + cbBookId.Text + "'", conSql);
                DataSet dsStockQty = new DataSet();
                daStockQty.Fill(dsStockQty, "QTY");

                if (dsBookName.Tables[0].Rows.Count > 0)
                {
                    stockID = dsBookName.Tables[0].Rows[0]["STOCK_ID"].ToString();
                    stockQty = dsStockQty.Tables[0].Rows[0]["BOOK_QTY"].ToString();
                }

            if (!isNull)
            {
                damageGenerateId();
                String insertDamageQuery = "Insert into DAMAGE Values('" + DamageID + "','" + stockID + "','" + bookQty + "','" + remark + "','" + DateTime.Now + "','" + CommonConstant.CREATED_BY + "')";
                SqlCommand mycmd = new SqlCommand(insertDamageQuery, conSql);
                mycmd.ExecuteNonQuery();

                int tempQty = int.Parse(stockQty) - int.Parse(bookQty);
                String updatedQty = tempQty.ToString();
                String updateStock = "UPDATE STOCK SET BOOK_QTY='" + updatedQty + "',LAST_UPDATED_DATE='" + DateTime.Now + "' WHERE STOCK_ID ='" + stockID + "'";
                SqlCommand updateCmd = new SqlCommand(updateStock, conSql);
                updateCmd.ExecuteNonQuery();
                damageloss.refreshform();

                this.Close();
            }

        }

        private void DamageLossEntry_Load(object sender, EventArgs e)
        {
            dataSource = CommonConstant.DATA_SOURCE;
            conSql = new SqlConnection(dataSource);
            conSql.Open();
            fillBookId();
        }

        void fillBookId(){
            SqlDataAdapter daBook = new SqlDataAdapter("SELECT BOOK_ID from STOCK", conSql);
            DataSet dsBook = new DataSet();
            DataTable dtBook;
            daBook.Fill(dsBook, "BookId");
            dtBook = dsBook.Tables["BookId"];
            cbBookId.DataSource = dtBook;

            if (dtBook.Rows.Count > 0)
            {
                cbBookId.DisplayMember = dtBook.Columns["BOOK_ID"].ToString();
                cbBookId.ValueMember = dtBook.Columns["BOOK_ID"].ToString();
            }
            else
            {
                cbBookId.DisplayMember = "";
                cbBookId.ValueMember = "";
            }
        }

        private void cbBookId_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter daBookQuery = new SqlDataAdapter("SELECT BK_TITLE from BOOK WHERE BOOK_ID = '"+ cbBookId.Text +"'", conSql);
            DataSet dsBookName = new DataSet();
            daBookQuery.Fill(dsBookName, "BOOK");

            if(dsBookName.Tables[0].Rows.Count > 0){
                txtBookName.Text = dsBookName.Tables[0].Rows[0]["BK_TITLE"].ToString();
            }
        }

    }
}
