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
    public partial class GeneralSaleReport : Form
    {
        public GeneralSaleReport()
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

        private void GeneralSaleReport_Load(object sender, EventArgs e)
        {

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
                case "Staff":
                    FillView("SELECT STAFF_ID,STAFF_NAME FROM STAFF");
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
            String query = "SELECT B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE, SUM(SD.SALE_QTY) AS SALE_QTY,SUM(SD.AMOUNT) AS AMOUNT FROM BOOK B INNER JOIN SALE_DETAIL SD ON SD.BOOK_ID=B.BOOK_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID GROUP BY B.BOOK_ID, B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE ORDER BY SD.DISCOUNT_RATE DESC";
            String file = "SaleReport.rpt";

            if (checkView.Checked && ckbxdate.Checked)
            {
                switch (cbViewBy.Text)
                {
                    case "Publisher":
                        query = "SELECT B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE, SUM(SD.SALE_QTY) AS SALE_QTY,SUM(SD.AMOUNT) AS AMOUNT FROM BOOK B INNER JOIN SALE_DETAIL SD ON SD.BOOK_ID=B.BOOK_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE P.PUB_NAME = N'" + cbView.Text + "' AND SD.CREATED_DATE BETWEEN '"+dtpStartDate.Text+"' AND '"+dtpEndDate.Text+"' GROUP BY B.BOOK_ID, B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE";
                        break;
                    case "Category":
                        query = "SELECT B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE, SUM(SD.SALE_QTY) AS SALE_QTY,SUM(SD.AMOUNT) AS AMOUNT FROM BOOK B INNER JOIN SALE_DETAIL SD ON SD.BOOK_ID=B.BOOK_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE C.CAT_NAME = N'" + cbView.Text + "' AND SD.CREATED_DATE BETWEEN '" + dtpStartDate.Text + "' AND '" + dtpEndDate.Text + "' GROUP BY B.BOOK_ID, B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE";
                        break;
                    case "Author":
                        query = "SELECT B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE, SUM(SD.SALE_QTY) AS SALE_QTY,SUM(SD.AMOUNT) AS AMOUNT FROM BOOK B INNER JOIN SALE_DETAIL SD ON SD.BOOK_ID=B.BOOK_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE A.AUT_NAME = N'" + cbView.Text + "' AND SD.CREATED_DATE BETWEEN '" + dtpStartDate.Text + "' AND '" + dtpEndDate.Text + "' GROUP BY B.BOOK_ID, B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE";
                        break;
                    case "Staff":
                        query = "SELECT B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE,SD.CREATED_BY, SUM(SD.SALE_QTY) AS SALE_QTY,SUM(SD.AMOUNT) AS AMOUNT FROM BOOK B INNER JOIN SALE_DETAIL SD ON SD.BOOK_ID=B.BOOK_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE SD.CREATED_BY = N'" + cbView.Text + "' AND SD.CREATED_DATE BETWEEN '" + dtpStartDate.Text + "' AND '" + dtpEndDate.Text + "' GROUP BY B.BOOK_ID, B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE,SD.CREATED_BY ORDER BY SD.CREATED_BY DESC";
                        break;
                }
            }
            else if (checkView.Checked)
            {
                switch (cbViewBy.Text)
                {
                    case "Publisher":
                        query = "SELECT B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE, SUM(SD.SALE_QTY) AS SALE_QTY,SUM(SD.AMOUNT) AS AMOUNT FROM BOOK B INNER JOIN SALE_DETAIL SD ON SD.BOOK_ID=B.BOOK_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE P.PUB_NAME = N'" + cbView.Text + "' GROUP BY B.BOOK_ID, B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE ORDER BY SD.DISCOUNT_RATE DESC";
                        break;
                    case "Category":
                        query = "SELECT B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE, SUM(SD.SALE_QTY) AS SALE_QTY,SUM(SD.AMOUNT) AS AMOUNT FROM BOOK B INNER JOIN SALE_DETAIL SD ON SD.BOOK_ID=B.BOOK_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE C.CAT_NAME = N'" + cbView.Text + "' GROUP BY B.BOOK_ID, B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE ORDER BY SD.DISCOUNT_RATE DESC";
                        break;
                    case "Author":
                        query = "SELECT B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE, SUM(SD.SALE_QTY) AS SALE_QTY,SUM(SD.AMOUNT) AS AMOUNT FROM BOOK B INNER JOIN SALE_DETAIL SD ON SD.BOOK_ID=B.BOOK_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE A.AUT_NAME = N'" + cbView.Text + "' GROUP BY B.BOOK_ID, B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE ORDER BY SD.DISCOUNT_RATE DESC";
                        break;
                    case "Staff":
                        query = "SELECT B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE,SD.CREATED_BY, SUM(SD.SALE_QTY) AS SALE_QTY,SUM(SD.AMOUNT) AS AMOUNT FROM BOOK B INNER JOIN SALE_DETAIL SD ON SD.BOOK_ID=B.BOOK_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE SD.CREATED_BY = N'"+cbView.Text+"' GROUP BY B.BOOK_ID, B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE,SD.CREATED_BY ORDER BY SD.CREATED_BY DESC";
                        break;
                }
            }
            else if (ckbxdate.Checked)
            {
                query = "SELECT B.ISBN,B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,B.BK_PURCHASE_PRICE,S.SELL_PRICE FROM BOOK B INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID= B.CAT_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN STOCK S ON S.BOOK_ID = B.BOOK_ID WHERE B.CREATED_DATE BETWEEN '" + dtpStartDate.Text.Trim() + "' AND '" + dtpEndDate.Text.Trim() + "'";
            }


            switch (cbViewBy.Text)
            {
                case "Publisher":
                    file = "SalePublisherReport.rpt";
                    break;
                case "Category":
                    file = "SaleCategoryReport.rpt";
                    break;
                case "Author":
                    file = "SaleAuthorReport.rpt";
                    break;
                case "Staff":
                    file = "SaleStaffReport.rpt";
                    break;
            }


            SaleReportForm bkreport = new SaleReportForm(query, file);
            bkreport.Show();
        }
    }
}
