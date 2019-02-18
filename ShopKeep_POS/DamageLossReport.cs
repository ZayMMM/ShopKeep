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
    public partial class DamageLossReport : Form
    {
        public DamageLossReport()
        {
            InitializeComponent();
        }

        private void txtPrint_Click(object sender, EventArgs e)
        {
            String startDate, endDate,query;
            startDate = dtpStartDate.Text.Trim();
            endDate = dtpEndDate.Text.Trim();
            query = "SELECT B.BK_TITLE,D.DEMAGE_QTY,D.REASON,D.CREATED_BY FROM DAMAGE D INNER JOIN STOCK S ON S.STOCK_ID = D.STOCK_ID INNER JOIN BOOK B ON B.BOOK_ID = S.BOOK_ID WHERE D.DEMAGE_CREATED_DATE BETWEEN '"+startDate+"' AND '"+endDate+"'";
            
            DamageLossReportForm dmglosrpt = new DamageLossReportForm();
            dmglosrpt.query = query;
            dmglosrpt.file = "dmgLosReport.rpt";
            dmglosrpt.Show();
        }
    }
}
