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
    public partial class SaleReportForm : Form
    {
        public SaleReportForm()
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

        private void SaleReportForm_Load(object sender, EventArgs e)
        {
            connection();
            String strSale = "SELECT B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE, SUM(SD.SALE_QTY) AS SALE_QTY,SUM(SD.AMOUNT) AS AMOUNT FROM BOOK B INNER JOIN SALE_DETAIL SD ON SD.BOOK_ID=B.BOOK_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID GROUP BY B.BOOK_ID, B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SD.DISCOUNT_RATE ORDER BY SD.DISCOUNT_RATE DESC";
            DsForReport dsSale = new DsForReport();
            SqlCommand SaleCmd = new SqlCommand(strSale, consql);
            SaleCmd.CommandType = CommandType.Text;
            SqlDataAdapter DaSale = new SqlDataAdapter(SaleCmd);
            DaSale.Fill(dsSale, "SALEREPORT");
            ReportDocument SaleDocument = new ReportDocument();
            SaleDocument.Load(CommonConstant.REPORT + "SaleReport.rpt");
            SaleDocument.SetDataSource(dsSale);
            SalecrystalReportViewer.ReportSource = SaleDocument;
            SalecrystalReportViewer.Refresh();
        }
    }
}
