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
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
        }
        string constr;
        string authorid;
        SqlConnection consql;
        DataTable datatableAuthor;
        string delete;



        public void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        DataSet Dset;
        public void FillData()
        {
            string query = "select AUT_ID,AUT_NAME,AUT_SUB_NAME,GENDER from AUTHOR";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
            adapter.Fill(Dset, "Author");
            datatableAuthor = Dset.Tables["Author"];
            authorDataGridView.DataSource = datatableAuthor;

            authorDataGridView.Columns[0].HeaderText = "ID";
            authorDataGridView.Columns[1].HeaderText = "Name";
            authorDataGridView.Columns[2].HeaderText = "Sub-Name";
            authorDataGridView.Columns[3].HeaderText = "Gender";

            authorDataGridView.Columns[0].Width = 80;
            authorDataGridView.Columns[1].Width = 150;
            authorDataGridView.Columns[2].Width = 150;
            authorDataGridView.Columns[3].Width = 100;

        }

        void getAuthorID()
        {
            connection();
            string OID = "SELECT AUT_ID FROM AUTHOR ORDER BY AUT_ID";
            string AuthorName;
            int AuthorID;
            string format = "000000";
            SqlDataAdapter ad = new SqlDataAdapter(OID, consql);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Author");
            if (ds.Tables["Author"].Rows.Count > 0)
            {
                AuthorName = ds.Tables["Author"].Rows[ds.Tables["Author"].Rows.Count - 1][0].ToString();
                AuthorID = int.Parse(AuthorName.Substring(2, (AuthorName.Length - 2)));
                authorid = "AU" + ((AuthorID + 1).ToString(format));
            }
            else
            {
                authorid = "AU000001";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            getAuthorID();
            AuthorEntry authorEntry = new AuthorEntry(this,CommonConstant.DB_INSERT);
            authorEntry.authorid = authorid;
            authorEntry.Show();
        }

        private void Author_Load(object sender, EventArgs e)
        {
            connection();
            FillData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string str = "Delete from AUTHOR where AUT_ID ='" + delete + "'";
            SqlCommand mycmd = new SqlCommand(str, consql);
            mycmd.ExecuteNonQuery();
            MessageBox.Show("Finish delete this record", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection();
            FillData();
        }

        private void authorDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = authorDataGridView.CurrentRow.Index;
            if (i == 0 || i == datatableAuthor.Rows.Count - 1)
            {
                dr = datatableAuthor.Rows[i];
                delete = dr[0].ToString();
            }

        }

        private void authorDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = authorDataGridView.CurrentRow.Index;
            dr = datatableAuthor.Rows[i];
            AuthorEntry authorentry = new AuthorEntry(this, CommonConstant.DB_UPDATE);
            authorentry.Show();
            authorentry.authorid = dr[0].ToString();
            authorentry.txtName.Text = dr[1].ToString();
            authorentry.txtSubName.Text = dr[2].ToString();
            
            if (dr[3].ToString() == "Male")
            {
                authorentry.radioMale.Checked = true;
            }
            else
            {
                authorentry.radioFemale.Checked = true;
            }
            authorentry.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = Dset.Tables["Author"].DefaultView;
            dv.RowFilter = "AUT_NAME LIKE '%" + txtSearch.Text.Trim() + "%'";

        }



    }
}
