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
    public partial class BookEntry : Form
    {
        Book book;
        public BookEntry(Book book)
        {

            InitializeComponent();
            this.book = book;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
