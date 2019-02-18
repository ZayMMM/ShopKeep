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
    public partial class DamageLoss : Form
    {
        public DamageLoss()
        {
            InitializeComponent();
        }

        string constr;
        SqlConnection consql;
        DataTable datatabledamage;
        DataSet Dset;
        void connection()
        {
            constr = CommonConstant.DATA_SOURCE ;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        void FillData()
        {
            connection();
            string query = "SELECT D.DEMAGE_ID,D.STOCK_ID,B.BK_TITLE,D.DEMAGE_QTY,D.REASON,D.DEMAGE_CREATED_DATE,D.CREATED_BY FROM DAMAGE D INNER JOIN STOCK S ON S.STOCK_ID = D.STOCK_ID INNER JOIN BOOK B ON B.BOOK_ID = S.BOOK_ID";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
            adapter.Fill(Dset, "Damage");
            datatabledamage = Dset.Tables["Damage"];
            damageDataGridView.DataSource = datatabledamage;

            damageDataGridView.Columns[0].HeaderText = "DamageID";
            damageDataGridView.Columns[1].HeaderText = "StockID";
            damageDataGridView.Columns[2].HeaderText = "TITLE";
            damageDataGridView.Columns[3].HeaderText = "QTY";            
            damageDataGridView.Columns[4].HeaderText = "REASON";
            damageDataGridView.Columns[5].HeaderText = "Created Date";
            damageDataGridView.Columns[6].HeaderText = "Created By";

            damageDataGridView.Columns[0].Visible = false;
            damageDataGridView.Columns[1].Visible = false;

            damageDataGridView.Columns[0].Width = 150;
            damageDataGridView.Columns[1].Width = 150;
            damageDataGridView.Columns[2].Width = 300;
            damageDataGridView.Columns[3].Width = 150;
            damageDataGridView.Columns[4].Width = 150;
            damageDataGridView.Columns[5].Width = 150;
            damageDataGridView.Columns[6].Width = 150;
            


        }

        public void refreshform()
        {
            connection();
            FillData();
        }
        


        private void DamageLoss_Load(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DamageLossEntry damagelossentry = new DamageLossEntry(this,CommonConstant.DB_INSERT);
            damagelossentry.Show();
        }

        private void damageDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = damageDataGridView.CurrentRow.Index;
            DamageLossEntry damagelossentry = new DamageLossEntry(this, CommonConstant.DB_UPDATE);
            damagelossentry.txtBookName.Text = damageDataGridView.Rows[i].Cells[2].Value.ToString();
            damagelossentry.txtQty.Text = damageDataGridView.Rows[i].Cells[3].Value.ToString();
            damagelossentry.txtRemark.Text = damageDataGridView.Rows[i].Cells[4].Value.ToString();
            damagelossentry.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = Dset.Tables["Damage"].DefaultView;
            dv.RowFilter = "BK_TITLE LIKE '%" + txtSearch.Text.Trim() + "%'";
        }
    }
}
