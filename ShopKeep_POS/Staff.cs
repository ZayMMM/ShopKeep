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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }
        string constr;
        SqlConnection consql;
        DataTable dtstaff;
        string staffID;
        string selectedStaffID, selectedLoginID, selectedAddressID;


        void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        void FillData()
        {
            String query = "SELECT STAFF_ID,S.STAFF_LOGIN_ID,S.ADDRESS_ID,STAFF_NAME,PASSWORD,COMFIRM_PASSWORD,ROLE,GENDER,STAFF_MAIL,PHONE,NRC,ADDRESS,CITY,STATE" +
                            " FROM STAFF S FULL OUTER JOIN STAFF_DETAIL T ON S.STAFF_LOGIN_ID=T.STAFF_LOGIN_ID" +
                            " FULL OUTER JOIN ADDRESS A ON S.ADDRESS_ID=A.ADDRESS_ID order by S.STAFF_ID";

            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet Dset = new DataSet();
            adapter.Fill(Dset, "STAFF");
            dtstaff = Dset.Tables["STAFF"];
            Dgstaff.DataSource = dtstaff;


            Dgstaff.Columns[0].Width = 100;
            Dgstaff.Columns[1].Width = 100;
            Dgstaff.Columns[2].Width = 100;
            Dgstaff.Columns[3].Width = 100;
            Dgstaff.Columns[4].Width = 100;
            Dgstaff.Columns[5].Width = 100;
            Dgstaff.Columns[6].Width = 100;
            Dgstaff.Columns[7].Width = 100;
            Dgstaff.Columns[8].Width = 100;
            Dgstaff.Columns[9].Width = 100;
            Dgstaff.Columns[10].Width = 100;
            Dgstaff.Columns[11].Width = 100;
            Dgstaff.Columns[12].Width = 100;
            Dgstaff.Columns[13].Width = 100;
            

        }

        public void refreshform()
        {
            connection();
            FillData();
        }

        void ID()
        {
            string OID = "select STAFF_ID from STAFF ORDER BY STAFF_ID";
            string SName;
            int SID;
            string format = "0000000";
            SqlDataAdapter ad = new SqlDataAdapter(OID, consql);
            DataSet ds = new DataSet();
            ad.Fill(ds, "STAFF");
            if (ds.Tables["STAFF"].Rows.Count > 0)
            {
                SName = ds.Tables["STAFF"].Rows[ds.Tables["STAFF"].Rows.Count - 1][0].ToString();
                SID = int.Parse(SName.Substring(1, (SName.Length - 1)));
                staffID = "S" + ((SID + 1).ToString(format));
            }
            else
            {
                staffID = "S0000001";
            }
        }


        public void Staff_Load(object sender, EventArgs e)
        {
            refreshform();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            ID();
            StaffEntry staffEntry = new StaffEntry(this, CommonConstant.DB_INSERT);
            staffEntry.txtStaffID.Text = staffID;
            staffEntry.Show();
        }

        private void Dgstaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = Dgstaff.CurrentRow.Index;
            dr = dtstaff.Rows[i];
            StaffEntry staffEntry = new StaffEntry(this,CommonConstant.DB_UPDATE);
            staffEntry.txtStaffID.Text = dr[0].ToString();
            staffEntry.loginID = dr[1].ToString();
            staffEntry.addID = dr[2].ToString();
            staffEntry.txtStaffName.Text = dr[3].ToString();
            staffEntry.txtPassword.Text = dr[4].ToString();
            staffEntry.txtConfirmPassword.Text = dr[5].ToString();
            staffEntry.cbRole.Text = dr[6].ToString();

            if (dr[7].ToString() == CommonConstant.MALE)
            {
                staffEntry.radioMale.Checked = true;
            }
            else if (dr[7].ToString() == CommonConstant.FEMALE)
            {
                staffEntry.radioFemale.Checked = true;
            }

            staffEntry.txtEmail.Text = dr[8].ToString();
            staffEntry.txtPhoneNum.Text = dr[9].ToString();
            staffEntry.txtNRC.Text = dr[10].ToString();
            staffEntry.txtAddress.Text = dr[11].ToString();
            staffEntry.txtCity.Text = dr[12].ToString();
            staffEntry.cbState.Text = dr[13].ToString();
            
            staffEntry.Show();
        }
        private void Dgstaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = Dgstaff.CurrentRow.Index;
            dr = dtstaff.Rows[i];
            selectedStaffID = dr[0].ToString();
            selectedLoginID = dr[1].ToString();
            selectedAddressID = dr[2].ToString();
        }



        private void btndel_Click(object sender, EventArgs e)
        {
            string staffDelSql = "Delete from STAFF where STAFF_ID ='" + selectedStaffID + "'";
            SqlCommand staffCmd = new SqlCommand(staffDelSql, consql);
            staffCmd.ExecuteNonQuery();

            string loginDelSql = "Delete from STAFF_DETAIL where STAFF_LOGIN_ID ='" + selectedLoginID + "'";
            SqlCommand loginCmd = new SqlCommand(loginDelSql, consql);
            loginCmd.ExecuteNonQuery();

            string addressDelSql = "Delete from ADDRESS where ADDRESS_ID ='" + selectedAddressID + "'";
            SqlCommand addressCmd = new SqlCommand(addressDelSql, consql);
            addressCmd.ExecuteNonQuery();

            MessageBox.Show("Finish delete this record", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshform();
        }

       
        
    }
}
