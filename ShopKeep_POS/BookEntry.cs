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
    public partial class BookEntry : Form
    {
        Book book;
        String Test,constr;
        SqlConnection consql;
        public String bookId,authorID,publisherId,categoryId,ISBN,Title,PurchasePrice;
        public String catName, autName, pubName;
        String strbook;

       // CategoryEntity categoryEntity;

        public BookEntry(Book book,String Test)
        {

            InitializeComponent();
            this.book = book;
            this.Test = Test;
        }

        void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ISBN = txtISBN.Text;
            Title = txtTitle.Text;
            PurchasePrice = txtPurchaseprice.Text;

            authorID = cbAuthor.SelectedValue.ToString();
            categoryId = cbCategory.SelectedValue.ToString();
            publisherId = cbPublisher.SelectedValue.ToString();


            if (Test.Equals(CommonConstant.DB_INSERT))
            {


                strbook = "INSERT INTO BOOK VALUES ('" + bookId + "','" + authorID + "','" + categoryId + "','" + publisherId + "','" + ISBN + "',N'" + Title + "',N'" + PurchasePrice + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                SqlCommand bookCmd = new SqlCommand(strbook, consql);
                bookCmd.ExecuteNonQuery();

                consql.Close();

                book.refreshform();
                MessageBox.Show(MessageConstant.INSERT_MSG);
                this.Close();

            }
            else if (Test.Equals(CommonConstant.DB_UPDATE))
            {
                strbook = "UPDATE BOOK SET AUT_ID='" + authorID + "',CAT_ID='" + categoryId + "',PUB_ID='" + publisherId + "',ISBN='" + ISBN + "',BK_TITLE = N'" + Title + "',BK_PURCHASE_PRICE=N'" + PurchasePrice + "',LAST_UPDATED_DATE='" + DateTime.Now + "' WHERE BOOK_ID ='" + bookId + "'";
                SqlCommand bookCmd = new SqlCommand(strbook, consql);
                bookCmd.ExecuteNonQuery();

                book.refreshform();
                MessageBox.Show(MessageConstant.UPDATE_MSG);
                this.Close();
            }
        }

        void FillAuthor()
        {
            connection();
            SqlDataAdapter daAuthor = new SqlDataAdapter("select AUT_ID,AUT_NAME from AUTHOR", consql);
            DataSet dsAuthor = new DataSet();
            DataTable dtAuthor;
            daAuthor.Fill(dsAuthor, "Author");
            dtAuthor = dsAuthor.Tables["Author"];
            cbAuthor.DataSource = dtAuthor;
            cbAuthor.DisplayMember = dtAuthor.Columns["AUT_NAME"].ToString() ;
            cbAuthor.ValueMember = dtAuthor.Columns["AUT_ID"].ToString();
        }

        void FillCategory()
        {
            connection();
            SqlDataAdapter daCategory = new SqlDataAdapter("select CAT_ID,CAT_NAME from CATEGORY", consql);
            DataSet dsCategory = new DataSet();
            DataTable dtCategory;
            daCategory.Fill(dsCategory, "Category");
            dtCategory = dsCategory.Tables["Category"];
            cbCategory.DataSource = dtCategory;
            cbCategory.DisplayMember = dtCategory.Columns["CAT_NAME"].ToString();
            cbCategory.ValueMember = dtCategory.Columns["CAT_ID"].ToString();            
        }



        void FillPublisher()
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




        private void BookEntry_Load(object sender, EventArgs e)
        {
                FillAuthor();
                FillCategory();
                FillPublisher();

            if(Test.Equals(CommonConstant.DB_UPDATE)){
                cbAuthor.Text = autName;
                cbCategory.Text = catName;
                cbPublisher.Text = pubName;
              }
                
            
        }
    }
}
