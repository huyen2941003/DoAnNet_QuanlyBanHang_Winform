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
    public partial class inputInvoices : UserControl
    {
        public inputInvoices()
        {
            InitializeComponent(); 
            timer1.Start();
            LoadCmbProvider();
            txt_idInputInvoices.Enabled = false;
        }
        void LoadCmbProvider()
        {
            List<DTO.Provider> provider = ProviderDAO.Instance.getlistProvider();
            cmb_provider.DataSource = provider;
            cmb_provider.DisplayMember = "nameProvider";
        }
        void Clear()
        {
            number_amount.Value = 0;
            cmb_product.Enabled = true;
            number_amount.Enabled = true;

            btn_add.Enabled = true;
            btn_out.Enabled = true;
            btn_pay.Enabled = true;
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            DateTime dateInvoice = date_dateInvoice.Value;
            string idProvider = ((DTO.Provider)cmb_provider.SelectedItem).NameProvider;
            DialogResult result = MessageBox.Show("Bạn có muốn thêm hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (InputInvoicesDAO.Instance.InsertInputInvoices(dateInvoice, idProvider))
                {
                    MessageBox.Show("Đã thêm hóa đơn thành công");
                    dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
                }
            }
        }

        private void inputInvoices_Load(object sender, EventArgs e)
        {
            string idInvoice = txt_idInputInvoices.Text;
            dgv_InputInvoicesDetails.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicesDetails(idInvoice);
            dgv_InputInvoicesDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_InputInvoicesDetails.ReadOnly = true;
            dgv_InputInvoicesDetails.Columns["idInvoice"].HeaderText = "Hóa đơn";
            dgv_InputInvoicesDetails.Columns["idProduct"].HeaderText = "Sản Phẩm";
            dgv_InputInvoicesDetails.Columns["costPrice"].HeaderText = "Giá nhập";
            dgv_InputInvoicesDetails.Columns["aMount"].HeaderText = "Số lượng";
            dgv_InputInvoicesDetails.Columns["pay"].HeaderText = "Thanh toán";

            dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
            dgv_InputInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_InputInvoices.ReadOnly = true;
            dgv_InputInvoices.Columns["id"].HeaderText = "Mã hóa đơn";
            dgv_InputInvoices.Columns["dateInvoice"].HeaderText = "Ngày nhập";
            dgv_InputInvoices.Columns["idProvider"].HeaderText = "Nhà cung cấp";
            dgv_InputInvoices.Columns["pay"].HeaderText = "Thanh toán";
            dgv_InputInvoices.Columns["paidAmount"].HeaderText = "Còn Nợ";
            dgv_InputInvoices.Columns["orderStatus"].HeaderText = "Trạng thái hóa đơn";
        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            string id = txt_idInputInvoices.Text;
            int row = InputInvoicesDAO.Instance.OutInputInvoices(id);
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
            }
            else
            {
                if (row == 0)
                {
                    MessageBox.Show("Bạn chưa nhập sản phẩm cho hóa đơn này");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xuất đơn " + id + " không?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (InputInvoicesDAO.Instance.UpdateStatusOrders2(id))
                        {
                            MessageBox.Show("Xuất đơn thành công");
                            txt_idInputInvoices.Text = "";
                            dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
                            dgv_InputInvoicesDetails.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicesDetails(txt_idInputInvoices.Text);
                        }
                    }
                }

            }
        }

        private void btn_deletedetail_Click(object sender, EventArgs e)
        {
            string idInvoice = txt_idInputInvoices.Text;
            string idProduct = ((DTO.Product)cmb_product.SelectedItem).NameProduct;
            DialogResult result = MessageBox.Show("Bạn có muốn xóa sản phẩm này khỏi hóa đơn không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (InputInvoicesDAO.Instance.DeleteInputInvoicesDetails(idInvoice, idProduct))
                {
                    MessageBox.Show("Xóa thành công");
                    Clear();
                    dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
                    dgv_InputInvoicesDetails.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicesDetails(idInvoice);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        } 
        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
            dgv_InputInvoicesDetails.Enabled = true;
            btn_add.Enabled = true;
            btn_pay.Enabled = true;
            btn_out.Enabled = true;
            txt_idInputInvoices.Text = "";
            dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
            dgv_InputInvoicesDetails.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicesDetails(txt_idInputInvoices.Text);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string idInvoice = txt_idInputInvoices.Text;
            string idProduct = ((DTO.Product)cmb_product.SelectedItem).NameProduct;
            float costPrice = float.Parse(txt_costPrice.Text);
            int aMount = (int)number_amount.Value;
            if (string.IsNullOrEmpty(idInvoice) || aMount == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn và số lượng phải > 0");
            }
            else
            {
                if (costPrice == InputInvoicesDAO.Instance.getcostPrice(idProduct))
                {
                    if (InputInvoicesDAO.Instance.SetInsertInputInvoicesDetails(idInvoice, idProduct).Count > 0)
                    {
                        MessageBox.Show("Bạn vừa thay đổi số lượng của sản phẩm " + idProduct + " trong hóa đơn", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (InputInvoicesDAO.Instance.UpdateAmount(idInvoice, idProduct, aMount))
                        {
                            Clear();
                            MessageBox.Show("Thêm thành công");
                            dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
                            dgv_InputInvoicesDetails.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicesDetails(idInvoice);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                    }
                    else
                    {
                        if (InputInvoicesDAO.Instance.InsertInputInvoicesDetails(idInvoice, idProduct, aMount))
                        {
                            MessageBox.Show("Thêm thành công");
                            dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
                            dgv_InputInvoicesDetails.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicesDetails(idInvoice);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn sửa giá nhập không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (InputInvoicesDAO.Instance.SetInsertInputInvoicesDetails(idInvoice, idProduct).Count > 0)
                        {
                            MessageBox.Show("Bạn vừa thay đổi số lượng của sản phẩm " + idProduct + " trong hóa đơn", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (InputInvoicesDAO.Instance.UpdateAmount(idInvoice, idProduct, aMount))
                            {
                                Clear();
                                MessageBox.Show("Thêm thành công");
                                dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
                                dgv_InputInvoicesDetails.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicesDetails(idInvoice);
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại");
                            }
                        }
                        else
                        {
                            if (InputInvoicesDAO.Instance.UpdatecostPrice(idProduct, costPrice, aMount))
                            {
                                if (InputInvoicesDAO.Instance.InsertInputInvoicesDetails(idInvoice, idProduct, aMount))
                                {
                                    MessageBox.Show("Thêm thành công");
                                    dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
                                    dgv_InputInvoicesDetails.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicesDetails(idInvoice);
                                }
                                else
                                {
                                    MessageBox.Show("Thêm thất bại");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại");
                            }
                        }
                    }
                }
            }
            
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            Views.Invoices.payment frm = new Views.Invoices.payment();
            frm.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string idInvoice = txt_idInputInvoices.Text;
            if (string.IsNullOrEmpty(idInvoice))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
            }
            else
            {
                if (InputInvoicesDAO.Instance.setDeleteInputInvoices1(idInvoice) > 0 || InputInvoicesDAO.Instance.setDeleteInputInvoices2(idInvoice) > 0)
                {
                    MessageBox.Show("Bạn không được xóa hóa đơn này");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa hóa đơn " + idInvoice + " không?", "Thông báo",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (InputInvoicesDAO.Instance.DeleteInputInvoices(idInvoice))
                        {
                            MessageBox.Show("Xóa thành công");
                            txt_idInputInvoices.Text = "";
                            dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
                            dgv_InputInvoicesDetails.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicesDetails(txt_idInputInvoices.Text);
                        }
                    }
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time.Text = DateTime.Now.ToLongTimeString() + "  -  " + DateTime.Now.ToLongDateString();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string id = txt_search.Text.Trim();
            Clear();
            dgv_InputInvoices.DataSource = InputInvoicesDAO.Instance.Search_InputInvoices(id);
        }

        private void dgv_InputInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            int r = e.RowIndex;
            if (r >= 0)
            {
                txt_idInputInvoices.Text = dgv_InputInvoices.Rows[r].Cells["id"].Value.ToString();
                string idInvoice = txt_idInputInvoices.Text;
                int row1 = InputInvoicesDAO.Instance.setStatusOrders1(idInvoice);
                if (row1 > 0)
                {
                    dgv_InputInvoicesDetails.Enabled = false;
                    btn_add.Enabled = false;
                    btn_out.Enabled = false;
                }
                else
                {
                    int row0 = InputInvoicesDAO.Instance.setStatusOrders0(idInvoice);
                    if (row0 > 0)
                    {
                        dgv_InputInvoicesDetails.Enabled = false;
                        btn_add.Enabled = false;
                        btn_out.Enabled = false;
                    }
                    else
                    {
                        dgv_InputInvoicesDetails.Enabled = true;
                        btn_add.Enabled = true;
                        btn_out.Enabled = true;
                    }
                }
                dgv_InputInvoicesDetails.DataSource = InputInvoicesDAO.Instance.getlistInputInvoicesDetails(idInvoice);

                List<DTO.Product> product = ProductDAO.Instance.getlistProduct_provider(dgv_InputInvoices.Rows[r].Cells["idProvider"].Value.ToString());
                cmb_product.DataSource = product;
                cmb_product.DisplayMember = "nameProduct";
            }
        }

        private void dgv_InputInvoicesDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txt_idInputInvoices.Text = dgv_InputInvoicesDetails.Rows[r].Cells["idInvoice"].Value.ToString();
                cmb_product.SelectedIndex = cmb_product.FindString(dgv_InputInvoicesDetails.Rows[r].Cells["idProduct"].Value.ToString());
                txt_costPrice.Text = dgv_InputInvoicesDetails.Rows[r].Cells["costPrice"].Value.ToString();
                string amount = dgv_InputInvoicesDetails.Rows[r].Cells["aMount"].Value.ToString();
                if (int.TryParse(amount, out int aMount))
                {
                    number_amount.Value = aMount;
                }
                else
                {
                    MessageBox.Show("Giá trị không hợp lệ!");
                }
            }
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
                    return "Đã xuất đơn";
                case 2:
                    return "Chưa xuất đơn";
                default:
                    return "Không xác định";
            }
        }

        private void cmb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = cmb_product.Text;
            float sellingPrice = SalesOrdersDAO.Instance.getcostPrice(selectedProduct);
            if(!string.IsNullOrEmpty(selectedProduct))
            {
                txt_costPrice.Text = Convert.ToString(sellingPrice);
            }
            else
            {
                txt_costPrice.Text = "";
            }
        }
    }
}
