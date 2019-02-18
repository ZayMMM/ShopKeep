using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopKeep_POS
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        public String count, startDate, endDate;
        public void fillChart()
        {

            SqlConnection con = new SqlConnection(CommonConstant.DATA_SOURCE);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT TOP 9 B.BK_TITLE,SUM(SD.SALE_QTY) AS QUANTITY FROM SALE_DETAIL SD INNER JOIN BOOK B ON B.BOOK_ID = SD.BOOK_ID WHERE SD.CREATED_DATE BETWEEN '"+startDate+"' AND '"+endDate+"' GROUP BY B.BK_TITLE ORDER BY QUANTITY DESC", con);
            adapt.Fill(ds);
            chart1.DataSource = ds;
            //set the member of the chart data source used to data bind to the X-values of the series  
            chart1.Series["Book"].XValueMember = "BK_TITLE";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chart1.Series["Book"].YValueMembers = "QUANTITY";
            chart1.Titles.Add("Best Salar Chart");
            con.Close();
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            fillChart();
        }

    }
}
