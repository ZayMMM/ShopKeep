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
    public partial class BookReportForm : Form
    {
        public BookReportForm()
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

        private void BookReportForm_Load(object sender, EventArgs e)
        {
            connection();
            String strBook = "SELECT B.ISBN,B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,B.BK_PURCHASE_PRICE,S.SELL_PRICE FROM BOOK B INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID= B.CAT_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN STOCK S ON B.BOOK_ID = S.BOOK_ID";
            DsForReport dsBook = new DsForReport();
            SqlCommand BookCmd = new SqlCommand(strBook, consql);
            BookCmd.CommandType = CommandType.Text;
            SqlDataAdapter Dabook = new SqlDataAdapter(BookCmd);
            Dabook.Fill(dsBook, "BOOKREPORT");
            ReportDocument bookDocument = new ReportDocument();
            bookDocument.Load(CommonConstant.REPORT + "BookReport.rpt");
            bookDocument.SetDataSource(dsBook);
            BookcrystalReportViewer.ReportSource = bookDocument;
            BookcrystalReportViewer.Refresh();
        }

    }
}
