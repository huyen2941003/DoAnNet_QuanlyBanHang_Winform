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
    public partial class frm_insert : Form
    {
        public frm_insert()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txt_link.Enabled = false;
            LoadCmbPosition();
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
            date_birthday.Value = DateTime.Now;
            txt_link.Text = "";
            pic_employee.Image = null;
        }
        bool InsertEmployee(string iD, string idPosition, string nameEmployee, DateTime birthday, string telephone, string address, string image)
        {
            return EmployeeDAO.Instance.InsertEmployee(iD, idPosition, nameEmployee, birthday, telephone, address, image);
        }
        private void btn_insert_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text;
            string position = ((DTO.Position)cmb_position.SelectedItem).NamePosition;
            string name = txt_name.Text;
            DateTime birthday = date_birthday.Value;
            string address = txt_address.Text;
            string telephone = txt_telephone.Text;
            string image = txt_link.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(telephone))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
            else
            {
                if (EmployeeDAO.Instance.SetInsert(id).Count > 0)
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại! Vui lòng nhập lại", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_id.Text = "";
                }
                else
                {
                    if (InsertEmployee(id, position, name, birthday, telephone, address, image))
                    {
                        MessageBox.Show("Thêm thành công!");
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại dữ liệu!");
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
                    pic_employee.Image = Image.FromFile(selectedImagePath);
                    txt_link.Text = selectedImagePath;
                }
                else
                {
                    MessageBox.Show("Tệp ảnh không hợp lệ.");
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
