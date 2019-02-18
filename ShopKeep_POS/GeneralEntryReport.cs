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
    public partial class GeneralEntryReport : Form
    {
        public GeneralEntryReport()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = checkBox1.Checked;
            dtpStartDate.Enabled = checkBox1.Checked;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                switch (cbView.Text)
                {
                    case "Publisher":
                        PublisherReportForm pubrp = new PublisherReportForm("SELECT P.PUB_NAME,P.PUB_PHONE,P.PUB_EMAIL,A.ADDRESS,A.CITY,A.STATE FROM PUBLISHER P INNER JOIN ADDRESS A ON A.ADD_ID = P.ADD_ID WHERE P.CREATED_DATE BETWEEN '" + dtpStartDate.Text.Trim() + "' AND '" + dtpEndDate.Text.Trim() + "'");
                        pubrp.Show();
                        break;
                    case "Author" :
                        AuthorReportForm autrp = new AuthorReportForm("SELECT AUT_NAME,AUT_SUB_NAME,GENDER FROM AUTHOR WHERE CREATED_DATE BETWEEN '" + dtpStartDate.Text + "' AND '" + dtpEndDate.Text + "'");
                        autrp.Show();
                        break;
                    case "Category" :
                        CategoryReportForm catrp = new CategoryReportForm("SELECT CAT_NAME FROM CATEGORY WHERE CREATED_DATE BETWEEN '"+dtpStartDate.Text+"' AND '"+dtpEndDate.Text+"'");
                        catrp.Show();
                        break;
                }
            }
            else
            {
                switch (cbView.Text)
                {
                    case "Publisher":
                        PublisherReportForm pubrp = new PublisherReportForm();
                        pubrp.Show();
                        break;
                    case "Author":
                        AuthorReportForm autrp = new AuthorReportForm();
                        autrp.Show();
                        break;
                    case "Category":
                        CategoryReportForm catrp = new CategoryReportForm();
                        catrp.Show();
                        break;
                }
            }
            
            
        }
    }
}
