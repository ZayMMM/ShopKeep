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
    public partial class Master : Form
    {
        public Master()
        {
            InitializeComponent();
        }

        private void publisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Publisher pub = new Publisher();
            pub.Show();
        }

        private void authorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Author aut = new Author();
            aut.Show();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Show();
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Member mem = new Member();
            mem.Show();
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase_Order puror = new Purchase_Order();
            puror.Show();
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurOrderConfirm purorcon = new PurOrderConfirm();
            purorcon.Show();
        }

        private void customerOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            sale.Show();
        }

        private void damageLossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cus_Order cusor = new Cus_Order();
            cusor.Show();
        }

        private void customerOrderConfirmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DamageLoss dmglos = new DamageLoss();
            dmglos.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockEntry stety = new StockEntry();
            stety.Show();

        }

      

      

        

    }
}
