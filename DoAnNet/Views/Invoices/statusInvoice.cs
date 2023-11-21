using DoAnNet.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNet.Views.Invoices
{
    public partial class statusInvoice : UserControl
    {
        public statusInvoice()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void statusInvoice_Load(object sender, EventArgs e)
        {
            dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
            dgv_InputInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_InputInvoices.ReadOnly = true;
            dgv_InputInvoices.Columns["id"].HeaderText = "Mã hóa đơn";
            dgv_InputInvoices.Columns["dateInvoice"].HeaderText = "Ngày nhập";
            dgv_InputInvoices.Columns["idProvider"].HeaderText = "Nhà cung cấp";
            dgv_InputInvoices.Columns["pay"].HeaderText = "Nợ";
            dgv_InputInvoices.Columns["orderStatus"].HeaderText = "Trạng thái hóa đơn";

            dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.getlistSalesOrders();
            dgv_SalesOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_SalesOrders.ReadOnly = true;
            dgv_SalesOrders.Columns["id"].HeaderText = "Mã hóa đơn";
            dgv_SalesOrders.Columns["dateInvoice"].HeaderText = "Ngày bán";
            dgv_SalesOrders.Columns["pay"].HeaderText = "Thanh toán";
            dgv_SalesOrders.Columns["orderStatus"].HeaderText = "Trạng thái hóa đơn";
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cmb_status.SelectedItem == null || cmb_invoice.SelectedItem == null)
            {
                MessageBox.Show("Vuo lòng điền đủ thông tin");
            }
            else
            {
                string invoice = cmb_invoice.SelectedItem.ToString();
                string status = cmb_status.SelectedItem.ToString();
                if (invoice == "Hóa đơn bán")
                {
                    if (status == "Đã thanh toán hết")
                    {
                        dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.Search_Status0();
                    }
                    else if (status == "Chưa thanh toán hết")
                    {
                        dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.Search_Status1();
                    }
                }
                else if (invoice == "Hóa đơn nhập")
                {
                    if (status == "Đã thanh toán hết")
                    {
                        dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.Search_Debt00();
                    }
                    else if (status == "Chưa thanh toán hết")
                    {
                        dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.Search_Debt11();
                    }
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
            dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.getlistSalesOrders();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time.Text = DateTime.Now.ToLongTimeString() + "  -  " + DateTime.Now.ToLongDateString();
        }

        private void dgv_InputInvoices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgv_InputInvoices.Columns["orderStatus"].Index && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int orderStatus))
                {
                    string statusText = GetOrderStatusText(orderStatus);
                    e.Value = statusText;
                    e.FormattingApplied = true;
                }
            }
        }
        private string GetOrderStatusText(int orderStatus)
        {
            switch (orderStatus)
            {
                case 0:
                    return "Đã thanh toán";
                case 1:
                    return "Chưa thanh toán";
                default:
                    return "Không xác định";
            }
        }

        private void dgv_SalesOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgv_SalesOrders.Columns["orderStatus"].Index && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int orderStatusValue))
                {
                    string statusText = (orderStatusValue == 0) ? "Đã thanh toán" : "Chưa thanh toán";
                    e.Value = statusText;
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
