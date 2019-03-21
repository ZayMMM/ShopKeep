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
    public partial class PublisherEntry : Form
    {
        Publisher publisher;
        String Test;
        public String publisherid;
        public String addressid;
        String name, phone, email, add, cty, state, strAddress, strPublisher;
        DataSet ds = new DataSet();
        SqlConnection consql;
        String constr;


        public PublisherEntry(Publisher publisher,String Test)
        {
            InitializeComponent();
            this.publisher = publisher;
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
                addressid = "A" + ((AID + 1).ToString(format));
            }
            else
            {
                addressid = "A0000001";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;
            name = txtName.Text ;
            phone = txtPhone.Text ;
            email = txtEmail.Text;
            add = txtAddress.Text;
            cty = txtCity.Text;
            state = cbState.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(MessageConstant.PUBLISHER.PUB_NAME);
                isValid = false;
            }else if(string.IsNullOrEmpty(phone)){
                MessageBox.Show(MessageConstant.PUBLISHER.PUB_PHONE);
                isValid = false;
            }else if(string.IsNullOrEmpty(email)){
                MessageBox.Show(MessageConstant.PUBLISHER.PUB_EMAIL);
                isValid = false;
            }else if(string.IsNullOrEmpty(add)){
                MessageBox.Show(MessageConstant.PUBLISHER.PUB_EMAIL);
                isValid = false;
            }else if(!string.IsNullOrEmpty(cty)){
                if (string.IsNullOrEmpty(state))
                {
                    MessageBox.Show(MessageConstant.PUBLISHER.PUB_STATE);
                    isValid = false;
                }
            }

            if (isValid && !string.IsNullOrEmpty(phone))
            {
                try
                {
                    long temp = long.Parse(phone);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(MessageConstant.STAFF.CHECK_PHONE_NO, MessageConstant.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isValid = false;
                }
            }

            if (isValid && !string.IsNullOrEmpty(email))
            {
                bool isMail = CommonFunction.IsEmail(email);
                if (!isMail)
                {
                    MessageBox.Show(MessageConstant.STAFF.CHECK_EMAIL_ADDRESS, MessageConstant.WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isValid = false;
                }
            }


            if (isValid)
            {
                if (Test.Equals(CommonConstant.DB_INSERT))
                {
                    connection();
                    getAddressID();
                    strAddress = "INSERT INTO ADDRESS VALUES ('" + addressid + "',N'" + add + "',N'" + cty + "','" + state + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                    SqlCommand addressCmd = new SqlCommand(strAddress, consql);
                    addressCmd.ExecuteNonQuery();

                    strPublisher = "INSERT INTO PUBLISHER VALUES ('" + publisherid + "','" + addressid + "',N'" + name + "','" + phone + "','" + email + "','" + CommonConstant.UNARCHIVED + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                    SqlCommand staffDetailCmd = new SqlCommand(strPublisher, consql);
                    staffDetailCmd.ExecuteNonQuery();

                    consql.Close();

                    publisher.refreshform();
                    MessageBox.Show(MessageConstant.INSERT_MSG);
                    this.Close();

                }
                else if (Test.Equals(CommonConstant.DB_UPDATE))
                {
                    connection();
                    strAddress = "UPDATE ADDRESS SET ADDRESS='" + add + "',CITY=N'" + cty + "',STATE=N'" + state + "',LAST_UPDATED_DATE='" + DateTime.Now + "' WHERE ADD_ID ='" + addressid + "'";
                    SqlCommand addressCmd = new SqlCommand(strAddress, consql);
                    addressCmd.ExecuteNonQuery();

                    strPublisher = "UPDATE PUBLISHER SET PUB_NAME=N'" + name + "',ADD_ID='" + addressid + "',PUB_EMAIL=N'" + email + "',PUB_PHONE=N'" + phone + "',LAST_UPDATED_DATE='" + DateTime.Now + "' WHERE PUB_ID='" + publisherid + "'";
                    SqlCommand staffCmd = new SqlCommand(strPublisher, consql);
                    staffCmd.ExecuteNonQuery();

                    publisher.refreshform();
                    MessageBox.Show(MessageConstant.UPDATE_MSG);
                    this.Close();
                }
            }
        }
    }
}
