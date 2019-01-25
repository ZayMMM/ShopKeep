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

namespace ShopKeep_POS
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }
       



        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem lvstock = new ListViewItem(txt1.Text);
            lvstock.SubItems.Add(txt2.Text);
            lvstock.SubItems.Add(txt3.Text);
            lvstock.SubItems.Add(txt4.Text);
            lstStock.Items.Add(lvstock);
        }
    }
}
