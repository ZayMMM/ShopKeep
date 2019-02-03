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
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }

        public void fillChart()
        {
            chart1.Series["Book"].Points.AddXY("LifeisTooShort","10000");
            chart1.Series["Book"].Points.AddXY("EssentialWords", "8000");
            chart1.Series["Book"].Points.AddXY("Oxfordlearner", "7000");
            chart1.Series["Book"].Points.AddXY("LoveIsNotLife", "65000");

            chart1.Titles.Add("Best Seller Report");


        }

        private void Chart_Load(object sender, EventArgs e)
        {
            fillChart();
        }
    }
}
