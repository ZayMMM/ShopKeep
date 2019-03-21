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

            Dgstaff.Columns[5].Visible = false;

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
           
            int i;
            i = Dgstaff.CurrentRow.Index;
            
            StaffEntry staffEntry = new StaffEntry(this,CommonConstant.DB_UPDATE);
            staffEntry.txtStaffID.Text = Dgstaff.Rows[i].Cells[0].Value.ToString();
            staffEntry.txtLginID.Text = Dgstaff.Rows[i].Cells[1].Value.ToString(); // Add
            staffEntry.loginID = Dgstaff.Rows[i].Cells[1].Value.ToString();
            staffEntry.addID = Dgstaff.Rows[i].Cells[2].Value.ToString();
            staffEntry.txtStaffName.Text = Dgstaff.Rows[i].Cells[3].Value.ToString();
            staffEntry.txtPassword.Text = Dgstaff.Rows[i].Cells[4].Value.ToString();
            staffEntry.txtConfirmPassword.Text = Dgstaff.Rows[i].Cells[5].Value.ToString();
            staffEntry.cbRole.Text = Dgstaff.Rows[i].Cells[6].Value.ToString();

            if (Dgstaff.Rows[i].Cells[7].Value.ToString() == CommonConstant.MALE)
            {
                staffEntry.radioMale.Checked = true;
            }
            else if (Dgstaff.Rows[i].Cells[7].Value.ToString() == CommonConstant.FEMALE)
            {
                staffEntry.radioFemale.Checked = true;
            }
            staffEntry.dtpDob.Value = DateTime.Parse(Dgstaff.Rows[i].Cells[8].Value.ToString());
            staffEntry.txtEmail.Text = Dgstaff.Rows[i].Cells[9].Value.ToString();
            staffEntry.txtPhoneNum.Text = Dgstaff.Rows[i].Cells[10].Value.ToString();
            staffEntry.txtNRC.Text = Dgstaff.Rows[i].Cells[11].Value.ToString();
            staffEntry.txtAddress.Text = Dgstaff.Rows[i].Cells[12].Value.ToString();
            staffEntry.txtCity.Text = Dgstaff.Rows[i].Cells[13].Value.ToString();
            staffEntry.cbState.Text = Dgstaff.Rows[i].Cells[14].Value.ToString();
            
            
            staffEntry.Show();
        }


        private void Dgstaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int i;
            i = Dgstaff.CurrentRow.Index;

            selectedStaffID = Dgstaff.Rows[i].Cells[0].Value.ToString();
            selectedLoginID = Dgstaff.Rows[i].Cells[1].Value.ToString();
            selectedAddressID = Dgstaff.Rows[i].Cells[2].Value.ToString();
        }



        private void btndel_Click(object sender, EventArgs e)
        {
            MessageBoxButtons button = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(MessageConstant.DELETE_CONFIRM,"Confirmation Window",button,MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
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

                MessageBox.Show("Finish Delete Record", "Information Window", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshform();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = Dset.Tables["STAFF"].DefaultView;
            dv.RowFilter = "STAFF_NAME LIKE '%" + txtSearch.Text.Trim() + "%'";
        }

       
        
    }
}
