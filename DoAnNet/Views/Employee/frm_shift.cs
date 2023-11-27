using DoAnNet.DAO;
using DoAnNet.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DoAnNet.Views.Employee
{
    public partial class frm_shift : Form
    {
        public frm_shift()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        void Clear()
        {
            txt_id.Text = string.Empty;
            txt_luong.Text = string.Empty;
            txt_name.Text = string.Empty;
            timein.Text = string.Empty;
            timeout.Text = string.Empty;

            txt_id.Enabled = true;
            btn_insert.Enabled = true;
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
        }
        private void frm_shift_Load(object sender, EventArgs e)
        {
            dgv_shift.DataSource = ShiftDAO.Instance.shiftEmployee();
            dgv_shift.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_shift.ReadOnly = true;
            dgv_shift.Columns["id"].HeaderText = "Mã ca";
            dgv_shift.Columns["nameShift"].HeaderText = "Ca làm";
            dgv_shift.Columns["timeInshift"].HeaderText = "Giờ vào";
            dgv_shift.Columns["timeOutWorkshift"].HeaderText = "Giờ về";
            dgv_shift.Columns["coefficientSalary"].HeaderText = "Hệ số lương";
            txt_id.Enabled = true;
            btn_insert.Enabled = true;
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text;
            string name = txt_name.Text;
            if (!float.TryParse(timein.Text, out float timeinn) || !float.TryParse(timeout.Text, out float timeoutt) || !float.TryParse(txt_luong.Text, out float coff) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ và đầy đủ các giá trị.");
                return;
            }
            else
            {
                if (ShiftDAO.Instance.GetNameshift(name).Count > 0 || ShiftDAO.Instance.GetIdshift(id).Count > 0)
                {
                    MessageBox.Show("TTên hoặc id đã tồn tại!");
                    txt_id.Text = "";
                    txt_name.Text = "";
                }
                else
                {
                    if (ShiftDAO.Instance.InsertEmployee(id, name, timeinn, timeoutt, coff))
                    {
                        MessageBox.Show("Thêm thành công!");
                        dgv_shift.DataSource = ShiftDAO.Instance.shiftEmployee();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại dữ liệu!");
                    }
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text;
            string name = txt_name.Text;
            if (!float.TryParse(timein.Text, out float timeinn) || !float.TryParse(timeout.Text, out float timeoutt) || !float.TryParse(txt_luong.Text, out float coff) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ và đầy đủ các giá trị.");
                return;
            }
            else
            {
                if (ShiftDAO.Instance.GetNameshift(name).Count > 0)
                {
                    MessageBox.Show("Tên ca đã tồn tại!");
                    txt_name.Text = "";
                }
                else
                {
                    if (ShiftDAO.Instance.UpdateshiftEmployee(id, name, timeinn, timeoutt, coff))
                    {
                        MessageBox.Show("Sửa thành công!");
                        dgv_shift.DataSource = ShiftDAO.Instance.shiftEmployee();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại, vui lòng kiểm tra lại dữ liệu!");
                    }
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text;
            if (ShiftDAO.Instance.setdelete(id).Count > 0)
            {
                MessageBox.Show("Không được xóa!");
                Clear();
            }
            else
            {
                if (ShiftDAO.Instance.DeleteColor(id))
                {
                    MessageBox.Show("Xóa thành công!");
                    dgv_shift.DataSource = ShiftDAO.Instance.shiftEmployee();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại, vui lòng kiểm tra lại dữ liệu!");
                }
            }
        }

        private void dgv_shift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txt_id.Text = dgv_shift.Rows[r].Cells["id"].Value.ToString();
                txt_name.Text = dgv_shift.Rows[r].Cells["nameShift"].Value.ToString();
                timein.Text = dgv_shift.Rows[r].Cells["timeInshift"].Value.ToString();
                timeout.Text = dgv_shift.Rows[r].Cells["timeOutWorkshift"].Value.ToString();
                txt_luong.Text = dgv_shift.Rows[r].Cells["coefficientSalary"].Value.ToString();

                txt_id.Enabled = false;
                btn_insert.Enabled = false;
                btn_delete.Enabled = true;
                btn_update.Enabled = true;
            }
        }
    }
}
