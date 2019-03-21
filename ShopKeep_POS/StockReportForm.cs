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
    public partial class StockReportForm : Form
    {
        public StockReportForm()
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

        private void StockReportForm_Load(object sender, EventArgs e)
        {
            connection();
            String strStock = "SELECT B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,S.BOOK_QTY FROM STOCK S INNER JOIN BOOK B ON S.BOOK_ID = B.BOOK_ID INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN AUTHOR A ON B.AUT_ID = A.AUT_ID";
            DsForReport dsStock = new DsForReport();
            SqlCommand StockCmd = new SqlCommand(strStock, consql);
            StockCmd.CommandType = CommandType.Text;
            SqlDataAdapter DaStock = new SqlDataAdapter(StockCmd);
            DaStock.Fill(dsStock, "STOCKREPORT");
            ReportDocument StockDocument = new ReportDocument();
            StockDocument.Load(CommonConstant.REPORT + "StockReport.rpt");
            StockDocument.SetDataSource(dsStock);
            StockcrystalReportViewer.ReportSource = StockDocument;
            StockcrystalReportViewer.Refresh();
        }
    }
}
