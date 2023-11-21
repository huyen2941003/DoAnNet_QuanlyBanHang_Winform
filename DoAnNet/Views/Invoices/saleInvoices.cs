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
    public partial class saleInvoices : UserControl
    {
        public saleInvoices()
        {
            InitializeComponent(); timer1.Start();
            LoadCmbProduct();
            txt_idSalesOrders.Enabled = false;
        }
        void LoadCmbProduct()
        {
            List<DTO.Product> product = ProductDAO.Instance.getlistProduct();
            cmb_product.DataSource = product;
            cmb_product.DisplayMember = "nameProduct";
        }
        void Clear()
        {
            cmb_product.SelectedIndex = 0;
            number_amount.Value = 0;
            txt_search.Text = "";
        }

        private void saleInvoices_Load(object sender, EventArgs e)
        {
            string idInvoice = txt_idSalesOrders.Text;
            dgv_SalesOrderDetails.DataSource = SalesOrdersDAO.Instance.getlistSalesOrderDetails(idInvoice);
            dgv_SalesOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_SalesOrderDetails.ReadOnly = true;
            dgv_SalesOrderDetails.Columns["idInvoice"].HeaderText = "Hóa đơn";
            dgv_SalesOrderDetails.Columns["idProduct"].HeaderText = "Sản Phẩm";
            dgv_SalesOrderDetails.Columns["aMount"].HeaderText = "Số lượng";
            dgv_SalesOrderDetails.Columns["sellingPrice"].HeaderText = "Giá bán";
            dgv_SalesOrderDetails.Columns["pay"].HeaderText = "Thanh toán";
            DataGridViewLinkColumn deleteLinkColumn = new DataGridViewLinkColumn();
            deleteLinkColumn.Name = "Xóa";
            deleteLinkColumn.HeaderText = "Delete";
            deleteLinkColumn.Text = "delete";
            deleteLinkColumn.UseColumnTextForLinkValue = true;
            dgv_SalesOrderDetails.Columns.Add(deleteLinkColumn);

            dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.getlistSalesOrders();
            dgv_SalesOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_SalesOrders.ReadOnly = true;
            dgv_SalesOrders.Columns["id"].HeaderText = "Mã hóa đơn";
            dgv_SalesOrders.Columns["dateInvoice"].HeaderText = "Ngày bán";
            dgv_SalesOrders.Columns["pay"].HeaderText = "Thanh toán";
            dgv_SalesOrders.Columns["orderStatus"].HeaderText = "Trạng thái hóa đơn";
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            DateTime dateInvoice = date_dateInvoice.Value;
            DialogResult result = MessageBox.Show("Bạn có muốn thêm hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (SalesOrdersDAO.Instance.InsertSalesOrders(dateInvoice))
                {
                    MessageBox.Show("Đã thêm hóa đơn thành công");
                    dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.getlistSalesOrders();
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string idInvoice = txt_idSalesOrders.Text;
            if (string.IsNullOrEmpty(idInvoice))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
            }
            else
            {
                int rowCount = SalesOrdersDAO.Instance.setDeleteSalesOrders(idInvoice);
                if (rowCount > 0)
                {
                    MessageBox.Show("Bạn không được xóa hóa đơn này");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa hóa đơn " + idInvoice + " không?", "Thông báo",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (SalesOrdersDAO.Instance.DeleteSalesOrders(idInvoice))
                        {
                            MessageBox.Show("Xóa thành công");
                            txt_idSalesOrders.Text = "";
                            dgv_SalesOrderDetails.DataSource = SalesOrdersDAO.Instance.getlistSalesOrderDetails(txt_idSalesOrders.Text);
                            dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.getlistSalesOrders();
                        }
                    }
                }

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string idInvoice = txt_idSalesOrders.Text;
            string idProduct = ((DTO.Product)cmb_product.SelectedItem).NameProduct;
            int aMount = (int)number_amount.Value;
            if (string.IsNullOrEmpty(idInvoice) || aMount == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn và số lượng phải > 0");
            }
            else
            {
                int inventory = InventoryDAO.Instance.GetInventory(idProduct);
                if (aMount > inventory)
                {
                    MessageBox.Show("Chỉ còn " + inventory + " sản phẩm trong kho. Vui lòng chọn lại");
                }
                else
                {
                    if (SalesOrdersDAO.Instance.SetInsertSalesOrderDetails(idInvoice, idProduct).Count > 0)
                    {
                        MessageBox.Show("Bạn vừa thay đổi số lượng của sản phẩm " + idProduct + " trong hóa đơn", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (SalesOrdersDAO.Instance.UpdateSalesOrderDetails(idInvoice, idProduct, aMount))
                        {
                            MessageBox.Show("Thêm thành công");
                            dgv_SalesOrderDetails.DataSource = SalesOrdersDAO.Instance.getlistSalesOrderDetails(idInvoice);
                            dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.getlistSalesOrders();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                    }
                    else
                    {
                        if (SalesOrdersDAO.Instance.InsertSalesOrderDetails(idInvoice, idProduct, aMount))
                        {
                            MessageBox.Show("Thêm thành công");
                            dgv_SalesOrderDetails.DataSource = SalesOrdersDAO.Instance.getlistSalesOrderDetails(idInvoice);
                            dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.getlistSalesOrders();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                    }
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
            dgv_SalesOrderDetails.Enabled = true;
            btn_add.Enabled = true;
            btn_pay.Enabled = true;
            txt_idSalesOrders.Text = "";
            dgv_SalesOrderDetails.DataSource = SalesOrdersDAO.Instance.getlistSalesOrderDetails(txt_idSalesOrders.Text);
            dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.getlistSalesOrders();
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            string id = txt_idSalesOrders.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để thanh toán");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thanh toán hóa đơn " + id + " không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (SalesOrdersDAO.Instance.UpdateStatusOrders(id))
                    {
                        MessageBox.Show("Thanh toán thành công");
                        Clear();
                        txt_idSalesOrders.Text = "";
                        dgv_SalesOrderDetails.DataSource = SalesOrdersDAO.Instance.getlistSalesOrderDetails(txt_idSalesOrders.Text);
                        dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.getlistSalesOrders();
                    }
                    else
                    {
                        MessageBox.Show("Hóa đơn chưa có sản phẩm nào để thanh toán");
                    }
                }
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string id = txt_search.Text.Trim();
            dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.Search_SalesOrders(id);
        }

        private void dgv_SalesOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txt_idSalesOrders.Text = dgv_SalesOrders.Rows[r].Cells["id"].Value.ToString();
                string idInvoice = txt_idSalesOrders.Text;
                dgv_SalesOrderDetails.DataSource = SalesOrdersDAO.Instance.getlistSalesOrderDetails(idInvoice);
                int rowCount = SalesOrdersDAO.Instance.setStatusOrders(idInvoice);

                if (rowCount > 0)
                {
                    dgv_SalesOrderDetails.Enabled = false;
                    btn_add.Enabled = false;
                    btn_pay.Enabled = false;
                }
                else
                {
                    dgv_SalesOrderDetails.Enabled = true;
                    btn_add.Enabled = true;
                    btn_pay.Enabled = true;
                }
            }
        }

        private void dgv_SalesOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                string idInvoice = dgv_SalesOrderDetails.Rows[r].Cells["idInvoice"].Value.ToString();
                string idProduct = dgv_SalesOrderDetails.Rows[r].Cells["idProduct"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có muốn xóa sản phẩm này khỏi hóa đơn không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (SalesOrdersDAO.Instance.DeleteSalesOrderDetails(idInvoice, idProduct))
                    {
                        MessageBox.Show("Xóa thành công");
                        dgv_SalesOrderDetails.DataSource = SalesOrdersDAO.Instance.getlistSalesOrderDetails(txt_idSalesOrders.Text);
                        dgv_SalesOrders.DataSource = SalesOrdersDAO.Instance.getlistSalesOrders();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time.Text = DateTime.Now.ToLongTimeString() + "  -  " + DateTime.Now.ToLongDateString();
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
