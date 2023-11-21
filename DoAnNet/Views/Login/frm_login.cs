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
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.WindowState = FormWindowState.Maximized;
        }
        private void frm_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        { 
            string userName = txt_user.Text;
            string pass = txt_password.Text;
            List<Account> accounts = AccountDAO.Instance.Login(userName, pass);
            if (string.IsNullOrEmpty(txt_user.Text) || string.IsNullOrEmpty(txt_password.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin tài khoản và mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (AccountDAO.Instance.Login(userName, pass).Count > 0)
                {
                    Account loggedInUser = accounts[0];
                    //Views.Home.frm_main frm = new Views.Home.frm_main();
                    Views.Home.frm_main frm = new Views.Home.frm_main(loggedInUser.IdPosition);
                    this.Hide();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại tên tài khoản hoặc mật khẩu");
                }
            }
        }

        private void frm_login_Load(object sender, EventArgs e)
        {

        }
    }
}
