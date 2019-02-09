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

        String query, file;

        public BookReportForm(String query, String file)
        {
            InitializeComponent();
            this.query = query;
            this.file = file;
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
            String strBook = query;
            DsForReport dsBook = new DsForReport();
            SqlCommand BookCmd = new SqlCommand(strBook, consql);
            BookCmd.CommandType = CommandType.Text;
            SqlDataAdapter Dabook = new SqlDataAdapter(BookCmd);
            Dabook.Fill(dsBook, "BOOKREPORT");
            ReportDocument bookDocument = new ReportDocument();
            bookDocument.Load(CommonConstant.REPORT + file);//"BookReport.rpt");
            bookDocument.SetDataSource(dsBook);
            BookcrystalReportViewer.ReportSource = bookDocument;
            BookcrystalReportViewer.Refresh();
        }

    }
}
