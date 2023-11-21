using DoAnNet.DAO;
using DoAnNet.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNet.Views.Login
{
    public partial class frm_account : Form
    {
        public frm_account()
        {
            InitializeComponent();
            txt_user.Enabled = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        void Clear()
        {
            txt_user.Text = "";
            txt_pass.Text = "";
        }
        private void frm_account_Load(object sender, EventArgs e)
        {
            dgv_account.DataSource = AccountDAO.Instance.getlistAccount();
            dgv_account.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_account.ReadOnly = true;

            dgv_account.Columns["idPosition"].HeaderText = "Chức vụ";
            dgv_account.Columns["userName"].HeaderText = "Tên tài khoản";
            dgv_account.Columns["pass"].HeaderText = "Mật khẩu";
        }
        bool Update(string username, string pass)
        {
            return AccountDAO.Instance.UpdatePassWord(username, pass);
        }
        private void btn_updatepass_Click(object sender, EventArgs e)
        {
            string username = txt_user.Text;
            string pass = txt_pass.Text;
            if (Update(username, pass))
            {
                MessageBox.Show("Sửa mật khẩu thành công!");
                Clear();
                dgv_account.DataSource = AccountDAO.Instance.getlistAccount();
            }
            else
            {
                MessageBox.Show("Sửa mật khẩu tài khoản thất bại, vui lòng kiểm tra lại dữ liệu!");
            }
        }
        bool Delete(string username)
        {
            return AccountDAO.Instance.DeleteAccount(username);
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string name = txt_user.Text;
            if (name == "Admin")
            {
                MessageBox.Show("Tài khoản này là tài khoản cố định. Bạn không được xóa!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Delete(name))
                {
                    MessageBox.Show("Xóa tài khoản thành công!");
                    Clear();
                    dgv_account.DataSource = AccountDAO.Instance.getlistAccount();
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại, vui lòng kiểm tra lại dữ liệu!");
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
            dgv_account.DataSource = AccountDAO.Instance.getlistAccount();
        }

        private void dgv_account_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txt_user.Text = dgv_account.Rows[r].Cells["userName"].Value.ToString();
                txt_pass.Text = dgv_account.Rows[r].Cells["pass"].Value.ToString();
            }
        }
    }
}
