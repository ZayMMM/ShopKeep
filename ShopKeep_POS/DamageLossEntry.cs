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
    public partial class DamageLossEntry : Form
    {

        DamageLoss damageloss;
        String test;
        public DamageLossEntry(DamageLoss damageloss,String test)
        {
            InitializeComponent();
            this.damageloss = damageloss;
            this.test = test;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
