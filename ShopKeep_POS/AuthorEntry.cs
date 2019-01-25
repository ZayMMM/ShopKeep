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
        

        public AuthorEntry(Author author,String Test)
        {
            InitializeComponent();
            this.author = author;
            this.Test = Test;
        }

        String constr;
        SqlConnection consql;
        String Test;
        public String authorid;
        string authorname, authorsubname, gen;

        void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;
            authorname = txtName.Text;
            authorsubname = txtSubName.Text;
            if (radioMale.Checked == true)
            { gen = CommonConstant.MALE; }
            else if (radioFemale.Checked == true)
            { gen = CommonConstant.FEMALE; }

            if (string.IsNullOrEmpty(authorname))
            {
                MessageBox.Show(MessageConstant.AUTHOR.AUTHOR_NAME);
                isValid = false;
            }




            connection();

            string strAuthor;

            if (isValid)
            {
                if (Test.Equals(CommonConstant.DB_INSERT))
                {
                    strAuthor = "Insert into AUTHOR Values('" + authorid + "',N'" + authorname + "',N'" + authorsubname + "','" + gen + "','" + CommonConstant.CREATED_BY + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                    SqlCommand mycmd = new SqlCommand(strAuthor, consql);
                    mycmd.ExecuteNonQuery();
                    author.connection();
                    author.FillData();
                    MessageBox.Show(MessageConstant.INSERT_MSG);
                    this.Close();
                }
                else if (Test.Equals(CommonConstant.DB_UPDATE))
                {
                    strAuthor = "Update AUTHOR Set AUT_NAME=N'" + authorname + "',AUT_SUB_NAME=N'" + authorsubname + "',GENDER = '" + gen + "',LAST_UPDATED_DATE='" + DateTime.Now + "' where AUT_ID='" + authorid + "'";
                    SqlCommand mycmd = new SqlCommand(strAuthor, consql);
                    mycmd.ExecuteNonQuery();
                    author.connection();
                    author.FillData();
                    MessageBox.Show(MessageConstant.UPDATE_MSG);
                    this.Close();
                }
            }
                     
        }

       





    }
}
