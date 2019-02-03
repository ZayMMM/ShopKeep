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
        String test;
        public DamageLossEntry(DamageLoss damageloss,String test)
        {
            InitializeComponent();
            this.damageloss = damageloss;
            this.test = test;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

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

    }
}
