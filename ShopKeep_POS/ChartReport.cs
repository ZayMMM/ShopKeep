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
    public partial class ChartReport : Form
    {
        public ChartReport()
        {
            InitializeComponent();
        }

        private void txtPrint_Click(object sender, EventArgs e)
        {
            String startDate, endDate;
            startDate = dtpStartDate.Text.Trim();

            endDate = dtpEndDate.Text.Trim();
             Chart chart = new Chart();
             chart.startDate = startDate;
             chart.endDate = endDate;
             String date = startDate;
             chart.Show();
        }

        public String formatDate()
        {

            return null;
        }

    }
}
