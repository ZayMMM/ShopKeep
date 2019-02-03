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
    public partial class StaffReportForm : Form
    {
        public StaffReportForm()
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

        private void StaffReportForm_Load(object sender, EventArgs e)
        {
            connection();
            String strStaff = "SELECT S.STAFF_NAME,S.PHONE,S.STAFF_DOB,S.GENDER,S.NRC,A.ADDRESS,A.CITY,A.STATE FROM STAFF S INNER JOIN ADDRESS A ON S.ADD_ID = A.ADD_ID";
            DsForReport dsStaff = new DsForReport();
            SqlCommand staffCmd = new SqlCommand(strStaff, consql);
            staffCmd.CommandType = CommandType.Text;
            SqlDataAdapter Dastaff = new SqlDataAdapter(staffCmd);
            Dastaff.Fill(dsStaff, "STAFFREPORT");
            ReportDocument staffDocument = new ReportDocument();
            staffDocument.Load(CommonConstant.REPORT+"StaffReport.rpt");
            staffDocument.SetDataSource(dsStaff);
            StaffcrystalReportViewer.ReportSource = staffDocument;
            StaffcrystalReportViewer.Refresh();

                //StaffcrystalReportViewer

        }
    }
}
