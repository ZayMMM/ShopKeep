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
    public partial class VoucherForm : Form
    {
        Sale sale;
        String saleID;

        public VoucherForm(Sale sale,String saleID)
        {
            InitializeComponent();
            this.sale = sale;
            this.saleID = saleID;
        }

        String constr;
        SqlConnection consql;

        public void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        private void VoucherForm_Load(object sender, EventArgs e)
        {
            connection();
           
            String strVoucher = "SELECT B.BK_TITLE,S.SELL_PRICE,SA.SALE_QTY,SA.AMOUNT FROM SALE_DETAIL SA INNER JOIN BOOK B ON B.BOOK_ID = SA.BOOK_ID INNER JOIN STOCK S ON S.BOOK_ID = SA.BOOK_ID  WHERE SA.SALE_ID = '" +saleID+"'";
            DsForReport dsVoucher = new DsForReport();
            dsVoucher.VOUCHER.Rows.Add(saleID, CommonConstant.CREATED_BY);
            SqlCommand VoucherCmd = new SqlCommand(strVoucher, consql);
            VoucherCmd.CommandType = CommandType.Text;
            SqlDataAdapter DaVoucher = new SqlDataAdapter(VoucherCmd);
            DaVoucher.Fill(dsVoucher, "VOUCHERDT");
            
            ReportDocument VoucherDocument = new ReportDocument();
            VoucherDocument.Load(CommonConstant.REPORT + "Voucher.rpt");
            VoucherDocument.SetDataSource(dsVoucher);
            VouchercrystalReportViewer.ReportSource = VoucherDocument;
            VouchercrystalReportViewer.Refresh();
            sale.Close();
        }
    }
}
