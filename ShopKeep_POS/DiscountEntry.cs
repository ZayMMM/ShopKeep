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
    public partial class DiscountEntry : Form
    {
        Discount discount;
        String Test;
        public DiscountEntry(Discount discount,String Test)
        {
            InitializeComponent();
            this.discount = discount;
            this.Test = Test;
        }

        
    }
}
