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
        String constr;
        SqlConnection consql;
        DataTable dtStaff;
        String staffID;
        String selectedStaffID, selectedLoginID, selectedAddressID;


        void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }
        DataSet Dset;
        void FillData()
        {
            String query = "SELECT STAFF_ID,S.STAFF_LOGIN_ID,S.ADD_ID,STAFF_NAME,PASSWORD,CON_PASSWORD,ROLE,GENDER,STAFF_DOB,STAFF_MAIL,PHONE,NRC,ADDRESS,CITY,STATE" +
                            " FROM STAFF S INNER JOIN STAFF_LOGIN T ON S.STAFF_LOGIN_ID=T.STAFF_LOGIN_ID" +
                            " INNER JOIN ADDRESS A ON S.ADD_ID=A.ADD_ID order by S.STAFF_ID";

            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
            adapter.Fill(Dset, "STAFF");
            dtStaff = Dset.Tables["STAFF"];
            Dgstaff.DataSource = dtStaff;

            Dgstaff.Columns[0].HeaderText = "Staff ID";
            Dgstaff.Columns[1].HeaderText = "Staff Login ID";
            Dgstaff.Columns[2].HeaderText = "Address ID";
            Dgstaff.Columns[3].HeaderText = "Staff Name";
            Dgstaff.Columns[4].HeaderText = "Password";
            Dgstaff.Columns[5].HeaderText = "Confirm Password";
            Dgstaff.Columns[6].HeaderText = "Role";
            Dgstaff.Columns[7].HeaderText = "Gender";
            Dgstaff.Columns[8].HeaderText = "Date Of Birth";
            Dgstaff.Columns[9].HeaderText = "Staff Mail";
            Dgstaff.Columns[10].HeaderText = "Phone";
            Dgstaff.Columns[11].HeaderText = "NRC No";
            Dgstaff.Columns[12].HeaderText = "Address";
            Dgstaff.Columns[13].HeaderText = "City";
            Dgstaff.Columns[14].HeaderText = "Region";


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
            Dgstaff.Columns[14].Width = 100;

            Dgstaff.Columns[0].Visible = false;
            Dgstaff.Columns[1].Visible = false;
            Dgstaff.Columns[2].Visible = false;
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
            dr = dtStaff.Rows[i];
            StaffEntry staffEntry = new StaffEntry(this,CommonConstant.DB_UPDATE);
            staffEntry.txtStaffID.Text = dr[0].ToString();
            staffEntry.txtLginID.Text = dr[1].ToString(); // Add
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
            staffEntry.dtpDob.Value = DateTime.Parse(dr[8].ToString());
            staffEntry.txtEmail.Text = dr[9].ToString();
            staffEntry.txtPhoneNum.Text = dr[10].ToString();
            staffEntry.txtNRC.Text = dr[11].ToString();
            staffEntry.txtAddress.Text = dr[12].ToString();
            staffEntry.txtCity.Text = dr[13].ToString();
            staffEntry.cbState.Text = dr[14].ToString();
            
            
            staffEntry.Show();
        }


        private void Dgstaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = Dgstaff.CurrentRow.Index;
                dr = dtStaff.Rows[i];
                selectedStaffID = dr[0].ToString();
                selectedLoginID = dr[1].ToString();
                selectedAddressID = dr[2].ToString();
        }



        private void btndel_Click(object sender, EventArgs e)
        {
            string staffDelSql = "Delete from STAFF where STAFF_ID ='" + selectedStaffID + "'";
            SqlCommand staffCmd = new SqlCommand(staffDelSql, consql);
            staffCmd.ExecuteNonQuery();

            string loginDelSql = "Delete from STAFF_LOGIN where STAFF_LOGIN_ID ='" + selectedLoginID + "'";
            SqlCommand loginCmd = new SqlCommand(loginDelSql, consql);
            loginCmd.ExecuteNonQuery();

            string addressDelSql = "Delete from ADDRESS where ADD_ID ='" + selectedAddressID + "'";
            SqlCommand addressCmd = new SqlCommand(addressDelSql, consql);
            addressCmd.ExecuteNonQuery();

            MessageBox.Show("Finish delete this record", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshform();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = Dset.Tables["STAFF"].DefaultView;
            dv.RowFilter = "STAFF_NAME LIKE '%" + txtSearch.Text.Trim() + "%'";
        }

       
        
    }
}
