using DoAnNet.DAO;
using DoAnNet.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace DoAnNet.Views.Products
{
    public partial class product : UserControl
    {
        public product()
        {
            InitializeComponent();
            timer1.Start();
            loadCmbColor();
            loadCmbSize();
            loadCmbDistribute();
            loadCmbProvider();
            txt_idproduct.Enabled = false;
            txt_link.Enabled = false;
            txt_price.Enabled = false;
        }
        public void Clear()
        {
            txt_search.Text = "";
            cmb_search.SelectedIndex = 0;
            txt_idproduct.Text = "";
            txt_nameproduct.Text = "";
            cmb_color.SelectedIndex = 0;
            cmb_size.SelectedIndex = 0;
            cmb_distribute.SelectedIndex = 0;
            cmb_provider.SelectedIndex = 0;
            txt_cost.Text = "";
            txt_sale.Text = "";
            txt_price.Text = "";
            pic_product.Image = null;
            btn_deleteproduct.Enabled = false;
            btn_updateproduct.Enabled = false;
        }
        void loadCmbColor()
        {
            List<DTO.Color> color = CategoryDAO.Instance.getlistColor();
            cmb_color.DataSource = color;
            cmb_color.DisplayMember = "nameColor";

        }
        void loadCmbSize()
        {
            List<DTO.Size> size = CategoryDAO.Instance.getlistSize();
            cmb_size.DataSource = size;
            cmb_size.DisplayMember = "nameSize";
        }
        void loadCmbDistribute()
        {
            List<DTO.Distribute> distribute = CategoryDAO.Instance.getlistDistribute();
            cmb_distribute.DataSource = distribute;
            cmb_distribute.DisplayMember = "nameDistribute";
        }
        void loadCmbProvider()
        {
            List<DTO.Provider> provider = ProviderDAO.Instance.getlistProvider();
            cmb_provider.DataSource = provider;
            cmb_provider.DisplayMember = "nameProvider";
        }
        private void product_Load(object sender, EventArgs e)
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

            string idProduct = txt_idproduct.Text;
            dgv_details.DataSource = ProductDAO.Instance.getlistProductDetails(idProduct);
            dgv_details.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_details.ReadOnly = true;
            dgv_details.Columns["idProduct"].HeaderText = "Tên sản phẩm";
            dgv_details.Columns["idSize"].HeaderText = "Kích thước";
            dgv_details.Columns["idColor"].HeaderText = "Màu";
            dgv_details.Columns["image"].HeaderText = "Ảnh";

            btn_insertdetails.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time.Text = DateTime.Now.ToLongTimeString() + "  -  " + DateTime.Now.ToLongDateString();
        }

        private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                btn_deleteproduct.Enabled = true;
                btn_updateproduct.Enabled = true;
                btn_insertdetails.Enabled = true;

                txt_idproduct.Text = dgv_product.Rows[r].Cells["id"].Value.ToString();
                txt_nameproduct.Text = dgv_product.Rows[r].Cells["nameProduct"].Value.ToString();
                cmb_distribute.SelectedIndex = cmb_distribute.FindString(dgv_product.Rows[r].Cells["idDistribute"].Value.ToString());
                cmb_provider.SelectedIndex = cmb_provider.FindString(dgv_product.Rows[r].Cells["idProvider"].Value.ToString());
                txt_cost.Text = dgv_product.Rows[r].Cells["costPrice"].Value.ToString();
                txt_sale.Text = dgv_product.Rows[r].Cells["rate"].Value.ToString();
                txt_price.Text = dgv_product.Rows[r].Cells["sellingPrice"].Value.ToString();

                string image = ProductDAO.Instance.GetFirstProductImageByID(txt_idproduct.Text);

                if (string.IsNullOrEmpty(image) || !File.Exists(image))
                {
                    pic_product.Image = null;
                }
                else
                {
                    pic_product.Image = Image.FromFile(image);
                }
                string idProduct = txt_idproduct.Text;
                dgv_details.DataSource = ProductDAO.Instance.getlistProductDetails(idProduct);
            }
        }

        private void btn_insertproduct_Click(object sender, EventArgs e)
        {
            Views.Products.frm_insert frm = new Views.Products.frm_insert();
            frm.ShowDialog();
        }
        bool UpdateProduct(string iD, string nameProduct, string idDistribute, string idProvider, float costPrice, float rate)
        {
            return ProductDAO.Instance.UpdateProduct(iD, nameProduct, idDistribute, idProvider, costPrice, rate);
        }
        private void btn_updateproduct_Click(object sender, EventArgs e)
        {
            string iD = txt_idproduct.Text;
            string name = txt_nameproduct.Text;
            string distribute = ((DTO.Distribute)cmb_distribute.SelectedItem).NameDistribute;
            string provider = ((DTO.Provider)cmb_provider.SelectedItem).NameProvider;
            if (!float.TryParse(txt_cost.Text, out float cost) || !float.TryParse(txt_sale.Text, out float rate))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ cho giá và tỷ lệ giảm giá.");
                return;
            }
            if (UpdateProduct(iD, name, distribute, provider, cost, rate))
            {
                MessageBox.Show("Sửa thành công!");
                Clear();
                dgv_product.DataSource = ProductDAO.Instance.getlistProduct();
            }
            else
            {
                MessageBox.Show("Sửa thất bại, vui lòng kiểm tra lại dữ liệu!");
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
            dgv_product.DataSource = ProductDAO.Instance.getlistProduct();
        }
        bool DeleteProduct(string id)
        {
            return ProductDAO.Instance.DeleteProduct(id);
        }
        private void btn_deleteproduct_Click(object sender, EventArgs e)
        {
            string iD = txt_idproduct.Text;
            if (ProductDAO.Instance.GetDataForProduct(iD).Count > 0)
            {
                MessageBox.Show("Không được phép xóa sản phẩm này!");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa sản phẩm này không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (DeleteProduct(iD))
                    {
                        MessageBox.Show("Xóa thành công!");
                        Clear();
                        dgv_product.DataSource = ProductDAO.Instance.getlistProduct();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại, vui lòng kiểm tra lại dữ liệu!");
                    }
                }
            }
        }


        private bool IsValidImageFile(string filePath)
        {
            try
            {
                using (Image img = Image.FromFile(filePath))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void btn_choose_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png|All Files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = open.FileName;
                if (IsValidImageFile(selectedImagePath))
                {
                    pic_product.Image = Image.FromFile(selectedImagePath);
                    txt_link.Text = selectedImagePath;
                }
                else
                {
                    MessageBox.Show("Tệp ảnh không hợp lệ.");
                }
            }
        }

        private void btn_resetdetails_Click(object sender, EventArgs e)
        {
            cmb_color.SelectedIndex = 0;
            cmb_size.SelectedIndex = 0;
            txt_link.Text = "";
            pic_product.Image = null;
        }
        bool InsertProductDetails(string idProduct, string idSize, string idColor, string image)
        {
            return ProductDAO.Instance.InsertProductDetails(idProduct, idSize, idColor, image);
        }
        private void btn_insertdetails_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txt_idproduct.Text))
            {
                string idProduct = txt_idproduct.Text;
                string size = ((DTO.Size)cmb_size.SelectedItem).NameSize;
                string color = ((DTO.Color)cmb_color.SelectedItem).NameColor;
                string image = txt_link.Text;
                if (ProductDAO.Instance.SetInsertProdetails(idProduct, size, color).Count > 0)
                {
                    MessageBox.Show("Đã có trong dữ liệu!");
                }
                else
                {
                    if (InsertProductDetails(idProduct, size, color, image))
                    {
                        MessageBox.Show("Thêm thành công!");
                        Clear();
                        dgv_details.DataSource = ProductDAO.Instance.getlistProductDetails(idProduct);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại dữ liệu!");
                    }
                }
            }
        }
        
        bool DeleteProductDetails(string idProduct, string idSize, string idColor)
        {
            return ProductDAO.Instance.DeleteProductDetails(idProduct, idSize, idColor);
        }
        private void dgv_details_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                string idProduct = txt_idproduct.Text;
                string idSize = dgv_details.Rows[r].Cells["idSize"].Value.ToString();
                string idColor = dgv_details.Rows[r].Cells["idColor"].Value.ToString();
                cmb_size.SelectedIndex = cmb_size.FindString(dgv_details.Rows[r].Cells["idSize"].Value.ToString());
                cmb_color.SelectedIndex = cmb_color.FindString(dgv_details.Rows[r].Cells["idColor"].Value.ToString());
                txt_link.Text = dgv_details.Rows[r].Cells["Image"].Value.ToString();
                if (dgv_details.Rows[r].Cells["Image"].Value.ToString() == "")
                {
                    pic_product.Image = null;
                }
                else
                {
                    pic_product.Image = Image.FromFile(txt_link.Text);
                }
                DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (DeleteProductDetails(idProduct, idSize, idColor))
                    {
                        MessageBox.Show("Xóa thành công!");
                        Clear();
                        dgv_details.DataSource = ProductDAO.Instance.getlistProductDetails(idProduct);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại, vui lòng kiểm tra lại dữ liệu!");
                    }
                }
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (cmb_search.SelectedItem == null || string.IsNullOrEmpty(cmb_search.SelectedItem.ToString()))
            {
                MessageBox.Show("Vui lòng chọn thông tin cần tìm kiếm!");
            }
            else
            {
                string searchdtb = txt_search.Text.Trim();
                if (cmb_search.SelectedItem.ToString() == "Tên sản phẩm")
                {
                    dgv_product.DataSource = ProductDAO.Instance.SearchProduct_nameProduct(searchdtb);
                }
                else if (cmb_search.SelectedItem.ToString() == "Tên nhà cung cấp")
                {
                    dgv_product.DataSource = ProductDAO.Instance.SearchProduct_nameProvider(searchdtb);
                }
                else if (ProductDAO.Instance.SearchProduct_nameProduct(searchdtb).Count == 0 && ProductDAO.Instance.SearchProduct_nameProvider(searchdtb).Count == 0)
                {
                    MessageBox.Show("Không tìm thấy!");
                }
            }
        }
    }
}
