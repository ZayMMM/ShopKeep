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
    public partial class Category : Form
    {

        SqlConnection conSql;
        String dataSource;
        DataTable CATEGORY;
        String categoryID;

        public Category()
        {
            InitializeComponent();
        }

        private void Add_Category_Load(object sender, EventArgs e)
        {
            dataSource = "Data Source=DESKTOP-PN5972M; Initial Catalog=BOOK; Integrated Security=SSPI;";
            conSql = new SqlConnection(dataSource);
            conSql.Open();
            FillData();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

       

        void getID()
        {
            string CID = "select CATEGORY_ID from CATEGORY ORDER BY CATEGORY_ID";
            string MName = null;
            int MID;
            string format = "00";
            SqlDataAdapter ad = new SqlDataAdapter(CID, conSql);
            DataSet ds = new DataSet();
            ad.Fill(ds, "CATEGORY");


            if (ds.Tables["CATEGORY"].Rows.Count > 0)
            {
                MName = ds.Tables["CATEGORY"].Rows[ds.Tables["CATEGORY"].Rows.Count - 1][0].ToString();
                MID = int.Parse(MName.Substring(1, (MName.Length - 1)));
                categoryID = "C" + (MID + 1).ToString(format);
            }
            else
            {
                categoryID = "C01";
            }

        }

        private void FillData()
        {
            string query = "SELECT CATEGORY_ID,CATEGORY_NAME FROM CATEGORY";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conSql);
            DataSet dSet = new DataSet();

            adapter.Fill(dSet, "CATEGORY");
            CATEGORY = dSet.Tables["CATEGORY"];
            categoryDataGridView.DataSource = CATEGORY;

            categoryDataGridView.Columns[0].HeaderText = "ID";
            categoryDataGridView.Columns[0].Width = 90;

            categoryDataGridView.Columns[1].HeaderText = "CATEGORY NAME";
            categoryDataGridView.Columns[1].Width = 198;


        }

        private void categoryDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = categoryDataGridView.CurrentRow.Index;
            dr = CATEGORY.Rows[i];
            txtCategory.Text = dr[1].ToString();
        }


    }
}
