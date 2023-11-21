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
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txt_id.Enabled = false;
        }
        void Clear()
        {
            txt_payment.Text = "";
            txt_search.Text = "";
            date_date.Value = DateTime.Now;

            txt_payment.Enabled = true;
            date_date.Enabled = true;
            btn_payment.Enabled = true;
            btn_delete.Enabled = false;
        }
        private void payment_Load(object sender, EventArgs e)
        {
            string idInvoice = txt_id.Text;
            dgv_BillPayments.DataSource = InputInvoicesDAO.Instance.getlistBillPayments(idInvoice);
            dgv_BillPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_BillPayments.ReadOnly = true;
            dgv_BillPayments.Columns["idInputInvoice"].HeaderText = "Hóa đơn";
            dgv_BillPayments.Columns["datePayment"].HeaderText = "Ngày thanh toán";
            dgv_BillPayments.Columns["paidAmount"].HeaderText = "Thanh toán";

            dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicess();
            dgv_InputInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_InputInvoices.ReadOnly = true;
            dgv_InputInvoices.Columns["id"].HeaderText = "Mã hóa đơn";
            dgv_InputInvoices.Columns["dateInvoice"].HeaderText = "Ngày nhập";
            dgv_InputInvoices.Columns["idProvider"].HeaderText = "Nhà cung cấp";
            dgv_InputInvoices.Columns["pay"].HeaderText = "Thanh toán";
            dgv_InputInvoices.Columns["paidAmount"].HeaderText = "Còn Nợ";
            dgv_InputInvoices.Columns["orderStatus"].HeaderText = "Trạng thái hóa đơn";

            btn_delete.Enabled = false;
            btn_payment.Enabled = false;
        }

        private void dgv_InputInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txt_id.Text = dgv_InputInvoices.Rows[r].Cells["id"].Value.ToString();
                string idInvoice = txt_id.Text;
                dgv_BillPayments.DataSource = InputInvoicesDAO.Instance.getlistBillPayments(idInvoice);
                int row0 = InputInvoicesDAO.Instance.setStatusOrders0(idInvoice);
                int row2 = InputInvoicesDAO.Instance.setStatusOrders2(idInvoice);
                if (row0 > 0 || row2 > 0)
                {
                    dgv_BillPayments.Enabled = false;
                    btn_payment.Enabled = false;
                    btn_delete.Enabled = false;
                }
                else
                {
                    dgv_BillPayments.Enabled = true;
                    btn_payment.Enabled = true;
                    btn_delete.Enabled = false;
                }
            }
        }

        private void dgv_BillPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txt_id.Text = dgv_BillPayments.Rows[r].Cells["idInputInvoice"].Value.ToString();
                string datePayment = dgv_BillPayments.Rows[r].Cells["datePayment"].Value?.ToString();
                if (!string.IsNullOrEmpty(datePayment))
                {
                    if (DateTime.TryParse(datePayment, out DateTime date))
                    {
                        date_date.Value = date;
                    }
                    else
                    {
                        MessageBox.Show("Ngày sinh không hợp lệ.");
                    }
                }
                txt_payment.Text = dgv_BillPayments.Rows[r].Cells["paidAmount"].Value.ToString();
                date_date.Enabled = false;
                txt_payment.Enabled = false;
                btn_payment.Enabled = false;
                btn_delete.Enabled = true;
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string id = txt_search.Text.Trim();
            dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.Search_InputInvoices(id);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string idInvoice = txt_id.Text;
            DateTime datePayment = date_date.Value;
            DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (InputInvoicesDAO.Instance.DeleteBillPayments(idInvoice, datePayment))
                {
                    MessageBox.Show("Xóa thành công");
                    dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicess();
                    dgv_BillPayments.DataSource = InputInvoicesDAO.Instance.getlistBillPayments(txt_id.Text);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        }

        private void btn_payment_Click(object sender, EventArgs e)
        {
            string idInvoice = txt_id.Text;
            DateTime datePayment = date_date.Value;
            int rowCount = InputInvoicesDAO.Instance.SetInsertBillPayments(txt_id.Text, date_date.Value);
            if (rowCount > 0)
            {
                MessageBox.Show("Bị trùng dữ liệu, vui lòng chọn lại ngày", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (string.IsNullOrEmpty(idInvoice) || !float.TryParse(txt_payment.Text, out float paymentStatus))
                {
                    MessageBox.Show("Vui lòng nhập đúng và đây đủ thông tin!");
                }
                else
                {
                    float paidAmount = InputInvoicesDAO.Instance.GetPaidAmount(idInvoice);
                    if (paymentStatus > paidAmount)
                    {
                        MessageBox.Show("Bạn đang thanh toán số tiền nhiều hơn số tiền còn nợ Nhà cung cấp!");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Bạn có muốn thanh toán không?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            if (InputInvoicesDAO.Instance.InsertBillPayments(idInvoice, datePayment, paymentStatus))
                            {
                                MessageBox.Show("Thanh toán thành công");
                                txt_payment.Text = "";
                                date_date.Value = DateTime.Now;
                                dgv_BillPayments.DataSource = InputInvoicesDAO.Instance.getlistBillPayments(txt_id.Text);
                                if (InputInvoicesDAO.Instance.UpdateStatusOrders(idInvoice))
                                {
                                    dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicess();
                                }
                                else
                                {
                                    dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicess();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Thanh toán thất bại");
                            }
                        }
                    }

                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
            txt_id.Text = "";
            dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicess();
            dgv_BillPayments.DataSource = InputInvoicesDAO.Instance.getlistBillPayments(txt_id.Text);
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
                    case 1:
                        return "Đã xuất đơn";
                    default:
                        return "Không xác định";
                }
            }
        }
}
