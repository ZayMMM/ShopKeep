using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopKeep_POS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection conSql;
        String dataSource;
        String userId, password;
        Boolean isValid = true;
       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            userId = txtUName.Text.Trim();
            password = txtPwd.Text.Trim();

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show(MessageConstant.LOGIN.USER_ID);
                isValid = false;
            }else if(string.IsNullOrEmpty(password))
            {
                MessageBox.Show(MessageConstant.LOGIN.PASSWORD);
                isValid = false;
            }

           if(isValid){
                String selectSql = "select STAFF_LOGIN_ID,PASSWORD from STAFF_LOGIN where STAFF_LOGIN_ID='" + userId + "' and PASSWORD='" + password + "'";
                SqlCommand cmd = new SqlCommand(selectSql, conSql);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        String selectLoginName = "select S.STAFF_NAME,SL.ROLE from STAFF S INNER JOIN STAFF_LOGIN SL ON S.STAFF_LOGIN_ID = SL.STAFF_LOGIN_ID where S.STAFF_LOGIN_ID ='" + txtUName.Text.Trim() + "'";
                    
                    SqlDataAdapter selectLoginNameAdapter = new SqlDataAdapter(selectLoginName,conSql);
                    DataSet dsLoginName = new DataSet();
                    selectLoginNameAdapter.Fill(dsLoginName, "LoginName");
                    DataTable selectLoginNameDt = new DataTable();
                    selectLoginNameDt = dsLoginName.Tables["LoginName"];

                    CommonConstant.CREATED_BY = selectLoginNameDt.Rows[0][0].ToString();
                    String role = selectLoginNameDt.Rows[0][1].ToString();
                        
                    this.Hide();
                    if (role.Equals("Manager"))
                    {
                        Master master = new Master();
                        master.ShowDialog();
                    }else
                    {
                        SubMaster master = new SubMaster();
                        master.ShowDialog();
                    }
                    
                
                }
                else
                {
                 MessageBox.Show("Invalid Login please check username and password");
                    clearTextBox();
                } 

                    conSql.Close();  
           }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            dataSource = CommonConstant.DATA_SOURCE;
            conSql = new SqlConnection(dataSource);
            conSql.Open();
        }

        private void clearTextBox()
        {
            txtUName.Text = "";
            txtPwd.Text = "";
        }
    }
}
