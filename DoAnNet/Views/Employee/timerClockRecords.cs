using DoAnNet.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNet.Views.Employee
{
    public partial class timerClockRecords : UserControl
    {
        public string UserRole { get; set; }

        public timerClockRecords()
        {
            InitializeControl();
            InitializeComponent();
            LoadCmbEmployee();
            timer1.Start();
            SetTime();

            txt_link.Enabled = false;
            btn_timeout.Enabled = false;

            txt_shift.Enabled = false;
            txt_timein.Enabled = false;
            txt_timeout.Enabled = false;
            txt_totalhours.Enabled = false;
            txt_late.Enabled = false;
        }

        public void InitializeControl()
        {
            if (UserRole == "QL")
            {
                btn_delete.Enabled = true;
            }
            else if (UserRole == "NV" || UserRole == "KT")
            {
                btn_delete.Enabled = false;
            }
        }

        void LoadCmbEmployee()
        {
            List<DTO.Employee> employee = EmployeeDAO.Instance.getlistEmployee();
            cmb_employee.DataSource = employee;
            cmb_employee.DisplayMember = "nameEmployee";
        }
        void SetTime()
        {
            string timeString = DateTime.Now.ToString("HH:mm:ss");
            string[] timeParts = timeString.Split(':');
            float hours = float.Parse(timeParts[0]);
            float minutes = float.Parse(timeParts[1]);
            float settime = hours + (minutes / 60);

            if (settime < 8.5)
            {
                btn_ca1.Enabled = false;
                btn_ca2.Enabled = false;
                btn_ca3.Enabled = false;
                btn_fulltime.Enabled = false;
            }
            else if (settime > 8.5 && settime < 12.5)
            {
                btn_ca1.Enabled = true;
                btn_ca2.Enabled = false;
                btn_ca3.Enabled = false;
                btn_fulltime.Enabled = true;
            }
            else if (settime > 13.5 && settime < 18.5)
            {
                btn_ca1.Enabled = false;
                btn_ca2.Enabled = true;
                btn_ca3.Enabled = false;
                btn_fulltime.Enabled = false;
            }
            else if (settime > 18.5 && settime < 22.5)
            {
                btn_ca1.Enabled = false;
                btn_ca2.Enabled = false;
                btn_ca3.Enabled = true;
                btn_fulltime.Enabled = false;
            }
        }
        void Clear()
        {
            cmb_employee.SelectedIndex = 0;
            date_work.Value = DateTime.Now;
            txt_shift.Text = "";
            txt_timein.Text = "";
            txt_timeout.Text = "";
            txt_totalhours.Text = "";
            txt_late.Text = "";
            txt_link.Text = "";
            pic_employee.Image = null;

            cmb_employee.Enabled = true;
            date_work.Enabled = true;
            grb_shift.Enabled = true;
            btn_timein.Enabled = true;
            btn_timeout.Enabled = false;
        }
        private void timerClockRecords_Load(object sender, EventArgs e)
        {
            dgv_TimeClockRecord.DataSource = TimeClockRecordDAO.Instance.getlistTimeClockRecords();
            dgv_TimeClockRecord.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_TimeClockRecord.ReadOnly = true;
            dgv_TimeClockRecord.Columns["idEmployee"].HeaderText = "Tên nhân viên";
            dgv_TimeClockRecord.Columns["idShift"].HeaderText = "Ca làm";
            dgv_TimeClockRecord.Columns["timeIn"].HeaderText = "Giờ vào ca";
            dgv_TimeClockRecord.Columns["timeOutwork"].HeaderText = "Giờ tan ca";
            dgv_TimeClockRecord.Columns["totalHours"].HeaderText = "Tổng giờ";
            dgv_TimeClockRecord.Columns["workDate"].HeaderText = "Ngày làm";
            dgv_TimeClockRecord.Columns["lateDate"].HeaderText = "Đi muộn";
            dgv_TimeClockRecord.Columns["dailySalary"].HeaderText = "Lương ngày";
        }

        private void btn_ca1_Click(object sender, EventArgs e)
        {
            txt_shift.Text = btn_ca1.Text;
        }

        private void btn_ca2_Click(object sender, EventArgs e)
        {
            txt_shift.Text = btn_ca2.Text;
        }

        private void btn_ca3_Click(object sender, EventArgs e)
        {
            txt_shift.Text = btn_ca3.Text;
        }

        private void btn_fulltime_Click(object sender, EventArgs e)
        {
            txt_shift.Text = btn_fulltime.Text;
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string name = txt_search.Text.Trim();
            dgv_TimeClockRecord.DataSource = TimeClockRecordDAO.Instance.Search_TimeClockRecords(name);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string idEmployee = ((DTO.Employee)cmb_employee.SelectedItem).NameEmployee;
            DateTime workDate = date_work.Value;
            string idShift = txt_shift.Text;
            if (TimeClockRecordDAO.Instance.DeleteTimeClockRecords(idEmployee, workDate, idShift))
            {
                MessageBox.Show("Xóa thành công!");
                Clear();
                dgv_TimeClockRecord.DataSource = TimeClockRecordDAO.Instance.getlistTimeClockRecords();
            }
            else
            {
                MessageBox.Show("Xóa thất bại. Vui lòng kiểm tra lại");
            }
        }

        private void btn_timein_Click(object sender, EventArgs e)
        {
            string timeString = DateTime.Now.ToString("HH:mm");
            string[] timeParts = timeString.Split(':');
            float hours = float.Parse(timeParts[0]);
            float minutes = float.Parse(timeParts[1]);
            float timein = hours + (minutes / 60);
            txt_timein.Text = timeString;

            string idEmployee = ((DTO.Employee)cmb_employee.SelectedItem).NameEmployee;
            string idShift = txt_shift.Text;
            DateTime workDate = date_work.Value;
            if (string.IsNullOrEmpty(txt_shift.Text))
            {
                MessageBox.Show("Vui lòng chọn ca làm việc!");
            }
            else
            {
                if (TimeClockRecordDAO.Instance.SetInsert(idEmployee, workDate, idShift).Count > 0)
                {
                    MessageBox.Show("Đã tồn tại! Vui lòng chọn lại ngày và nhân viên cần chấm công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (TimeClockRecordDAO.Instance.InsertTimeIn(idEmployee, idShift, timein, workDate))
                    {
                        MessageBox.Show("Chấm công thành công!");
                        Clear();
                        dgv_TimeClockRecord.DataSource = TimeClockRecordDAO.Instance.getlistTimeClockRecords();
                    }
                    else
                    {
                        MessageBox.Show("Chấm công thất bại. Vui lòng kiểm tra lại");
                    }
                }
            }
        }

        private void btn_timeout_Click(object sender, EventArgs e)
        {
            string timeString = DateTime.Now.ToString("HH:mm");
            string[] timeParts = timeString.Split(':');
            float hours = float.Parse(timeParts[0]);
            float minutes = float.Parse(timeParts[1]);
            float timeout = hours + (minutes / 60);
            txt_timeout.Text = timeString;

            string idEmployee = ((DTO.Employee)cmb_employee.SelectedItem).NameEmployee;
            DateTime workDate = date_work.Value;
            string idShift = txt_shift.Text;
            if (TimeClockRecordDAO.Instance.InsertTimeOut(timeout, idEmployee, workDate, idShift))
            {
                MessageBox.Show("Chấm công thành công!");
                Clear();
                dgv_TimeClockRecord.DataSource = TimeClockRecordDAO.Instance.getlistTimeClockRecords();
            }
            else
            {
                MessageBox.Show("Chấm công thất bại. Vui lòng kiểm tra lại");
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
            dgv_TimeClockRecord.DataSource = TimeClockRecordDAO.Instance.getlistTimeClockRecords();
        }

        private void dgv_TimeClockRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                cmb_employee.SelectedIndex = cmb_employee.FindString(dgv_TimeClockRecord.Rows[r].Cells["idEmployee"].Value.ToString());
                txt_shift.Text = dgv_TimeClockRecord.Rows[r].Cells["idShift"].Value.ToString();

                float timein = float.Parse(dgv_TimeClockRecord.Rows[r].Cells["timeIn"].Value.ToString());
                int nguyen = (int)timein;
                float thapphan = timein - nguyen;
                int minutes = (int)(thapphan * 60);
                txt_timein.Text = nguyen.ToString() + ":"  + minutes.ToString();

                float timeout = float.Parse(dgv_TimeClockRecord.Rows[r].Cells["timeOutwork"].Value.ToString());
                int nguyenout = (int)timeout;
                float thapphanout = timeout - nguyenout;
                int minutesout = (int)(thapphanout * 60);
                txt_timeout.Text = nguyenout.ToString() + ":" + minutesout.ToString();
                if (dgv_TimeClockRecord.Rows[r].Cells["timeOutwork"].Value.ToString() == "0")
                {
                    btn_timeout.Enabled = true;
                }
                else
                {
                    btn_timeout.Enabled = false;
                }

                txt_totalhours.Text = dgv_TimeClockRecord.Rows[r].Cells["totalHours"].Value.ToString();
                string workingday = dgv_TimeClockRecord.Rows[r].Cells["workDate"].Value?.ToString();
                if (!string.IsNullOrEmpty(workingday))
                {
                    if (DateTime.TryParse(workingday, out DateTime date))
                    {
                        date_work.Value = date;
                    }
                    else
                    {
                        MessageBox.Show("Ngày không hợp lệ.");
                    }
                }
                txt_late.Text = dgv_TimeClockRecord.Rows[r].Cells["lateDate"].Value.ToString();

                object nameEmployee = dgv_TimeClockRecord.Rows[r].Cells["IdEmployee"].Value;
                if (nameEmployee != null)
                {
                    string nameEmployeeString = nameEmployee.ToString();
                    DataTable imageTable = EmployeeDAO.Instance.getImageEmployee(nameEmployeeString);
                    if (imageTable.Rows.Count > 0)
                    {
                        string imageLink = imageTable.Rows[0]["employeeImage"].ToString();
                        txt_link.Text = imageLink;
                        pic_employee.Image = Image.FromFile(txt_link.Text);
                    }
                    else
                    {
                        txt_link.Text = "Không tìm thấy hình ảnh";
                        pic_employee.Image = null;
                    }
                }

                cmb_employee.Enabled = false;
                date_work.Enabled = false;
                grb_shift.Enabled = false;
                btn_timein.Enabled = false;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time.Text = DateTime.Now.ToLongTimeString() + "  -  " + DateTime.Now.ToLongDateString();
        }

        private void dgv_TimeClockRecord_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgv_TimeClockRecord.Columns["lateDate"].Index && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int lateDate))
                {
                    string statusText = (lateDate == 0) ? "Đúng giờ" : "Đi muộn";
                    e.Value = statusText;
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
