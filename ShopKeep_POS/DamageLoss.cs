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
        void connection()
        {
            constr = CommonConstant.DATA_SOURCE ;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        void FillData()
        {
            connection();
            string query = "SELECT * FROM DEMAGE";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet Dset = new DataSet();
            adapter.Fill(Dset, "Damage");
            datatabledamage = Dset.Tables["Damage"];
            damageDataGridView.DataSource = datatabledamage;

            damageDataGridView.Columns[0].HeaderText = "DamageID";
            damageDataGridView.Columns[1].HeaderText = "StockID";
            damageDataGridView.Columns[2].HeaderText = "QTY";            
            damageDataGridView.Columns[3].HeaderText = "Created Date";
            damageDataGridView.Columns[4].HeaderText = "Created By";            

            damageDataGridView.Columns[0].Width = 100;
            damageDataGridView.Columns[1].Width = 100;
            damageDataGridView.Columns[2].Width = 100;
            damageDataGridView.Columns[3].Width = 100;
            damageDataGridView.Columns[4].Width = 100;
            


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
            DamageLossEntry damagelossentry = new DamageLossEntry(this, CommonConstant.DB_UPDATE);
            damagelossentry.Show();
        }
    }
}
