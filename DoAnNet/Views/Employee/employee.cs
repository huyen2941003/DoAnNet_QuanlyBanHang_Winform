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

namespace DoAnNet.Views.Employee
{
    public partial class employee : UserControl
    {
        public employee()
        {
            InitializeComponent(); txt_link.Enabled = false;
            txt_id.Enabled = false;
            LoadCmbPosition();
            timer1.Start();
        }
        void LoadCmbPosition()
        {
            List<DTO.Position> position = AccountDAO.Instance.getlistPosition();
            cmb_position.DataSource = position;
            cmb_position.DisplayMember = "namePosition";
        }
        void Clear()
        {
            txt_id.Text = "";
            txt_name.Text = "";
            txt_address.Text = "";
            txt_telephone.Text = "";
            txt_search.Text = "";
            date_birthday.Value = DateTime.Now;
            txt_link.Text = "";
            pic_employee.Image = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time.Text = DateTime.Now.ToLongTimeString() + "  -  " + DateTime.Now.ToLongDateString();
        }

        private void employee_Load(object sender, EventArgs e)
        {
            dgv_employee.DataSource = EmployeeDAO.Instance.getlistEmployee();
            dgv_employee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_employee.ReadOnly = true;

            dgv_employee.Columns["id"].HeaderText = "Mã nhân viên";
            dgv_employee.Columns["idPosition"].HeaderText = "Chức vụ";
            dgv_employee.Columns["nameEmployee"].HeaderText = "Tên nhân viên";
            dgv_employee.Columns["birthday"].HeaderText = "Ngày sinh";
            dgv_employee.Columns["address"].HeaderText = "Địa chỉ";
            dgv_employee.Columns["telephone"].HeaderText = "Số điện thoại";
            dgv_employee.Columns["Image"].HeaderText = "Ảnh";

            btn_delete.Enabled = false;
            btn_update.Enabled = false;
        }
        bool DeleteEmployee(string id)
        {
            return EmployeeDAO.Instance.DeleteEmployee(id);
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string iD = txt_id.Text;
            if (EmployeeDAO.Instance.SetDeleteEmployee(iD).Count > 0)
            {
                MessageBox.Show("Không được xóa nhân viên này!");
            }
            else
            {
                if (DeleteEmployee(iD))
                {
                    MessageBox.Show("Xóa thành công!");
                    Clear();
                    dgv_employee.DataSource = EmployeeDAO.Instance.getlistEmployee();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại, vui lòng kiểm tra lại dữ liệu!");
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
            dgv_employee.DataSource = EmployeeDAO.Instance.getlistEmployee();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            Views.Employee.frm_insert frm = new Views.Employee.frm_insert();
            frm.ShowDialog();
        }
        bool UpdateEmployee(string iD, string idPosition, string nameEmployee, DateTime birthday, string telephone, string address, string image)
        {
            return EmployeeDAO.Instance.UpdateEmployee(iD, idPosition, nameEmployee, birthday, telephone, address, image);
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text;
            string position = ((DTO.Position)cmb_position.SelectedItem).NamePosition;
            string name = txt_name.Text;
            DateTime birthday = date_birthday.Value;
            string address = txt_address.Text;
            string telephone = txt_telephone.Text;
            string image = txt_link.Text;
            if (UpdateEmployee(id, position, name, birthday, telephone, address, image))
            {
                MessageBox.Show("Sửa thành công!");
                Clear();
                dgv_employee.DataSource = EmployeeDAO.Instance.getlistEmployee();
            }
            else
            {
                MessageBox.Show("Sửa thất bại, vui lòng kiểm tra lại dữ liệu!");
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
                    pic_employee.Image = Image.FromFile(selectedImagePath);
                    txt_link.Text = selectedImagePath;
                }
                else
                {
                    MessageBox.Show("Tệp ảnh không hợp lệ.");
                }
            }
        }

        private void dgv_employee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txt_id.Text = dgv_employee.Rows[r].Cells["id"].Value.ToString();
                cmb_position.SelectedIndex = cmb_position.FindString(dgv_employee.Rows[r].Cells["idPosition"].Value.ToString());
                txt_name.Text = dgv_employee.Rows[r].Cells["nameEmployee"].Value.ToString();
                string birthday = dgv_employee.Rows[r].Cells["birthday"].Value?.ToString();
                if (!string.IsNullOrEmpty(birthday))
                {
                    if (DateTime.TryParse(birthday, out DateTime date))
                    {
                        date_birthday.Value = date;
                    }
                    else
                    {
                        MessageBox.Show("Ngày sinh không hợp lệ.");
                    }
                }
                txt_telephone.Text = dgv_employee.Rows[r].Cells["telephone"].Value.ToString();
                txt_address.Text = dgv_employee.Rows[r].Cells["address"].Value.ToString();
                txt_link.Text = dgv_employee.Rows[r].Cells["Image"].Value.ToString();
                if (dgv_employee.Rows[r].Cells["Image"].Value.ToString() == "")
                {
                    pic_employee.Image = null;
                }
                else
                {
                    pic_employee.Image = Image.FromFile(txt_link.Text);
                }

                btn_delete.Enabled = true;
                btn_update.Enabled = true;
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (cmb_search.SelectedItem == null || string.IsNullOrEmpty(cmb_search.SelectedItem.ToString()))
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm!");
            }
            else
            {
                string searchdtb = txt_search.Text.Trim();
                if (cmb_search.SelectedItem.ToString() == "Chức vụ")
                {
                    if(!string.IsNullOrEmpty(searchdtb))
                    {
                        dgv_employee.DataSource = EmployeeDAO.Instance.SearchPosition(searchdtb);
                    }
                    else
                    {
                        dgv_employee.DataSource = EmployeeDAO.Instance.getlistEmployee();
                    }
                }
                else if (cmb_search.SelectedItem.ToString() == "Nhân viên")
                {
                    if (!string.IsNullOrEmpty(searchdtb))
                    {
                        dgv_employee.DataSource = EmployeeDAO.Instance.SearchEmployee(searchdtb);
                    }
                    else
                    {
                        dgv_employee.DataSource = EmployeeDAO.Instance.getlistEmployee();
                    }
                }
            }
        }
    }
}
