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
    public partial class BestSellerReportForm : Form
    {
        public BestSellerReportForm()
        {
            InitializeComponent();
        }
        String query;

        public BestSellerReportForm(String query)
        {
            InitializeComponent();
            this.query = query;
        }

        String constr;
        SqlConnection consql;

        public void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        private void BestSellerReportForm_Load(object sender, EventArgs e)
        {
            connection();
            DsForReport dsBestSeller = new DsForReport();
            SqlCommand BestSellerCmd = new SqlCommand(query, consql);
            BestSellerCmd.CommandType = CommandType.Text;
            SqlDataAdapter DabestSeller = new SqlDataAdapter(BestSellerCmd);
            DabestSeller.Fill(dsBestSeller, "BESTSELLREPORT");
            ReportDocument BestSellerDocument = new ReportDocument();
            BestSellerDocument.Load(CommonConstant.REPORT + "BestSellerRpt.rpt");//"BestSellerRpt.rpt");
            BestSellerDocument.SetDataSource(dsBestSeller);
            BestSellercrystalReportViewer.ReportSource = BestSellerDocument;
            BestSellercrystalReportViewer.Refresh();
        }

    }
}
