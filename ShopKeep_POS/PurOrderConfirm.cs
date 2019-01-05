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
    public partial class PurOrderConfirm : Form
    {
        public PurOrderConfirm()
        {
            InitializeComponent();
        }

        private void DGVOrderview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PurOrderDT purordt = new PurOrderDT();
            purordt.Show();
        }
    }
}
