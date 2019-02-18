﻿using System;
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
    public partial class CategoryReportForm : Form
    {
        public CategoryReportForm()
        {
            InitializeComponent();
        }

        public CategoryReportForm(String query)
        {
            InitializeComponent();
            this.query = query;
        }

        String constr;
        SqlConnection consql;
        String query = "SELECT CAT_NAME FROM CATEGORY";

        public void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        private void CategoryReportForm_Load(object sender, EventArgs e)
        {
            connection();
            
            DsForReport dsCategory = new DsForReport();
            SqlCommand CategoryCmd = new SqlCommand(query, consql);
            CategoryCmd.CommandType = CommandType.Text;
            SqlDataAdapter DaCategory = new SqlDataAdapter(CategoryCmd);
            DaCategory.Fill(dsCategory, "CATREPORT");
            ReportDocument CategoryDocument = new ReportDocument();
            CategoryDocument.Load(CommonConstant.REPORT + "CategoryReport.rpt");
            CategoryDocument.SetDataSource(dsCategory);
            CategorycrystalReportViewer.ReportSource = CategoryDocument;
            CategorycrystalReportViewer.Refresh();
        
        }
    }
}
