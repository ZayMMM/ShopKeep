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
    public partial class DamageLossReportForm : Form
    {
        public DamageLossReportForm()
        {
            InitializeComponent();
        }

        public String query, file;

        String constr;
        SqlConnection consql;

        public void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        private void DamageLossReportForm_Load(object sender, EventArgs e)
        {
            connection();
            String strdmglos = query;
            DsForReport dsdmglos = new DsForReport();
            SqlCommand dmglosCmd = new SqlCommand(strdmglos, consql);
            dmglosCmd.CommandType = CommandType.Text;
            SqlDataAdapter Dadmglos = new SqlDataAdapter(dmglosCmd);
            Dadmglos.Fill(dsdmglos, "DAMAGEREPORT");
            ReportDocument dmglosDocument = new ReportDocument();
            dmglosDocument.Load(CommonConstant.REPORT + file);//"BookReport.rpt");
            dmglosDocument.SetDataSource(dsdmglos);
            dmgLoscrystalReportViewer.ReportSource = dmglosDocument;
            dmgLoscrystalReportViewer.Refresh();
            
        }
    }
}
