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
    public partial class discount : UserControl
    {
        public discount()
        {
            InitializeComponent();
            timer1.Start();
        }
        void Clear()
        {
            txt_id.Text = "";
            txt_name.Text = "";
            date_start.Value = DateTime.Now;
            date_end.Value = DateTime.Now;
            txt_percent.Text = "";
            txt_search.Text = "";

            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            txt_id.Enabled = true;
            btn_insert.Enabled = true;
        }
        private void discount_Load(object sender, EventArgs e)
        {
            btn_delete.Enabled = false;
            btn_update.Enabled = false;

            dgv_discount.DataSource = DiscountDAO.Instance.getlistDiscount();
            dgv_discount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_discount.ReadOnly = true;
            dgv_discount.Columns["id"].HeaderText = "Mã giảm giá";
            dgv_discount.Columns["nameDiscount"].HeaderText = "Tên chương trình";
            dgv_discount.Columns["startDiscount"].HeaderText = "Ngày bắt đầu";
            dgv_discount.Columns["finishDiscount"].HeaderText = "Ngày kết thúc";
            dgv_discount.Columns["percentDiscount"].HeaderText = "Phần trăm giảm giá";
        }
        bool DeleteDiscount(string iD)
        {
            return DiscountDAO.Instance.DeleteDiscount(iD);
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string iD = txt_id.Text;
            if (DiscountDAO.Instance.SetDelete(iD).Count > 0)
            {
                MessageBox.Show("Chương trình này đang được áp dụng cho 1 số sản phẩm! \n Vui lòng xóa chương trình bên sản phẩm trước khi xóa chương trình", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (DeleteDiscount(iD))
                {
                    MessageBox.Show("Xóa thành công!");
                    Clear();
                    dgv_discount.DataSource = DiscountDAO.Instance.getlistDiscount();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Vui lòng kiểm tra lại");
                }
            }
        }
        bool InSertDiscount(string iD, string nameDiscount, DateTime startDiscount, DateTime finishDiscount, float percentDiscount)
        {
            return DiscountDAO.Instance.InsertDiscount(iD, nameDiscount, startDiscount, finishDiscount, percentDiscount);
        }
        private void btn_insert_Click(object sender, EventArgs e)
        {
            string iD = txt_id.Text;
            string nameDiscount = txt_name.Text;
            DateTime startDiscount = date_start.Value;
            DateTime finishDiscount = date_end.Value;
            if (!float.TryParse(txt_percent.Text, out float percentDiscount))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ cho phần trăm giảm giá");
            }

            if (DiscountDAO.Instance.SetInsert(iD).Count > 0)
            {
                MessageBox.Show("Mã chương trình này đã tồn tại. Vui lòng nhập lại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (startDiscount > finishDiscount)
                {
                    MessageBox.Show("Ngày bắt đầu không thể sau ngày kết thúc chương trình", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    date_start.Value = DateTime.Now;
                    date_end.Value = DateTime.Now;
                }
                else
                {
                    if (InSertDiscount(iD, nameDiscount, startDiscount, finishDiscount, percentDiscount))
                    {
                        MessageBox.Show("Thêm thành công!");
                        Clear();
                        dgv_discount.DataSource = DiscountDAO.Instance.getlistDiscount();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại. Vui lòng kiểm tra lại");
                    }
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
            dgv_discount.DataSource = DiscountDAO.Instance.getlistDiscount();
        }
        bool UpdateDiscount(string iD, string nameDiscount, DateTime startDiscount, DateTime finishDiscount, float percentDiscount)
        {
            return DiscountDAO.Instance.UpdateDiscount(iD, nameDiscount, startDiscount, finishDiscount, percentDiscount);
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            string iD = txt_id.Text;
            string nameDiscount = txt_name.Text;
            DateTime startDiscount = date_start.Value;
            DateTime finishDiscount = date_end.Value;
            if (!float.TryParse(txt_percent.Text, out float percentDiscount))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ cho phần trăm giảm giá");
            }
            else
            {
                if (startDiscount > finishDiscount)
                {
                    MessageBox.Show("Ngày bắt đầu không thể sau ngày kết thúc chương trình", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    date_start.Value = DateTime.Now;
                    date_end.Value = DateTime.Now;
                }
                else
                {
                    if (UpdateDiscount(iD, nameDiscount, startDiscount, finishDiscount, percentDiscount))
                    {
                        MessageBox.Show("Sửa thành công!");
                        Clear();
                        dgv_discount.DataSource = DiscountDAO.Instance.getlistDiscount();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại. Vui lòng kiểm tra lại");
                    }
                }
            }
            
        }

        private void dgv_discount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txt_id.Enabled = false;
                btn_delete.Enabled = true;
                btn_update.Enabled = true;
                btn_insert.Enabled = false;

                txt_id.Text = dgv_discount.Rows[r].Cells["id"].Value.ToString();
                txt_name.Text = dgv_discount.Rows[r].Cells["nameDiscount"].Value.ToString();
                string start = dgv_discount.Rows[r].Cells["startDiscount"].Value?.ToString();
                if (!string.IsNullOrEmpty(start))
                {
                    if (DateTime.TryParse(start, out DateTime startdate))
                    {
                        date_start.Value = startdate;
                    }
                    else
                    {
                        MessageBox.Show("Ngày không hợp lệ.");
                    }
                }

                string end = dgv_discount.Rows[r].Cells["finishDiscount"].Value?.ToString();
                if (!string.IsNullOrEmpty(end))
                {
                    if (DateTime.TryParse(end, out DateTime enddate))
                    {
                        date_end.Value = enddate;
                    }
                    else
                    {
                        MessageBox.Show("Ngày không hợp lệ.");
                    }
                }
                txt_percent.Text = dgv_discount.Rows[r].Cells["percentDiscount"].Value.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time.Text = DateTime.Now.ToLongTimeString() + "  -  " + DateTime.Now.ToLongDateString();
        }
    }
}
