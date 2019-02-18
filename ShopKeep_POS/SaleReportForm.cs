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
        String query, file;

        public SaleReportForm()
        {
            InitializeComponent();
        }

        public SaleReportForm(String query, String file)
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

        private void SaleReportForm_Load(object sender, EventArgs e)
        {
            connection();
            String strSale = query;
            DsForReport dsSale = new DsForReport();
            SqlCommand SaleCmd = new SqlCommand(strSale, consql);
            SaleCmd.CommandType = CommandType.Text;
            SqlDataAdapter DaSale = new SqlDataAdapter(SaleCmd);
            if (file.Equals("SaleStaffReport.rpt"))
            {
                DaSale.Fill(dsSale, "SALEREPORTSTAFF");
            }
            else
            {
                DaSale.Fill(dsSale, "SALEREPORT");
            }
            
            ReportDocument SaleDocument = new ReportDocument();
            SaleDocument.Load(CommonConstant.REPORT + file);
            SaleDocument.SetDataSource(dsSale);
            SalecrystalReportViewer.ReportSource = SaleDocument;
            SalecrystalReportViewer.Refresh();
        }
    }
}
