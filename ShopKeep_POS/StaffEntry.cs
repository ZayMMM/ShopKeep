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
    public partial class StaffEntry : Form
    {

        Staff staff;
        //DataSet ds = new DataSet();
        public String addID;
        public String loginID;
        string id, name, dob, nrc, add, cty, state, email, gen, password, confirmPwd, role, phone, Test, constr, strStaff, strStaffDetail, strAddress;
        SqlConnection consql;
        Boolean isValid = true;

        public StaffEntry(Staff staff,string Test)
        {
            InitializeComponent();
            this.staff = staff;
            this.Test = Test;
        }

        void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        void getAddressID()
        {
            string addressID = "select ADD_ID from ADDRESS ORDER BY ADD_ID";
            string AName;
            int AID;
            string format = "0000000";
            SqlDataAdapter ad = new SqlDataAdapter(addressID, consql);
            DataSet ds = new DataSet();
            ad.Fill(ds, "ADDRESS");

            if (ds.Tables["ADDRESS"].Rows.Count > 0)
            {
                AName = ds.Tables["ADDRESS"].Rows[ds.Tables["ADDRESS"].Rows.Count - 1][0].ToString();
                AID = int.Parse(AName.Substring(1, (AName.Length - 1)));
                addID = "A" + ((AID + 1).ToString(format));
            }
            else
            {
                addID = "A0000001";
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            
            id = txtStaffID.Text;
            name = txtStaffName.Text.Trim();
            dob = dtpDob.Text.Trim();
            phone = txtPhoneNum.Text.Trim();
            nrc = txtNRC.Text.Trim();
            if (radioMale.Checked == true)
            { gen = CommonConstant.MALE; }
            else if(radioFemale.Checked == true)
            { gen = CommonConstant.FEMALE; }
            add = txtAddress.Text.Trim();
            cty = txtCity.Text.Trim();
            state = cbState.Text.Trim();
            email = txtEmail.Text.Trim();

            password = txtPassword.Text.Trim();
            confirmPwd = txtConfirmPassword.Text.Trim();
            role = cbRole.Text.Trim();

            if(string.IsNullOrEmpty(role)){
                MessageBox.Show(MessageConstant.STAFF.ROLE);
                isValid = false;

            }else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show(MessageConstant.STAFF.PASSWORD);
                isValid = false;

            }else if (string.IsNullOrEmpty(confirmPwd))
            {
                MessageBox.Show(MessageConstant.STAFF.COMFIRM_PASSWORD);
                isValid = false;

            }else if (!password.Equals(confirmPwd))
            {
                MessageBox.Show(MessageConstant.STAFF.NOT_MATCH_PASSWORD);
                isValid = false;

            }else if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(MessageConstant.STAFF.NAME);
                isValid = false;

            }else if (string.IsNullOrEmpty(add))
            {
                MessageBox.Show(MessageConstant.STAFF.ADDRESS);
                isValid = false;

            }else if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show(MessageConstant.STAFF.PHONE);
                isValid = false;

            }else if (string.IsNullOrEmpty(nrc))
            {
                MessageBox.Show(MessageConstant.STAFF.NRC);
                isValid = false;

            }else if (string.IsNullOrEmpty(gen))
            {
                MessageBox.Show(MessageConstant.STAFF.GENDER);
                isValid = false;

            }else if (string.IsNullOrEmpty(cty))
            {
                MessageBox.Show(MessageConstant.STAFF.City);
                isValid = false;

            }else if (string.IsNullOrEmpty(state))
            {
                MessageBox.Show(MessageConstant.STAFF.STATE);
                isValid = false;

            }else if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show(MessageConstant.STAFF.EMAIL);
                isValid = false;

            }else
            {
                isValid = true;
            }

            if (isValid)
            {
                if (Test.Equals(CommonConstant.DB_INSERT))
                {
                    getAddressID();
                    strAddress = "INSERT INTO ADDRESS VALUES ('" + addID + "',N'" + add + "',N'" + cty + "','" + state + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                    SqlCommand addressCmd = new SqlCommand(strAddress, consql);
                    addressCmd.ExecuteNonQuery();

                    strStaffDetail = "INSERT INTO STAFF_DETAIL VALUES ('" + loginID + "','" + password + "','" + confirmPwd + "','" + role + "','0','0','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                    SqlCommand staffCmd = new SqlCommand(strStaffDetail, consql);
                    staffCmd.ExecuteNonQuery();

                    strStaff = "INSERT INTO STAFF VALUES ('" + id + "','" + loginID + "','" + addID + "',N'" + name + "','" + gen + "','" + email + "','"+phone+"','"+nrc+"','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                    SqlCommand staffDetailCmd = new SqlCommand(strStaff, consql);
                    staffDetailCmd.ExecuteNonQuery();

                    consql.Close();

                    staff.refreshform();
                    MessageBox.Show(MessageConstant.INSERT_MSG);
                    this.Close();

                }else if(Test.Equals(CommonConstant.DB_UPDATE)){
                    strAddress = "UPDATE ADDRESS SET ADDRESS='" + add + "',CITY=N'" + cty + "',STATE=N'" + state + "',LAST_UPDATED_DATE='" + DateTime.Now + "' WHERE ADD_ID ='"+addID+"'";
                    SqlCommand addressCmd = new SqlCommand(strAddress, consql);
                    addressCmd.ExecuteNonQuery();

                    strStaffDetail = "UPDATE STAFF_DETAIL SET PASSWORD=N'" + password + "',CON_PASSWORD=N'" + confirmPwd + "',ROLE='" + role + "',LAST_UPDATED_DATE='" + DateTime.Now + "' WHERE STAFF_LOGIN_ID='" + loginID + "'";
                    SqlCommand staffDetailCmd = new SqlCommand(strStaffDetail, consql);
                    staffDetailCmd.ExecuteNonQuery();

                    strStaff = "UPDATE STAFF SET STAFF_NAME=N'" + name + "',GENDER='" + gen + "',STAFF_MAIL=N'" + email + "',PHONE=N'" + phone + "',NRC=N'" + nrc + "',LAST_UPDATED_DATE='" + DateTime.Now + "' WHERE STAFF_ID='" + id + "'";
                    SqlCommand staffCmd = new SqlCommand(strStaff, consql);
                    staffCmd.ExecuteNonQuery();

                    staff.refreshform();
                    MessageBox.Show(MessageConstant.UPDATE_MSG);
                    this.Close();
                }
            }           
        }

        

        void getLoginID()
        {
            string LoginSql = "select STAFF_LOGIN_ID from STAFF_DETAIL ORDER BY STAFF_LOGIN_ID";
            string LName;
            int LID;
            string format = "0000000";
            SqlDataAdapter ad = new SqlDataAdapter(LoginSql, consql);
            DataSet ds = new DataSet();
            ad.Fill(ds, "STAFF_DETAIL");

            if (ds.Tables["STAFF_DETAIL"].Rows.Count > 0)
            {
                LName = ds.Tables["STAFF_DETAIL"].Rows[ds.Tables["STAFF_DETAIL"].Rows.Count - 1][0].ToString();
                LID = int.Parse(LName.Substring(1, (LName.Length - 1)));
                loginID = "L" + ((LID + 1).ToString(format));
            }
            else
            {
                loginID = "L0000001";
            }
        }

        private void StaffEntry_Load(object sender, EventArgs e)
        {
            connection();
            getLoginID();
            txtLginID.Text = loginID;
        }           

       
    }
}
