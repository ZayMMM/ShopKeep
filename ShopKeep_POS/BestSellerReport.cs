using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopKeep_POS
{
    public partial class BestSellerReport : Form
    {
        public BestSellerReport()
        {
            InitializeComponent();
        }

        private void cbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbView.Text.Equals("Best Seller List"))
            {
                txtNo.Enabled = true;
            }
            else
            {
                txtNo.Enabled = false;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            switch (cbView.Text)
            {
                case "Best Seller Chart":
                    Chart chart = new Chart();
                    chart.startDate = dtpStartDate.Text.Trim();
                    chart.endDate = dtpEndDate.Text.Trim();
                    chart.Show();
                    break;
                case "Best Seller List":
                    String query = "SELECT TOP " + txtNo.Text + " B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME,SUM(SD.SALE_QTY) AS QUANTITY FROM SALE_DETAIL SD INNER JOIN BOOK B ON B.BOOK_ID = SD.BOOK_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN CATEGORY C ON C.CAT_ID = B.CAT_ID INNER JOIN PUBLISHER P ON P.PUB_ID = B.PUB_ID WHERE SD.CREATED_DATE BETWEEN '" + dtpStartDate.Text.Trim() + "' AND '" + dtpEndDate.Text.Trim() + "' GROUP BY B.BK_TITLE,A.AUT_NAME,C.CAT_NAME,P.PUB_NAME ORDER BY QUANTITY DESC";
                    BestSellerReportForm best = new BestSellerReportForm(query);
                    best.Show();
                    break;
            }
        }
    }
}
