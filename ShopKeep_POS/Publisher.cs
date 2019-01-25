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
    public partial class Publisher : Form
    {
        public Publisher()
        {
            InitializeComponent();
        }

        String constr;
        SqlConnection consql;
        DataTable dtpublisher;
        String publisherid;
        String addressid;


        void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        void FillData()
        {
            string query = "SELECT PUB_ID,P.ADD_ID,PUB_NAME,PUB_TEL,PUB_EMAIL,ADDRESS,CITY,STATE FROM PUBLISHER P INNER JOIN ADDRESS A ON P.ADD_ID = A.ADD_ID";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet Dset = new DataSet();
            adapter.Fill(Dset, "Publish");
            dtpublisher = Dset.Tables["Publish"];
            publisherDataGridView.DataSource = dtpublisher;

            publisherDataGridView.Columns[0].HeaderText = "Publisher ID";
            publisherDataGridView.Columns[1].HeaderText = "ADDRESS_ID";
            publisherDataGridView.Columns[2].HeaderText = "Name";
            publisherDataGridView.Columns[3].HeaderText = "Phone No";
            publisherDataGridView.Columns[4].HeaderText = "Email";
            publisherDataGridView.Columns[5].HeaderText = "Address";
            publisherDataGridView.Columns[6].HeaderText = "City";
            publisherDataGridView.Columns[7].HeaderText = "State";

            publisherDataGridView.Columns[0].Width = 80;
            publisherDataGridView.Columns[1].Width = 80;
            publisherDataGridView.Columns[2].Width = 200;
            publisherDataGridView.Columns[3].Width = 100;
            publisherDataGridView.Columns[4].Width = 150;
            publisherDataGridView.Columns[5].Width = 150;
            publisherDataGridView.Columns[6].Width = 100;
            publisherDataGridView.Columns[7].Width = 100;

        }

        public void refreshform()
        {
            connection();
            FillData();
        }

        

        void getPublisherID()
        {
            string OID = "SELECT PUB_ID FROM PUBLISHER ORDER BY PUB_ID";
            string publisherName;
            int PublisherID;
            string format = "0000000";
            SqlDataAdapter ad = new SqlDataAdapter(OID, consql);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Publisher");
            if (ds.Tables["Publisher"].Rows.Count > 0)
            {
                publisherName = ds.Tables["Publisher"].Rows[ds.Tables["Publisher"].Rows.Count - 1][0].ToString();
                PublisherID = int.Parse(publisherName.Substring(1, (publisherName.Length - 1)));
                publisherid = "P" + ((PublisherID + 1).ToString(format));
            }
            else
            {
                publisherid = "P0000001";
            }
        }

        private void Publisher_Load(object sender, EventArgs e)
        {
            refreshform();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            getPublisherID();
            PublisherEntry publisherentry = new PublisherEntry(this,CommonConstant.DB_INSERT);
            publisherentry.publisherid = this.publisherid;
            publisherentry.Show();
        }

        private void publisherDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = publisherDataGridView.CurrentRow.Index;
            dr = dtpublisher.Rows[i];
            PublisherEntry publisherentry = new PublisherEntry(this, CommonConstant.DB_UPDATE);
            publisherentry.publisherid = dr[0].ToString();
            publisherentry.addressid = dr[1].ToString();
            publisherentry.txtName.Text = dr[2].ToString();
            publisherentry.txtPhone.Text = dr[3].ToString();
            publisherentry.txtEmail.Text = dr[4].ToString();
            publisherentry.txtAddress.Text = dr[5].ToString();
            publisherentry.txtCity.Text = dr[6].ToString();
            publisherentry.cbState.Text = dr[7].ToString();
            
            publisherentry.Show();
        }

        private void publisherDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = publisherDataGridView.CurrentRow.Index;
            dr = dtpublisher.Rows[i];
            publisherid = dr[0].ToString();
            addressid = dr[1].ToString();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string publisherDelSql = "Delete from PUBLISHER where PUB_ID ='" + publisherid + "'";
            SqlCommand publisherCmd = new SqlCommand(publisherDelSql, consql);
            publisherCmd.ExecuteNonQuery();

            string addressDelSql = "Delete from ADDRESS where ADD_ID ='" + addressid + "'";
            SqlCommand addressCmd = new SqlCommand(addressDelSql, consql);
            addressCmd.ExecuteNonQuery();

            MessageBox.Show("Finish delete this record", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshform();
        }

        

    }
}
