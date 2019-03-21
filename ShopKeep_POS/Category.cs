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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        String constr;
        SqlConnection consql;
        DataTable dtCategory;
        String categoryId,categoryName;
        String sqlStr;

        void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        DataSet Dset;
        void FillData()
        {
            string query = "SELECT CAT_ID,CAT_NAME FROM CATEGORY";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
            adapter.Fill(Dset, "Category");
            dtCategory = Dset.Tables["Category"];
            categoryDataGridView.DataSource = dtCategory;

            categoryDataGridView.Columns[0].HeaderText = "CATEGORY_ID";
            categoryDataGridView.Columns[1].HeaderText = "CATEGORY_NAME";
            

            categoryDataGridView.Columns[0].Width = 130;
            categoryDataGridView.Columns[1].Width = 130;
        }


        public void refreshform()
        {
            connection();
            FillData();
        }

        void getCategoryID()
        {
            string OID = "SELECT CAT_ID FROM CATEGORY ORDER BY CAT_ID";
            string categoryName;
            int categoryID;
            string format = "0000000";
            SqlDataAdapter ad = new SqlDataAdapter(OID, consql);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Category");
            if (ds.Tables["Category"].Rows.Count > 0)
            {
                categoryName = ds.Tables["Category"].Rows[ds.Tables["Category"].Rows.Count - 1][0].ToString();
                categoryID = int.Parse(categoryName.Substring(1, (categoryName.Length - 1)));
                categoryId = "C" + ((categoryID + 1).ToString(format));
            }
            else
            {
                categoryId = "C0000001";
            }
        }

        private void Category_Load(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            categoryName = txtcategory.Text;
            Boolean isValid = true;
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show(MessageConstant.CATEGORY.CATEGORY_NAME);
                isValid = false;
            }
            else
            {
                foreach(char value in categoryName){
                    bool digit = char.IsDigit(value);
                    if (digit)
                    {
                        MessageBox.Show("Category Name should be only Character");
                        isValid = false;
                        break;
                    }
                }
            }

            String selectSql = "select CAT_NAME from CATEGORY where CAT_NAME='" + categoryName + "'";
            SqlCommand cmd = new SqlCommand(selectSql, consql);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(MessageConstant.CATEGORY.EXISTING_CATEGORY_NAME);
                isValid = false;
            }

            if (isValid)
            {
                getCategoryID();
                sqlStr = "INSERT INTO CATEGORY VALUES('" + categoryId + "',N'" + categoryName + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                SqlCommand mycmd = new SqlCommand(sqlStr, consql);
                mycmd.ExecuteNonQuery();
                MessageBox.Show(MessageConstant.INSERT_MSG);
                FillData();
            }
            
        }

        private void categoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;

            i = categoryDataGridView.CurrentRow.Index;
            categoryId = categoryDataGridView.Rows[i].Cells[0].Value.ToString();
            categoryName = categoryDataGridView.Rows[i].Cells[1].Value.ToString();
            txtcategory.Text = categoryDataGridView.Rows[i].Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlStr = "DELETE FROM CATEGORY WHERE CAT_ID='"+categoryId+"'";
            SqlCommand mycmd = new SqlCommand(sqlStr, consql);
            mycmd.ExecuteNonQuery();
            MessageBox.Show(MessageConstant.DELETE_MSG);
            FillData();
            txtcategory.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;
            categoryName = txtcategory.Text;
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show(MessageConstant.CATEGORY.CATEGORY_NAME);
                isValid = false;
            }

            if (isValid)
            {
                sqlStr = "UPDATE CATEGORY SET CAT_NAME='" + txtcategory.Text + "',LAST_UPDATED_DATE='" + DateTime.Now + "' WHERE CAT_ID ='" + categoryId + "'";
                SqlCommand mycmd = new SqlCommand(sqlStr, consql);
                mycmd.ExecuteNonQuery();
                MessageBox.Show(MessageConstant.UPDATE_MSG);
                FillData();
                txtcategory.Clear();
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = Dset.Tables["Category"].DefaultView;
            dv.RowFilter = "CAT_NAME LIKE '%" + txtSearch.Text.Trim() + "%'";
        }

        
    }
}
