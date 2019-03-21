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

        DataSet Dset;
        void FillData()
        {
            string query = "SELECT PUB_ID,P.ADD_ID,PUB_NAME,PUB_PHONE,PUB_EMAIL,ADDRESS,CITY,STATE FROM PUBLISHER P INNER JOIN ADDRESS A ON P.ADD_ID = A.ADD_ID where PUB_ARCHIVED = '"+ CommonConstant.UNARCHIVED +"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
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
            publisherDataGridView.Columns[5].Width = 270;
            publisherDataGridView.Columns[6].Width = 100;
            publisherDataGridView.Columns[7].Width = 100;

            publisherDataGridView.Columns[0].Visible = false;
            publisherDataGridView.Columns[1].Visible = false;
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
            
            int i;
            i = publisherDataGridView.CurrentRow.Index;
            
            PublisherEntry publisherentry = new PublisherEntry(this, CommonConstant.DB_UPDATE);
            publisherentry.publisherid = publisherDataGridView.Rows[i].Cells[0].Value.ToString();
            publisherentry.addressid = publisherDataGridView.Rows[i].Cells[1].Value.ToString();
            publisherentry.txtName.Text = publisherDataGridView.Rows[i].Cells[2].Value.ToString();
            publisherentry.txtPhone.Text = publisherDataGridView.Rows[i].Cells[3].Value.ToString();
            publisherentry.txtEmail.Text = publisherDataGridView.Rows[i].Cells[4].Value.ToString();
            publisherentry.txtAddress.Text = publisherDataGridView.Rows[i].Cells[5].Value.ToString();
            publisherentry.txtCity.Text = publisherDataGridView.Rows[i].Cells[6].Value.ToString();
            publisherentry.cbState.Text = publisherDataGridView.Rows[i].Cells[7].Value.ToString();
            
            publisherentry.Show();
        }

        private void publisherDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = publisherDataGridView.CurrentRow.Index;
                publisherid = publisherDataGridView.Rows[i].Cells[0].Value.ToString();
                addressid = publisherDataGridView.Rows[i].Cells[1].Value.ToString();
          }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string publisherDelSql = "Update PUBLISHER set PUB_ARCHIVED = '"+ CommonConstant.ARCIVED +"' where PUB_ID ='" + publisherid + "'";
            SqlCommand publisherCmd = new SqlCommand(publisherDelSql, consql);
            publisherCmd.ExecuteNonQuery();

            string addressDelSql = "Delete from ADDRESS where ADD_ID ='" + addressid + "'";
            SqlCommand addressCmd = new SqlCommand(addressDelSql, consql);
            addressCmd.ExecuteNonQuery();

            MessageBox.Show("Finish delete this record", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshform();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = Dset.Tables["Publish"].DefaultView;
            dv.RowFilter = "PUB_NAME LIKE '%" + txtSearch.Text.Trim() + "%'";
        }
    }
}
