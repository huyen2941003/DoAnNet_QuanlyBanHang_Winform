using DoAnNet.Views.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNet.Views.Home
{
    public partial class frm_main : Form
    {
        private string userRole;
        public string UserRole { get => userRole; set => userRole = value; }
        public frm_main(string userRole)
        {
            InitializeComponent();
            this.UserRole = userRole;
            DisplayAccount(userRole);
            timer1.Start();
        }
        private void DisplayAccount(string role)
        {
            if (role == "QL")
            {
                menuproduct.Visible = true;
                menudiscount.Visible = true;
                menuprovider.Visible = true;
                menuinvoice.Visible = true;
                menuemployee.Visible = true;
                menustatistic.Visible = true;
                menuaccount.Visible = true;
                menusetting.Visible = true;
                timelineChấmCôngToolStripMenuItem.Visible = true;
            }
            else if (role == "NV")
            {
                menuproduct.Visible = true;
                menudiscount.Visible = true;
                menuprovider.Visible = true;
                menuinvoice.Visible = true;
                menuemployee.Visible = true;
                thôngTinNhânViênToolStripMenuItem.Visible = false;
                menustatistic.Visible = false;
                menuaccount.Visible = false;
                menusetting.Visible = true;
                timelineChấmCôngToolStripMenuItem.Visible = false;
            }
            else if (role == "KT")
            {
                menuproduct.Visible = true;
                menudiscount.Visible = true;
                menuprovider.Visible = true;
                menuinvoice.Visible = true;
                menuemployee.Visible = true;
                thôngTinNhânViênToolStripMenuItem.Visible = true;
                menustatistic.Visible = true;
                menuaccount.Visible = false;
                menusetting.Visible = true;
                timelineChấmCôngToolStripMenuItem.Visible = true;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.WindowState = FormWindowState.Maximized;
        }
        private void frm_main_Load(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm != null && frm.Name != "frm_login")
                    {
                        frm.Close();
                    }
                }

                Views.Login.frm_login loginForm = new Views.Login.frm_login();
                loginForm.Show();
                this.Close();
            }
        }

        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void đăngKýTàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Views.Login.frm_register frm = new Views.Login.frm_register();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void xemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Views.Login.frm_account frm = new Views.Login.frm_account();
            frm.ShowDialog();
        }

        private void date_time_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time.Text = DateTime.Now.ToLongTimeString() + "  -  " + DateTime.Now.ToLongDateString();
        }

        private void thôngTinkhacToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Views.Products.category myControl = new Views.Products.category();
            pnl_control.Controls.Clear();
            pnl_control.Controls.Add(myControl);
        }

        private void thongTinSanphamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Products.product myControl = new Views.Products.product();
            pnl_control.Controls.Clear();
            pnl_control.Controls.Add(myControl);
        }

        private void sửaChươngTrìnhKhuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Discount.discount myControl = new Views.Discount.discount();
            pnl_control.Controls.Clear();
            pnl_control.Controls.Add(myControl);
        }

        private void thêmSảnPhẩmVàoChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Discount.frm_details frm = new Views.Discount.frm_details();
            frm.ShowDialog();
        }

        private void thôngTinNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Provider.provider myControl = new Views.Provider.provider();
            pnl_control.Controls.Clear();
            pnl_control.Controls.Add(myControl);
        }

        private void tìnhTrạngNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Provider.frm_debt frm = new Views.Provider.frm_debt();
            frm.ShowDialog();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Invoices.inputInvoices myControl = new Views.Invoices.inputInvoices();
            pnl_control.Controls.Clear();
            pnl_control.Controls.Add(myControl);
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Invoices.saleInvoices myControl = new Views.Invoices.saleInvoices();
            pnl_control.Controls.Clear();
            pnl_control.Controls.Add(myControl);
        }

        private void tìnhTrạngHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Invoices.statusInvoice myControl = new Views.Invoices.statusInvoice();
            pnl_control.Controls.Clear();
            pnl_control.Controls.Add(myControl);
        }

        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Employee.employee myControl = new Views.Employee.employee();
            pnl_control.Controls.Clear();
            pnl_control.Controls.Add(myControl);
        }
        private void timelineChấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Employee.frm_timeline frm = new Views.Employee.frm_timeline();
            frm.ShowDialog();
        }
        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Employee.timerClockRecords myControl = new Views.Employee.timerClockRecords();
            pnl_control.Controls.Clear();
            pnl_control.Controls.Add(myControl);
        }

        private void thốngKêDoanhthuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Revenue.revenue myControl = new Views.Revenue.revenue();
            pnl_control.Controls.Clear();
            pnl_control.Controls.Add(myControl);
        }

        private void sốLượngHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Products.frm_inventory frm = new Views.Products.frm_inventory();
            frm.ShowDialog();
        }

        private void caLàmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.Employee.frm_shift frm = new Views.Employee.frm_shift();
            frm.ShowDialog();
        }
    }
}
