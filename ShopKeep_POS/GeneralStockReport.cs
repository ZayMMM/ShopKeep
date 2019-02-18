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
    public partial class GeneralStockReport : Form
    {
        public GeneralStockReport()
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
            cbView.DisplayMember = dtView.Columns[1].ToString();
            cbView.ValueMember = dtView.Columns[0].ToString();
        }


        private void checkView_CheckedChanged(object sender, EventArgs e)
        {
            cbView.Enabled = checkView.Checked;
        }


        


        private void cbViewBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbViewBy.Text)
            {
                case "Publisher":
                    FillView("SELECT PUB_ID,PUB_NAME FROM PUBLISHER");
                    break;
                case "Category":
                    FillView("SELECT CAT_ID,CAT_NAME FROM CATEGORY");
                    break;
                case "Author":
                    FillView("SELECT AUT_ID,AUT_NAME FROM AUTHOR");
                    break;
            }
        }

        

        private void ckbxdate_CheckedChanged(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = ckbxdate.Checked;
            dtpEndDate.Enabled = ckbxdate.Checked;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            String query = "SELECT B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,S.BOOK_QTY FROM STOCK S INNER JOIN BOOK B ON S.BOOK_ID = B.BOOK_ID INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN AUTHOR A ON B.AUT_ID = A.AUT_ID";
            String file = "StockReport.rpt";

            if (checkView.Checked && ckbxdate.Checked)
            {
                switch (cbViewBy.Text)
                {
                    case "Publisher":
                        query = "SELECT B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,S.BOOK_QTY FROM STOCK S INNER JOIN BOOK B ON S.BOOK_ID = B.BOOK_ID INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN AUTHOR A ON B.AUT_ID = A.AUT_ID WHERE P.PUB_NAME = N'" + cbView.Text + "' AND S.CREATED_DTAE BETWEEN '" + dtpStartDate.Text + "' AND '" + dtpEndDate.Text + "'";
                        break;
                    case "Category":
                        query = "SELECT B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,S.BOOK_QTY FROM STOCK S INNER JOIN BOOK B ON S.BOOK_ID = B.BOOK_ID INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN AUTHOR A ON B.AUT_ID = A.AUT_ID WHERE C.CAT_NAME = N'" + cbView.Text + "' AND S.CREATED_DTAE BETWEEN '" + dtpStartDate.Text + "' AND '" + dtpEndDate.Text + "'";
                        break;
                    case "Author":
                        query = "SELECT B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,S.BOOK_QTY FROM STOCK S INNER JOIN BOOK B ON S.BOOK_ID = B.BOOK_ID INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN AUTHOR A ON B.AUT_ID = A.AUT_ID WHERE A.AUT_NAME = N'" + cbView.Text + "' AND S.CREATED_DTAE BETWEEN '" + dtpStartDate.Text + "' AND '" + dtpEndDate.Text + "'";
                        break;
                }
            }
            else if (checkView.Checked)
            {
                switch (cbViewBy.Text)
                {
                    case "Publisher":
                        query = "SELECT B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,S.BOOK_QTY FROM STOCK S INNER JOIN BOOK B ON S.BOOK_ID = B.BOOK_ID INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN AUTHOR A ON B.AUT_ID = A.AUT_ID WHERE P.PUB_NAME = N'" + cbView.Text + "'";
                        break;
                    case "Category":
                        query = "SELECT B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,S.BOOK_QTY FROM STOCK S INNER JOIN BOOK B ON S.BOOK_ID = B.BOOK_ID INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN AUTHOR A ON B.AUT_ID = A.AUT_ID WHERE C.CAT_NAME = N'" + cbView.Text + "'";
                        break;
                    case "Author":
                        query = "SELECT B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,S.BOOK_QTY FROM STOCK S INNER JOIN BOOK B ON S.BOOK_ID = B.BOOK_ID INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN AUTHOR A ON B.AUT_ID = A.AUT_ID WHERE A.AUT_NAME = N'" + cbView.Text + "'" ;
                        break;
                }
            }
            else if (ckbxdate.Checked)
            {
                query = "SELECT B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,S.BOOK_QTY FROM STOCK S INNER JOIN BOOK B ON S.BOOK_ID = B.BOOK_ID INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN AUTHOR A ON B.AUT_ID = A.AUT_ID WHERE S.CREATED_DTAE BETWEEN '" + dtpStartDate.Text + "' AND '" + dtpEndDate.Text + "'"; 
            }


            switch (cbViewBy.Text)
            {
                case "Publisher":
                    file = "StockPublisherReport.rpt";
                    break;
                case "Category":
                    file = "StockCategoryReport.rpt";
                    break;
                case "Author":
                    file = "StockAuthorReport.rpt";
                    break;
            }


            StockReportForm bkreport = new StockReportForm(query, file);
            bkreport.Show();
        }
    }
}
