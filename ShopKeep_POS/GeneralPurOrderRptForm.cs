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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ShopKeep_POS
{
    public partial class GeneralPurOrderRptForm : Form
    {
        public GeneralPurOrderRptForm()
        {
            InitializeComponent();
        }

        String constr;
        SqlConnection consql;

        public void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        void FillView(String choice)
        {
            connection();
            SqlDataAdapter daView = new SqlDataAdapter(choice, consql);
            DataSet dsView = new DataSet();
            DataTable dtView;
            daView.Fill(dsView, "View");
            dtView = dsView.Tables["View"];
            cbView.DataSource = dtView;
            cbView.DisplayMember = dtView.Columns[0].ToString();
            
            
            if(!cbViewBy.Text.Equals("Order Status"))
            {
                cbView.ValueMember = dtView.Columns[1].ToString();    
            }
            
        }

        

        private void checkView_CheckedChanged(object sender, EventArgs e)
        {
            cbView.Enabled = checkView.Checked;
        }

        private void ckbxdate_CheckedChanged(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = ckbxdate.Checked;
            dtpEndDate.Enabled = ckbxdate.Checked;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            String query = "SELECT OD.ORDER_ID,OD.CREATED_BY,PO.ORDER_STATUS,PO.DUE_DATE,P.PUB_NAME,PO.OR_AMOUNT,B.BK_TITLE,OD.QUANTITY,OD.OD_AMOUNT FROM ORDER_DETAIL OD INNER JOIN PURCHASE_ORDER PO ON OD.ORDER_ID = PO.ORDER_ID INNER JOIN BOOK B ON B.BOOK_ID = OD.BOOK_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID ORDER BY OD.ORDER_ID";
            String file = "PurOrderReport.rpt";

            if (checkView.Checked && ckbxdate.Checked)
            {
                switch (cbViewBy.Text)
                {
                    case "Publisher":
                        query = "SELECT OD.ORDER_ID,OD.CREATED_BY,PO.ORDER_STATUS,PO.DUE_DATE,P.PUB_NAME,PO.OR_AMOUNT,B.BK_TITLE,OD.QUANTITY,OD.OD_AMOUNT FROM ORDER_DETAIL OD INNER JOIN PURCHASE_ORDER PO ON OD.ORDER_ID = PO.ORDER_ID INNER JOIN BOOK B ON B.BOOK_ID = OD.BOOK_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE P.PUB_NAME = N'"+cbView.Text+"' PO.CREATED_DATE BETWEEN '" + dtpStartDate.Text + "' AND '" + dtpEndDate.Text + "' ORDER BY OD.ORDER_ID";
                        break;
                    case "Order Status":
                        query = "SELECT OD.ORDER_ID,OD.CREATED_BY,PO.ORDER_STATUS,PO.DUE_DATE,P.PUB_NAME,PO.OR_AMOUNT,B.BK_TITLE,OD.QUANTITY,OD.OD_AMOUNT FROM ORDER_DETAIL OD INNER JOIN PURCHASE_ORDER PO ON OD.ORDER_ID = PO.ORDER_ID INNER JOIN BOOK B ON B.BOOK_ID = OD.BOOK_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE PO.ORDER_STATUS = N'"+cbView.Text+"' PO.CREATED_DATE BETWEEN '" + dtpStartDate.Text + "' AND '" + dtpEndDate.Text + "' ORDER BY OD.ORDER_ID";
                        break;
                }
            }
            else if (checkView.Checked)
            {
                switch (cbViewBy.Text)
                {
                    case "Publisher":
                        query = "SELECT OD.ORDER_ID,OD.CREATED_BY,PO.ORDER_STATUS,PO.DUE_DATE,P.PUB_NAME,PO.OR_AMOUNT,B.BK_TITLE,OD.QUANTITY,OD.OD_AMOUNT FROM ORDER_DETAIL OD INNER JOIN PURCHASE_ORDER PO ON OD.ORDER_ID = PO.ORDER_ID INNER JOIN BOOK B ON B.BOOK_ID = OD.BOOK_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE P.PUB_NAME = N'" + cbView.Text + "' ORDER BY OD.ORDER_ID";
                        break;
                    case "Order Status":
                        query = "SELECT OD.ORDER_ID,OD.CREATED_BY,PO.ORDER_STATUS,PO.DUE_DATE,P.PUB_NAME,PO.OR_AMOUNT,B.BK_TITLE,OD.QUANTITY,OD.OD_AMOUNT FROM ORDER_DETAIL OD INNER JOIN PURCHASE_ORDER PO ON OD.ORDER_ID = PO.ORDER_ID INNER JOIN BOOK B ON B.BOOK_ID = OD.BOOK_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE PO.ORDER_STATUS = N'" + cbView.Text + "' ORDER BY OD.ORDER_ID";
                        break;
                }
            }
            else if (ckbxdate.Checked)
            {
                query = "SELECT OD.ORDER_ID,OD.CREATED_BY,PO.ORDER_STATUS,PO.DUE_DATE,P.PUB_NAME,PO.OR_AMOUNT,B.BK_TITLE,OD.QUANTITY,OD.OD_AMOUNT FROM ORDER_DETAIL OD INNER JOIN PURCHASE_ORDER PO ON OD.ORDER_ID = PO.ORDER_ID INNER JOIN BOOK B ON B.BOOK_ID = OD.BOOK_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE PO.CREATED_DATE BETWEEN '" + dtpStartDate.Text + "' AND '" + dtpEndDate.Text + "' ORDER BY OD.ORDER_ID";
            }


            PurOrderReportForm purorreport = new PurOrderReportForm(query, file);
            purorreport.Show();
        }

        private void cbViewBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbViewBy.Text)
            {
                case "Publisher":
                    FillView("SELECT PUB_NAME,PUB_ID FROM PUBLISHER");
                    break;
                case "Order Status":
                    FillView("SELECT PO.ORDER_STATUS FROM PURCHASE_ORDER PO GROUP BY PO.ORDER_STATUS");
                    break;
            }
        }

        private void GeneralPurOrderRptForm_Load(object sender, EventArgs e)
        {

        }



    }
}
