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
    public partial class AuthorReportForm : Form
    {
        public AuthorReportForm()
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

        private void AuthorReportForm_Load(object sender, EventArgs e)
        {
            connection();
            String strAuthor = "SELECT AUT_NAME,AUT_SUB_NAME,GENDER FROM AUTHOR";
            DsForReport dsAuthor = new DsForReport();
            SqlCommand AuthorCmd = new SqlCommand(strAuthor, consql);
            AuthorCmd.CommandType = CommandType.Text;
            SqlDataAdapter DaAuthor = new SqlDataAdapter(AuthorCmd);
            DaAuthor.Fill(dsAuthor, "AUTREPORT");
            ReportDocument AutohrDocument = new ReportDocument();
            AutohrDocument.Load(CommonConstant.REPORT + "AuthorReport.rpt");
            AutohrDocument.SetDataSource(dsAuthor);
            AuthorcrystalReportViewer.ReportSource = AutohrDocument;
            AuthorcrystalReportViewer.Refresh();
        }
    }
}
