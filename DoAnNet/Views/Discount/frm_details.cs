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

namespace DoAnNet.Views.Discount
{
    public partial class frm_details : Form
    {
        public frm_details()
        {
            InitializeComponent();
            txt_idproduct.Enabled = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            loadCmbDiscount();
        }
        void loadCmbDiscount()
        {
            List<DTO.Discount> discount = DiscountDAO.Instance.getlistDiscount();
            cmb_discount.DataSource = discount;
            cmb_discount.DisplayMember = "nameDiscount";
        }
        private void frm_details_Load(object sender, EventArgs e)
        {
            dgv_product.DataSource = ProductDAO.Instance.getlistProduct();
            dgv_product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_product.ReadOnly = true;
            dgv_product.Columns["id"].HeaderText = "Mã sản phẩm";
            dgv_product.Columns["nameProduct"].HeaderText = "Tên sản phẩm";
            dgv_product.Columns["idDistribute"].HeaderText = "Loại";
            dgv_product.Columns["idProvider"].HeaderText = "Nhà cung cấp";
            dgv_product.Columns["costPrice"].HeaderText = "Giá nhập";
            dgv_product.Columns["rate"].HeaderText = "Tỷ lệ chênh";
            dgv_product.Columns["SellingPrice"].HeaderText = "Giá bán";

            string id = txt_idproduct.Text;
            dgv_details.DataSource = DiscountDAO.Instance.getlistDiscountDetials(id);
            dgv_details.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_details.ReadOnly = true;
            dgv_details.Columns["idProduct"].HeaderText = "Tên sản phẩm";
            dgv_details.Columns["idDiscount"].HeaderText = "Tên chương trình";

            btn_insert.Enabled = false;
        }

        private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if(r>=0)
            {
                txt_idproduct.Text = dgv_product.Rows[r].Cells["id"].Value.ToString();
                string id = txt_idproduct.Text;
                dgv_details.DataSource = DiscountDAO.Instance.getlistDiscountDetials(id);
                btn_insert.Enabled = true;
            }    
        }
        bool DeleteDiscount(string idProduct, string idDiscount)
        {
            return DiscountDAO.Instance.DeleteDiscount(idProduct, idDiscount);
        }
        private void dgv_details_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                string idProduct = dgv_details.Rows[r].Cells["idProduct"].Value.ToString();
                string idDiscount = dgv_details.Rows[r].Cells["idDiscount"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (DeleteDiscount(idProduct, idDiscount))
                    {
                        MessageBox.Show("Xóa thành công!");
                        dgv_details.DataSource = DiscountDAO.Instance.getlistDiscountDetials(txt_idproduct.Text);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại, vui lòng kiểm tra lại dữ liệu!");
                    }
                }
            }
        }

        bool InsertDiscountDetials(string idProduct, string idDiscount)
        {
            return DiscountDAO.Instance.InsertDiscountDetials(idProduct, idDiscount);
        }
        private void btn_insert_Click(object sender, EventArgs e)
        {
            string idproduct = txt_idproduct.Text;
            string idDiscount = ((DTO.Discount)cmb_discount.SelectedItem).NameDiscount;
            if(DiscountDAO.Instance.setInsertDetails(idproduct, idDiscount).Count > 0)
            {
                MessageBox.Show("Sản phẩm " + idproduct + " đã được áp mã giảm giá " + idDiscount);
            }
            else
            {
                if (InsertDiscountDetials(idproduct, idDiscount))
                {
                    MessageBox.Show("Thêm thành công!");
                    dgv_details.DataSource = DiscountDAO.Instance.getlistDiscountDetials(idproduct);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }
    }
}
