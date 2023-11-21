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

namespace DoAnNet.Views.Login
{
    public partial class frm_register : Form
    {
        public frm_register()
        {
            InitializeComponent();
            LoadCmbPosition();
        }
        void LoadCmbPosition()
        {
            List<DTO.Position> position = AccountDAO.Instance.getlistPosition();
            cmb_position.DataSource = position;
            cmb_position.DisplayMember = "namePosition";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.WindowState = FormWindowState.Maximized;
        }

        bool InsertAccount(string username, string password, string position)
        {
            return AccountDAO.Instance.InsertAccount(username, password, position);
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            string position = ((DTO.Position)cmb_position.SelectedItem).NamePosition;
            string userName = txt_user.Text;
            string passWord = txt_password.Text;
            string retype = txt_retype.Text;
            if (string.IsNullOrEmpty(txt_user.Text) || string.IsNullOrEmpty(txt_password.Text) ||
                string.IsNullOrEmpty(txt_retype.Text) || string.IsNullOrEmpty(cmb_position.SelectedValue.ToString()) || retype != passWord)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và kiểm tra lại thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (AccountDAO.Instance.SetInsert(userName).Count > 0)
                {
                    MessageBox.Show("Tài khoản của bạn đã tồn tại, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (InsertAccount(userName, passWord, position))
                    {
                        MessageBox.Show("Tạo tài khoản thành công!");
                        Views.Login.frm_login frm = new Views.Login.frm_login();
                        this.Hide();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản của bạn đã tồn tại, vui lòng nhập lại!");
                    }
                }
            }
        }
    }
}
