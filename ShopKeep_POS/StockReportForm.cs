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
        String query, file;

        public StockReportForm(String query,String file)
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

        private void StockReportForm_Load(object sender, EventArgs e)
        {
            connection();
            
            DsForReport dsStock = new DsForReport();
            SqlCommand StockCmd = new SqlCommand(query, consql);
            StockCmd.CommandType = CommandType.Text;
            SqlDataAdapter DaStock = new SqlDataAdapter(StockCmd);
            DaStock.Fill(dsStock, "STOCKREPORT");
            ReportDocument StockDocument = new ReportDocument();
            StockDocument.Load(CommonConstant.REPORT + file);
            StockDocument.SetDataSource(dsStock);
            StockcrystalReportViewer.ReportSource = StockDocument;
            StockcrystalReportViewer.Refresh();
        }
    }
}
