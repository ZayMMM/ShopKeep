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
    public partial class PublisherReportForm : Form
    {
        public PublisherReportForm()
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

        private void PublisherReportForm_Load(object sender, EventArgs e)
        {
            connection();
            String strPublisher = "SELECT P.PUB_NAME,P.PUB_PHONE,P.PUB_EMAIL,A.ADDRESS,A.CITY,A.STATE FROM PUBLISHER P INNER JOIN ADDRESS A ON A.ADD_ID = P.ADD_ID";
            DsForReport dsPublisher = new DsForReport();
            SqlCommand PublisherCmd = new SqlCommand(strPublisher, consql);
            PublisherCmd.CommandType = CommandType.Text;
            SqlDataAdapter DaPublisher = new SqlDataAdapter(PublisherCmd);
            DaPublisher.Fill(dsPublisher, "PUBREPORT");
            ReportDocument PublisherDocument = new ReportDocument();
            PublisherDocument.Load(CommonConstant.REPORT + "PublisherReport.rpt");
            PublisherDocument.SetDataSource(dsPublisher);
            PublishercrystalReportViewer.ReportSource = PublisherDocument;
            PublishercrystalReportViewer.Refresh();
        }
    }
}
