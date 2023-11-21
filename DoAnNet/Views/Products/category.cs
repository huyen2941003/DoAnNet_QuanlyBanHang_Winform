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

namespace DoAnNet.Views.Products
{
    public partial class category : UserControl
    {
        public category()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time.Text = DateTime.Now.ToLongTimeString() + "  -  " + DateTime.Now.ToLongDateString();
        }
        public void Clear()
        {
            txt_idcolor.Text = "";
            txt_iddistribute.Text = "";
            txt_idsize.Text = "";
            txt_namecolor.Text = "";
            txt_namedistribute.Text = "";
            txt_namesize.Text = "";

            btn_deletecolor.Enabled = false;
            btn_updatecolor.Enabled = false;
            txt_idcolor.Enabled = true;
            btn_insertcolor.Enabled = true;

            btn_deletesize.Enabled = false;
            btn_updatesize.Enabled = false;
            txt_idsize.Enabled = true;
            btn_insertsize.Enabled = true;

            btn_deletedistribute.Enabled = false;
            btn_updatedistribute.Enabled = false;
            txt_iddistribute.Enabled = true;
            btn_insertdistribute.Enabled = true;

        }
        private void category_Load(object sender, EventArgs e)
        {
            dgv_color.DataSource = CategoryDAO.Instance.getlistColor();
            dgv_color.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_color.ReadOnly = true;
            dgv_color.Columns["id"].HeaderText = "Mã màu";
            dgv_color.Columns["nameColor"].HeaderText = "Tên màu";

            dgv_size.DataSource = CategoryDAO.Instance.getlistSize();
            dgv_size.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_size.ReadOnly = true;
            dgv_size.Columns["id"].HeaderText = "Mã size";
            dgv_size.Columns["nameSize"].HeaderText = "Tên size";

            dgv_distribute.DataSource = CategoryDAO.Instance.getlistDistribute();
            dgv_distribute.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_distribute.ReadOnly = true;
            dgv_distribute.Columns["id"].HeaderText = "Mã loại";
            dgv_distribute.Columns["nameDistribute"].HeaderText = "Tên loại";

            btn_deletecolor.Enabled = false;
            btn_updatecolor.Enabled = false;
            btn_deletesize.Enabled = false;
            btn_updatesize.Enabled = false;
            btn_deletedistribute.Enabled = false;
            btn_updatedistribute.Enabled = false;
        }

        //Color
        private void btn_resetcolor_Click(object sender, EventArgs e)
        {
            Clear();
            dgv_color.DataSource = CategoryDAO.Instance.getlistColor();
        }

        private void btn_updatecolor_Click(object sender, EventArgs e)
        {
            string iD = txt_idcolor.Text;
            string name = txt_namecolor.Text;
            if (CategoryDAO.Instance.UpdateColor(iD, name))
            {
                MessageBox.Show("Sửa thành công!");
                Clear();
                dgv_color.DataSource = CategoryDAO.Instance.getlistColor();
            }
            else
            {
                MessageBox.Show("Sửa thất bại, vui lòng kiểm tra lại dữ liệu!");
            }
        }

