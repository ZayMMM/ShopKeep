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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ShopKeep_POS
{
    public partial class GeneralBookReport : Form
    {
        public GeneralBookReport()
        {
            InitializeComponent();
        }

        String constr;
        SqlConnection consql;

        public void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        void FillView(String choice)
        {
            connection();
            SqlDataAdapter daView = new SqlDataAdapter(choice, consql);
            DataSet dsView = new DataSet();
            DataTable dtView;
            daView.Fill(dsView,"View");
            dtView = dsView.Tables["View"];
            cbView.DataSource = dtView;
            cbView.DisplayMember = dtView.Columns[1].ToString();
            cbView.ValueMember = dtView.Columns[0].ToString();
        }



        private void checkView_CheckedChanged(object sender, EventArgs e)
        {
            cbView.Enabled = checkView.Checked;
        }

        private void cbViewBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbViewBy.Text)
            {
                case "Publisher" :
                        FillView("SELECT PUB_ID,PUB_NAME FROM PUBLISHER");
                        break;
                case "Category"  :
                        FillView("SELECT CAT_ID,CAT_NAME FROM CATEGORY");
                        break;
                case "Author"    :
                        FillView("SELECT AUT_ID,AUT_NAME FROM AUTHOR");
                        break;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

            String query = "SELECT B.ISBN,B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,B.BK_PURCHASE_PRICE,S.SELL_PRICE FROM BOOK B INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID= B.CAT_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN STOCK S ON S.BOOK_ID = B.BOOK_ID";
            String file = "BookReport.rpt";

            if(checkView.Checked)
            {
                switch (cbViewBy.Text)
                {
                    case "Publisher":
                        query = "SELECT B.ISBN,B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,B.BK_PURCHASE_PRICE,S.SELL_PRICE FROM BOOK B INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID= B.CAT_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN STOCK S ON S.BOOK_ID = B.BOOK_ID WHERE P.PUB_NAME = N'" + cbView.Text+ "'";
                        break;
                    case "Category":
                        query = "SELECT B.ISBN,B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,B.BK_PURCHASE_PRICE,S.SELL_PRICE FROM BOOK B INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID= B.CAT_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN STOCK S ON S.BOOK_ID = B.BOOK_ID WHERE C.CAT_NAME = N'" + cbView.Text + "'";
                        break;
                    case "Author":
                        query = "SELECT B.ISBN,B.BK_TITLE,P.PUB_NAME,A.AUT_NAME,C.CAT_NAME,B.BK_PURCHASE_PRICE,S.SELL_PRICE FROM BOOK B INNER JOIN PUBLISHER P ON B.PUB_ID = P.PUB_ID INNER JOIN CATEGORY C ON C.CAT_ID= B.CAT_ID INNER JOIN AUTHOR A ON A.AUT_ID = B.AUT_ID INNER JOIN STOCK S ON S.BOOK_ID = B.BOOK_ID WHERE A.AUT_NAME = N'" + cbView.Text+ "'";;
                        break;
                }
            }


            switch (cbViewBy.Text)
            {
                case "Publisher":
                    file = "PublisherOnly.rpt";
                    break;
                case "Category":
                    file = "CategoryOnly.rpt";
                    break;
                case "Author":
                    file = "AuthorOnly.rpt";
                    break;
            }


            BookReportForm bkreport = new BookReportForm(query, file);
            bkreport.Show();
        }

        
    }
}
