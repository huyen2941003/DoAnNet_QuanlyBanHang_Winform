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
    public partial class frm_shift : Form
    {
        public frm_shift()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frm_shift_Load(object sender, EventArgs e)
        {
            dgv_shift.DataSource = TimeClockRecordDAO.Instance.shiftEmployee();
            dgv_shift.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_shift.ReadOnly = true;
            dgv_shift.Columns["id"].HeaderText = "Mã ca";
            dgv_shift.Columns["nameShift"].HeaderText = "Ca làm";
            dgv_shift.Columns["timeInshift"].HeaderText = "Giờ vào";
            dgv_shift.Columns["timeOutWorkshift"].HeaderText = "Giờ về";
            dgv_shift.Columns["coefficientSalary"].HeaderText = "Hệ số lương";
        }
    }
}
