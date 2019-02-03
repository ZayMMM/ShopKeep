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
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
        }

        String constr;
        SqlConnection consql;
        DataTable dtBook;
        String bookID, authorID, publisherID, categoryID;


        void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        DataSet Dset;
        void FillData()
        {
            String query = "SELECT BOOK_ID,B.AUT_ID,B.CAT_ID,B.PUB_ID,B.ISBN,B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,B.BK_PURCHASE_PRICE" +
            " FROM BOOK B INNER JOIN AUTHOR A ON B.AUT_ID=A.AUT_ID"+
            " INNER JOIN CATEGORY C ON B.CAT_ID=C.CAT_ID"+
            " INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID order by B.BOOK_ID";

            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
            adapter.Fill(Dset, "Book");
            dtBook = Dset.Tables["Book"];
            bookDataGridView.DataSource = dtBook;

            bookDataGridView.Columns[0].HeaderText = "Book ID";
            bookDataGridView.Columns[1].HeaderText = "Author ID";
            bookDataGridView.Columns[2].HeaderText = "Category ID";
            bookDataGridView.Columns[3].HeaderText = "Publisher ID";
            bookDataGridView.Columns[4].HeaderText = "ISBN";
            bookDataGridView.Columns[5].HeaderText = "Title";
            bookDataGridView.Columns[6].HeaderText = "Author Name";
            bookDataGridView.Columns[7].HeaderText = "Category Name";
            bookDataGridView.Columns[8].HeaderText = "Publisher Name";
            bookDataGridView.Columns[9].HeaderText = "Purchase Price";

            bookDataGridView.Columns[0].Visible = false;
            bookDataGridView.Columns[1].Visible = false;
            bookDataGridView.Columns[2].Visible = false;
            bookDataGridView.Columns[3].Visible = false;

            bookDataGridView.Columns[0].Width = 100;
            bookDataGridView.Columns[1].Width = 100;
            bookDataGridView.Columns[2].Width = 100;
            bookDataGridView.Columns[3].Width = 100;
            bookDataGridView.Columns[4].Width = 200;
            bookDataGridView.Columns[5].Width = 150;
            bookDataGridView.Columns[6].Width = 150;
            bookDataGridView.Columns[7].Width = 150;
            bookDataGridView.Columns[8].Width = 150;
            bookDataGridView.Columns[9].Width = 150;
        }


        public void refreshform()
        {
            connection();
            FillData();
        }

        void bookGenerateId()
        {
            string OID = "select BOOK_ID from BOOK ORDER BY BOOK_ID";
            string BName;
            int BID;
            string format = "0000000";
            SqlDataAdapter ad = new SqlDataAdapter(OID, consql);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Book");
            if (ds.Tables["Book"].Rows.Count > 0)
            {
                BName = ds.Tables["Book"].Rows[ds.Tables["Book"].Rows.Count - 1][0].ToString();
                BID = int.Parse(BName.Substring(1, (BName.Length - 1)));
                bookID = "B" + ((BID + 1).ToString(format));
            }
            else
            {
                bookID = "B0000001";
            }
        }

        private void Book_Load(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            bookGenerateId();
            BookEntry bookEntry = new BookEntry(this,CommonConstant.DB_INSERT);
            bookEntry.bookId = bookID;
            bookEntry.Show();
        }

        private void bookDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = bookDataGridView.CurrentRow.Index;
            dr = dtBook.Rows[i];
            BookEntry bookEntry = new BookEntry(this, CommonConstant.DB_UPDATE);
            bookEntry.bookId = dr[0].ToString();
            bookEntry.authorID = dr[1].ToString();
            bookEntry.categoryId = dr[2].ToString();
            bookEntry.publisherId = dr[3].ToString();
            bookEntry.txtISBN.Text = dr[4].ToString();
            bookEntry.txtTitle.Text = dr[5].ToString();
            bookEntry.autName = dr[6].ToString();            
            bookEntry.catName = dr[7].ToString();
            bookEntry.pubName = dr[8].ToString();
            bookEntry.txtPurchaseprice.Text = dr[9].ToString();

            bookEntry.Show();
        }

        private void bookDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = bookDataGridView.CurrentRow.Index;
            dr = dtBook.Rows[i];
            bookID = dr[0].ToString();
            authorID = dr[1].ToString();
            categoryID = dr[2].ToString();
            publisherID = dr[3].ToString();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string bookDelSql = "Delete from BOOK where BOOK_ID ='" + bookID + "'";
            SqlCommand staffCmd = new SqlCommand(bookDelSql, consql);
            staffCmd.ExecuteNonQuery();

            MessageBox.Show("Finish delete this record", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshform();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = Dset.Tables["Book"].DefaultView;
            dv.RowFilter = "BK_TITLE LIKE '%" + txtSearch.Text.Trim() + "%'";
        }


    }
}
