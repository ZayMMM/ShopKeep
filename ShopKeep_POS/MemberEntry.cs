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
    public partial class MemberEntry : Form
    {
        Member mem;
        public MemberEntry(Member mem)
        {
            InitializeComponent();
            this.mem = mem;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
