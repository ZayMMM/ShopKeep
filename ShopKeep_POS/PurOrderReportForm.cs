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
    public partial class PurOrderReportForm : Form
    {
        public PurOrderReportForm()
        {
            InitializeComponent();
        }

        String query,file;

        public PurOrderReportForm(String query, String file)
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

        private void PurOrderReportForm_Load(object sender, EventArgs e)
        {
            connection();
            String strPurOrder = query;
            DsForReport dsPurOrder = new DsForReport();
            SqlCommand PurOrderCmd = new SqlCommand(strPurOrder, consql);
            PurOrderCmd.CommandType = CommandType.Text;
            SqlDataAdapter DaSale = new SqlDataAdapter(PurOrderCmd);
            DaSale.Fill(dsPurOrder, "ORDERREPORT");
            ReportDocument purOrderDocument = new ReportDocument();
            purOrderDocument.Load(CommonConstant.REPORT + file);
            purOrderDocument.SetDataSource(dsPurOrder);
            purordercrystalReportViewer.ReportSource = purOrderDocument;
            purordercrystalReportViewer.Refresh();
           
        }
    }
}
