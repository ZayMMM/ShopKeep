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
    public partial class PurOrderconfirm : Form
    {
        PurOrderList purorlst;

        public String constr,orderID;
        SqlConnection consql;
        public void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        public PurOrderconfirm(PurOrderList purorlst)
        {
            InitializeComponent();
            this.purorlst = purorlst;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String Confirm,strConfirm;
            if (rbProgress.Checked)
            {
                Confirm = "Progress";
            }else if(rbSuccess.Checked)
            {
                Confirm = "Success";
            }
            else
            {
                Confirm = "Cancel";
            }
            connection();
            strConfirm = "UPDATE PURCHASE_ORDER SET ORDER_STATUS='" + Confirm + "' WHERE ORDER_ID ='" + orderID + "'";
            SqlCommand mycmd = new SqlCommand(strConfirm, consql);
            mycmd.ExecuteNonQuery();
            MessageBox.Show(CommonConstant.DB_UPDATE);
            purorlst.connection();
            purorlst.FillData();
            this.Close();
            

        }
    }
}
