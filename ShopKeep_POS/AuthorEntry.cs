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
    public partial class AuthorEntry : Form
    {
        Author author;
        public string authorid;

        public AuthorEntry(Author author,string test)
        {
            InitializeComponent();
            this.author = author;
            this.test = test;
        }

        string constr;
        SqlConnection consql;
        string test;

        void connection()
        {
            constr = "Data Source=DESKTOP-PN5972M; Initial Catalog=BOOK; Integrated Security=SSPI;";
            consql = new SqlConnection(constr);
            consql.Open();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string authorname, authorsubname,gender;
            authorname = txtName.Text;
            authorsubname = txtSubName.Text;
            if (radioMale.Checked == true)
            { gender = "Male"; }
            else
            { gender = "Female"; }


            connection();

            string str;

            if (test == "I")
            {
                str = "Insert into AUTHOR Values('" + authorid + "',N'" + authorname + "',N'" + authorsubname + "','" + gender + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
            }
            else
            {
                str = "Update AUTHOR Set AUT_NAME=N'" + authorname + "',AUT_SUB_NAME=N'" + authorsubname + "',LAST_UPDATED_DATE='" + DateTime.Now + "' where AUT_ID='" + authorid + "'";
            }
            SqlCommand mycmd = new SqlCommand(str, consql);
            mycmd.ExecuteNonQuery();
            author.connection();
            author.FillData();
            MessageBox.Show("Finish");
            this.Close();         
        }





    }
}
