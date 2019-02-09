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
    public partial class SubMaster : Form
    {
        public SubMaster()
        {
            InitializeComponent();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
        }

        private void publisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Publisher publisher = new Publisher();
            publisher.Show();
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Show();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Show();
        }

        private void discountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Discount discount = new Discount();
            discount.Show();
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurOrderList purcharseorderlist = new PurOrderList();
            purcharseorderlist.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockList stocklist = new StockList();
            stocklist.Show();
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            sale.Show();
        }

        private void damageLossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DamageLoss damageloss = new DamageLoss();
            damageloss.Show();
        }

        private void Master_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void bestSellerChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChartReport chart = new ChartReport();
            chart.Show();
        }

        private void staffReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffReportForm staffReport = new StaffReportForm();
            staffReport.Show();
        }

        private void publisherReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublisherReportForm pubReport = new PublisherReportForm();
            pubReport.Show();
        }

        private void authorReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorReportForm autReport = new AuthorReportForm();
            autReport.Show();
        }

        private void categoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryReportForm catReport = new CategoryReportForm();
            catReport.Show();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockReportForm stockReport = new StockReportForm();
            stockReport.Show();
        }

        private void bookReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralBookReport bookReport = new GeneralBookReport();
            bookReport.Show();
        }
   

    }
}
