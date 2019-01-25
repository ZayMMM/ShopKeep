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
    public partial class AvalibleStock : Form
    {
        StockList stockList;
        String constr;
        SqlConnection consql;
        DataTable dtPurOrder;
        public String orderid, pubid;
        

        public AvalibleStock(StockList stockList)
        {
            InitializeComponent();
            this.stockList = stockList;
        }

        void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        void FillData()
        {
            String query = "SELECT PO.ORDER_ID,PO.PUB_ID,P.PUB_NAME FROM PURCHASE_ORDER PO INNER JOIN PUBLISHER P ON PO.PUB_ID = P.PUB_ID WHERE PO.ORDER_STATUS = 'Success'";

            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            DataSet Dset = new DataSet();
            adapter.Fill(Dset, "PurOrder");
            dtPurOrder = Dset.Tables["PurOrder"];
            AvaliableDTGridView.DataSource = dtPurOrder;

            AvaliableDTGridView.Columns[0].HeaderText = "OrderID";
            AvaliableDTGridView.Columns[1].HeaderText = "Pubid";
            AvaliableDTGridView.Columns[2].HeaderText = "Publisher";

            AvaliableDTGridView.Columns[1].Visible = false;

            AvaliableDTGridView.Columns[0].Width = 100;
            AvaliableDTGridView.Columns[2].Width = 100;

        }

        private void AvalibleStock_Load(object sender, EventArgs e)
        {
            connection();
            FillData();
        }

        private void AvaliableDTGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = AvaliableDTGridView.CurrentRow.Index;
            dr = dtPurOrder.Rows[i];
            orderid = dr[0].ToString();
            pubid = dr[1].ToString();
        }

        String changeid(String BKid)
        {
            int stockid = int.Parse(BKid.Substring(1, BKid.Length - 1));
            return "S"+stockid.ToString("0000000") ;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String strPurOrder,strStock;
            connection();
            strPurOrder = "UPDATE PURCHASE_ORDER SET ORDER_STATUS='Done' WHERE ORDER_ID ='" + orderid + "'";
            SqlCommand mycmd = new SqlCommand(strPurOrder, consql);
            mycmd.ExecuteNonQuery();
            String bookid, ISBN, Title, Qty,stockid; 
            strStock = "SELECT OD.BOOK_ID,B.ISBN,B.BK_TITLE,OD.QUANTITY FROM ORDER_DETAIL OD INNER JOIN BOOK B ON OD.BOOK_ID =B.BOOK_ID WHERE ORDER_ID = '"+orderid+"'";
            SqlDataAdapter daStock = new SqlDataAdapter();
            DataSet dsStock = new DataSet();
            daStock.Fill(dsStock, "Stock");
            DataTable dtStock = dsStock.Tables["Stock"];
            for (int i = 0; i < dtStock.Rows.Count; i++)
            {
                for (int j = 0; j < dtStock.Columns.Count; j++)
                {
                    switch (j)
                    {
                        case 0:
                            bookid = dtStock.Rows[i].ItemArray[j].ToString();
                            stockid = changeid(bookid);
                            break;
                        case 1:
                            ISBN = dtStock.Rows[i].ItemArray[j].ToString();
                            break;
                        case 2:
                            Title = dtStock.Rows[i].ItemArray[j].ToString();
                            break;
                        case 3:
                            Qty = dtStock.Rows[i].ItemArray[j].ToString();
                            break;
                    }
                    
                }
            }

                stockList.connection();
            stockList.FillData();
            this.FillData();
            MessageBox.Show("Done");
        }

        




    }
}
