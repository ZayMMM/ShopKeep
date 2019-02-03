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
    public partial class PurOrderList : Form
    {
        public PurOrderList()
        {
            InitializeComponent();
        }

        String constr;
        SqlConnection consql;
        DataTable dtPurOrder;
        String orderID;
        String status;


        public void connection()
        {
            constr = CommonConstant.DATA_SOURCE;
            consql = new SqlConnection(constr);
            consql.Open();
        }

        DataSet Dset;
        public void FillData()
        {
            String query = "SELECT ORDER_ID,P.PUB_ID,P.PUB_NAME,ORDER_STATUS,ORDER_DATE,DUE_DATE,PO.CREATED_BY,PO.CREATED_DATE,PO.LAST_UPDATED_DATE FROM PURCHASE_ORDER PO INNER JOIN PUBLISHER P ON PO.PUB_ID=P.PUB_ID";

            SqlDataAdapter adapter = new SqlDataAdapter(query, consql);
            Dset = new DataSet();
            adapter.Fill(Dset, "PurOrder");
            dtPurOrder = Dset.Tables["PurOrder"];
            orderviewDataGridView.DataSource = dtPurOrder;

            orderviewDataGridView.Columns[0].HeaderText = "ORDER_ID";
            orderviewDataGridView.Columns[1].HeaderText = "PUB_ID";
            orderviewDataGridView.Columns[2].HeaderText = "PUB_NAME";
            orderviewDataGridView.Columns[3].HeaderText = "ORDER_STATUS";
            orderviewDataGridView.Columns[4].HeaderText = "ORDER_DATE";
            orderviewDataGridView.Columns[5].HeaderText = "DUE_DATE";
            orderviewDataGridView.Columns[6].HeaderText = "CREATED_BY";

            orderviewDataGridView.Columns[7].HeaderText = "CREATED_DATE";
            orderviewDataGridView.Columns[8].HeaderText = "LAST_UPDATED_DATE";

            orderviewDataGridView.Columns[0].Width = 150;
            orderviewDataGridView.Columns[1].Width = 150;
            orderviewDataGridView.Columns[2].Width = 180;
            orderviewDataGridView.Columns[3].Width = 150;
            orderviewDataGridView.Columns[4].Width = 150;
            orderviewDataGridView.Columns[5].Width = 150;
            orderviewDataGridView.Columns[6].Width = 150;

            orderviewDataGridView.Columns[7].Visible = false;
            orderviewDataGridView.Columns[8].Visible = false;



            //orderviewDataGridView.Columns[0].Visible = false;
            orderviewDataGridView.Columns[1].Visible = false;
        }

        void orderGenerateId()
        {
            string OID = "select ORDER_ID from PURCHASE_ORDER ORDER BY ORDER_ID";
            string PName;
            int PID;
            String format = "000000";
            SqlDataAdapter ad = new SqlDataAdapter(OID, consql);
            DataSet ds = new DataSet();
            ad.Fill(ds, "PurchaseOrder");
            if (ds.Tables["PurchaseOrder"].Rows.Count > 0)
            {
                PName = ds.Tables["PurchaseOrder"].Rows[ds.Tables["PurchaseOrder"].Rows.Count - 1][0].ToString();
                PID = int.Parse(PName.Substring(2, (PName.Length - 2)));
                orderID = "PO" + ((PID + 1).ToString(format));
            }
            else
            {
                orderID = "PO000001";
            }
        }


        public void refreshform()
        {
            connection();
            FillData();
        }

        private void PurOrderList_Load(object sender, EventArgs e)
        {
            refreshform();
        }



        private void orderviewDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = orderviewDataGridView.CurrentRow.Index;
            dr = dtPurOrder.Rows[i];
            if (dr[3].ToString() == "Progress")
            {
                Purchase_Order purchaseorder = new Purchase_Order(this, CommonConstant.DB_UPDATE);

                purchaseorder.cbPublisher.Text = dr[2].ToString();
                String strODT = "SELECT OD.BOOK_ID,B.BK_TITLE,B.BK_PURCHASE_PRICE,OD.QUANTITY FROM ORDER_DETAIL OD INNER JOIN BOOK B ON OD.BOOK_ID =B.BOOK_ID WHERE ORDER_ID = '" + dr[0].ToString() + "'";
                connection();
                SqlDataAdapter ODTad = new SqlDataAdapter(strODT, consql);
                DataSet ODTds = new DataSet();
                ODTad.Fill(ODTds, "OrderDT");
                DataTable ODTtable;
                ODTtable = ODTds.Tables["OrderDT"];
                int totamt = 0;
                for (int j = 0; j < ODTtable.Rows.Count; j++)
                {
                    ListViewItem odtlistviewitem = new ListViewItem(ODTtable.Rows[j].ItemArray[0].ToString());
                    for (int k = 1; k < ODTtable.Columns.Count; k++)
                    {
                        odtlistviewitem.SubItems.Add(ODTtable.Rows[j].ItemArray[k].ToString());
                    }
                    int Amount = (int.Parse(ODTtable.Rows[j].ItemArray[2].ToString())) * (int.Parse(ODTtable.Rows[j].ItemArray[3].ToString()));
                    totamt += Amount;
                    odtlistviewitem.SubItems.Add(Amount.ToString());
                    purchaseorder.purorderList.Items.Add(odtlistviewitem);

                }
                purchaseorder.pubid = dr[1].ToString();
                purchaseorder.txtTotalAmount.Text = totamt.ToString();
                purchaseorder.bookname = ODTtable.Rows[0].ItemArray[1].ToString();
                purchaseorder.txtQty.Text = ODTtable.Rows[0].ItemArray[3].ToString();
                purchaseorder.txtOrderNo.Text = dr[0].ToString();
                purchaseorder.Show();
            }
            else
            {
                MessageBox.Show("This Order is not on Progress.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            orderGenerateId();
            Purchase_Order purchaseorder = new Purchase_Order(this, CommonConstant.DB_INSERT);
            purchaseorder.txtOrderNo.Text = orderID;
            purchaseorder.Show();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
            PurOrderconfirm purORcon = new PurOrderconfirm(this);
            switch (status)
            {
                case "Progress":
                    purORcon.rbProgress.Checked = true;
                    break;
                case "Success":
                    purORcon.rbSuccess.Checked = true;
                    break;
                case "Cancel":
                    purORcon.rbCancel.Checked = true;
                    break;
            }
            purORcon.orderID = this.orderID;
            purORcon.Show();
            
        }

        private void orderviewDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr;
            int i;
            i = orderviewDataGridView.CurrentRow.Index;
            dr = dtPurOrder.Rows[i];
            status = dr[3].ToString();
            orderID = dr[0].ToString();
            if(status != "Progress")
            {
                btnConfirm.Enabled = false;
            }
            else
            {
                btnConfirm.Enabled = true;
            }

        }

        private void txtSrearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = Dset.Tables["PurOrder"].DefaultView;
            dv.RowFilter = "PUB_NAME LIKE '%" + txtSearch.Text.Trim() + "%'";
        }
    }
}
