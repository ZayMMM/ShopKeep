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
            string query = "SELECT AUT_ID,AUT_NAME,AUT_SUB_NAME,GENDER FROM AUTHOR WHERE AUT_ARCHIVED = '"+CommonConstant.UNARCHIVED+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
            adapter.Fill(Dset, "Author");
            datatableAuthor = Dset.Tables["Author"];
            authorDataGridView.DataSource = datatableAuthor;

            authorDataGridView.Columns[0].HeaderText = "ID";
            authorDataGridView.Columns[1].HeaderText = "Name";
            authorDataGridView.Columns[2].HeaderText = "Sub-Name";
            authorDataGridView.Columns[3].HeaderText = "Gender";

            authorDataGridView.Columns[0].Width = 100;
            authorDataGridView.Columns[1].Width = 150;
            authorDataGridView.Columns[2].Width = 150;
            authorDataGridView.Columns[3].Width = 150;

            authorDataGridView.Columns[0].Visible = false;

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

            Int32 selectedCellCount = authorDataGridView.GetCellCount(DataGridViewElementStates.Selected);
            Int32 selectedRowCount = authorDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (!string.IsNullOrEmpty(delete))
            {
                DialogResult result = MessageBox.Show(MessageConstant.DELETE_CONFIRM, "Coniframtion Box", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
               if (result.Equals(DialogResult.OK))
                 {
                   string str = "Update AUTHOR set AUT_ARCHIVED ='" + CommonConstant.ARCIVED + "' where AUT_ID = '" + delete + "'";
                   SqlCommand mycmd = new SqlCommand(str, consql);
                   mycmd.ExecuteNonQuery();
                   MessageBox.Show("Finish delete this record", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   connection();
                   FillData();
                 }
            }
            else
            {
                MessageBox.Show(MessageConstant.SELECT_ONE, MessageConstant.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void authorDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = authorDataGridView.CurrentRow.Index;
            delete = authorDataGridView.Rows[i].Cells[0].Value.ToString();
        }

        private void authorDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = authorDataGridView.CurrentRow.Index;
            AuthorEntry authorentry = new AuthorEntry(this, CommonConstant.DB_UPDATE);
            authorentry.Show();
            authorentry.authorid = authorDataGridView.Rows[i].Cells[0].Value.ToString();
            authorentry.txtName.Text = authorDataGridView.Rows[i].Cells[1].Value.ToString();
            authorentry.txtSubName.Text = authorDataGridView.Rows[i].Cells[2].Value.ToString();

            if (authorDataGridView.Rows[i].Cells[3].Value.ToString() == "Male")
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