        private void btn_insertcolor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_idcolor.Text) || string.IsNullOrEmpty(txt_namecolor.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
            else
            {
                string iD = txt_idcolor.Text;
                string name = txt_namecolor.Text;
                if (CategoryDAO.Instance.GetNameColor(name).Count > 0 || CategoryDAO.Instance.GetIdColor(iD).Count > 0)
                {
                    MessageBox.Show("Mã màu hoặc tên màu của bạn đã tồn tại! Vui lòng kiểm tra lại", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (CategoryDAO.Instance.InsertColor(iD, name))
                    {
                        MessageBox.Show("Thêm màu mới thành công!");
                        Clear();
                        dgv_color.DataSource = CategoryDAO.Instance.getlistColor();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại dữ liệu!");
                    }
                }

            }
        }

        private void btn_deletecolor_Click(object sender, EventArgs e)
        {
            string iD = txt_idcolor.Text;
            string name = txt_namecolor.Text;
            if (CategoryDAO.Instance.SetDeleteColor(iD).Count > 0)
            {
                MessageBox.Show("Màu " + name + " này đang được gán cho 1 số sản phẩm trong cửa hàng. Không được xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (CategoryDAO.Instance.DeleteColor(iD))
                {
                    MessageBox.Show("Xóa thành công!");
                    Clear();
                    dgv_color.DataSource = CategoryDAO.Instance.getlistColor();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại, vui lòng kiểm tra lại dữ liệu!");
                }
            }
        }

        private void dgv_color_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txt_idcolor.Enabled = false;
                btn_deletecolor.Enabled = true;
                btn_updatecolor.Enabled = true;
                btn_insertcolor.Enabled = false;
                txt_idcolor.Text = dgv_color.Rows[r].Cells["iD"].Value.ToString();
                txt_namecolor.Text = dgv_color.Rows[r].Cells["nameColor"].Value.ToString();
            }
        }


        //Size
        private void btn_deletesize_Click(object sender, EventArgs e)
        {
            string iD = txt_idsize.Text;
            string name = txt_namesize.Text;
            if (CategoryDAO.Instance.SetDeleteSize(iD).Count > 0)
            {
                MessageBox.Show("Size " + name + " này đang được gán cho 1 số sản phẩm trong cửa hàng. Không được xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (CategoryDAO.Instance.DeleteSize(iD))
                {
                    MessageBox.Show("Xóa thành công!");
                    Clear();
                    dgv_size.DataSource = CategoryDAO.Instance.getlistSize();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại, vui lòng kiểm tra lại dữ liệu!");
                }
            }
        }

        private void btn_updatesize_Click(object sender, EventArgs e)
        {
            string iD = txt_idsize.Text;
            string name = txt_namesize.Text;
            if (CategoryDAO.Instance.UpdateSize(iD, name))
            {
                MessageBox.Show("Sửa thành công!");
                Clear();
                dgv_size.DataSource = CategoryDAO.Instance.getlistSize();
            }
            else
            {
                MessageBox.Show("Sửa thất bại, vui lòng kiểm tra lại dữ liệu!");
            }
        }

        private void btn_insertsize_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_namesize.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
            else
            {
                string iD = txt_idsize.Text;
                string name = txt_namesize.Text;
                if (CategoryDAO.Instance.GetNameSize(name).Count > 0 || CategoryDAO.Instance.GetIdSize(iD).Count > 0)
                {
                    MessageBox.Show("Mã size hoặc tên size của bạn đã tồn tại! Vui lòng kiểm tra lại", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (CategoryDAO.Instance.InsertSize(iD, name))
                    {
                        MessageBox.Show("Thêm size mới thành công!");
                        Clear();
                        dgv_size.DataSource = CategoryDAO.Instance.getlistSize();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại dữ liệu!");
                    }
                }
            }
        }

        private void btn_resetsize_Click(object sender, EventArgs e)
        {
            Clear();
            dgv_size.DataSource = CategoryDAO.Instance.getlistSize();
        }

        private void dgv_size_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txt_idsize.Enabled = false;
                btn_deletesize.Enabled = true;
                btn_updatesize.Enabled = true;
                btn_insertsize.Enabled = false;
                txt_idsize.Text = dgv_size.Rows[r].Cells["iD"].Value.ToString();
                txt_namesize.Text = dgv_size.Rows[r].Cells["nameSize"].Value.ToString();
            }
        }

        //Distribute
        private void btn_deletedistribute_Click(object sender, EventArgs e)
        {
            string iD = txt_iddistribute.Text;
            string name = txt_namedistribute.Text;
            if (CategoryDAO.Instance.SetDeleteDistribute(iD).Count > 0)
            {
                MessageBox.Show("Loại " + name + " này đang được gán cho 1 số sản phẩm trong cửa hàng. Không được xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (CategoryDAO.Instance.DeleteDistribute(iD))
                {
                    MessageBox.Show("Xóa thành công!");
                    Clear();
                    dgv_distribute.DataSource = CategoryDAO.Instance.getlistDistribute();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại, vui lòng kiểm tra lại dữ liệu!");
                }
            }
        }

        private void btn_updatedistribute_Click(object sender, EventArgs e)
        {
            string iD = txt_iddistribute.Text;
            string name = txt_namedistribute.Text;
            if (CategoryDAO.Instance.UpdateDistribute(iD, name))
            {
                MessageBox.Show("Sửa thành công!");
                Clear();
                dgv_distribute.DataSource = CategoryDAO.Instance.getlistDistribute();
            }
            else
            {
                MessageBox.Show("Sửa thất bại, vui lòng kiểm tra lại dữ liệu!");
            }
        }

        private void btn_insertdistribute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_iddistribute.Text) || string.IsNullOrEmpty(txt_namedistribute.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
            else
            {
                string iD = txt_iddistribute.Text;
                string name = txt_namedistribute.Text;
                if (CategoryDAO.Instance.GetNameDistribute(name).Count > 0 || CategoryDAO.Instance.GetIdDistribute(iD).Count > 0)
                {
                    MessageBox.Show("Mã loại hàng hoặc tên loại hàng của bạn đã tồn tại! Vui lòng kiểm tra lại", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (CategoryDAO.Instance.InsertDistribute(iD, name))
                    {
                        MessageBox.Show("Thêm loại mới thành công!");
                        Clear();
                        dgv_distribute.DataSource = CategoryDAO.Instance.getlistDistribute();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại dữ liệu!");
                    }
                }
            }
        }

        private void btn_resetdistribute_Click(object sender, EventArgs e)
        {
            Clear();
            dgv_distribute.DataSource = CategoryDAO.Instance.getlistDistribute();
        }

        private void dgv_distribute_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txt_iddistribute.Enabled = false;
                btn_deletedistribute.Enabled = true;
                btn_updatedistribute.Enabled = true;
                btn_insertdistribute.Enabled = false;
                txt_iddistribute.Text = dgv_distribute.Rows[r].Cells["iD"].Value.ToString();
                txt_namedistribute.Text = dgv_distribute.Rows[r].Cells["nameDistribute"].Value.ToString();
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (cmb_search.SelectedItem == null || string.IsNullOrEmpty(cmb_search.SelectedItem.ToString()))
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm và chọn loại tìm kiếm!");
            }
            else
            {
                string searchdtb = txt_search.Text.Trim();
                if (cmb_search.SelectedItem.ToString() == "Màu sắc")
                {
                    dgv_color.DataSource = CategoryDAO.Instance.Search_Color(searchdtb);
                }
                else if (cmb_search.SelectedItem.ToString() == "Kích thước")
                {
                    dgv_size.DataSource = CategoryDAO.Instance.Search_Size(searchdtb);
                }
                else if (cmb_search.SelectedItem.ToString() == "Loại hàng")
                {
                    dgv_distribute.DataSource = CategoryDAO.Instance.Search_Distribute(searchdtb);
                }
            }
        }
    }
}
