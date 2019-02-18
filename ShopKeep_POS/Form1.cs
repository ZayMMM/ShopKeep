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
    public partial class Form1 : Form
    {
        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            connection();
            DsForReport dsBestSeller = new DsForReport();
            SqlCommand BestSellerCmd = new SqlCommand("SELECT TOP 4 B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SUM(SD.SALE_QTY) AS QUANTITY FROM SALE_DETAIL SD INNER JOIN BOOK B ON B.BOOK_ID = SD.BOOK_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE SD.CREATED_DATE BETWEEN '2/1/2019' AND '2/17/2019' GROUP BY B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME ORDER BY QUANTITY DESC", consql);
            BestSellerCmd.CommandType = CommandType.Text;
            SqlDataAdapter DabestSeller = new SqlDataAdapter(BestSellerCmd);
            DabestSeller.Fill(dsBestSeller, "BESTSELLREPORT");
            ReportDocument BestSellerDocument = new ReportDocument();
            BestSellerDocument.Load(CommonConstant.REPORT + "CrystalReport1.rpt");//"BestSellerRpt.rpt");
            BestSellerDocument.SetDataSource(dsBestSeller);
            crystalReportViewer1.ReportSource = BestSellerDocument;
            crystalReportViewer1.Refresh();
            this.Controls.Add(crystalReportViewer1);
            crystalReportViewer1.Dock = DockStyle.Fill;
        }


    }
}
