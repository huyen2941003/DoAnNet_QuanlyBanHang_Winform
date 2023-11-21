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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAnNet.Views.Employee
{
    public partial class frm_timeline : Form
    {
        public frm_timeline()
        {
            InitializeComponent();
            txt_id.Enabled = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadCmbEmployee();
            LoadShift();
        }
        void LoadCmbEmployee()
        {
            List<DTO.Employee> employee = EmployeeDAO.Instance.getlistEmployee();
            cmb_employee.DataSource = employee;
            cmb_employee.DisplayMember = "nameEmployee";
            cmb_employeee.DataSource = employee;
            cmb_employeee.DisplayMember = "nameEmployee";
        }
        void LoadShift()
        {
            List<DTO.shiftEmployee> shift = EmployeeDAO.Instance.getlistShift();
            cmb_shift.DataSource = shift;
            cmb_shift.DisplayMember = "nameShift";
        }

        private void frm_timeline_Load(object sender, EventArgs e)
        {
            dgv_timeline.DataSource = TimelineDAO.Instance.getlistTimeline();
            dgv_timeline.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_timeline.ReadOnly = true;
            dgv_timeline.Columns["id"].HeaderText = "Mã timeline";
            dgv_timeline.Columns["nameTimeline"].HeaderText = "Tên";
            dgv_timeline.Columns["dayWork"].HeaderText = "Ngày làm";

            string id = txt_id.Text;
            dgv_timelinedetails.DataSource = TimelineDAO.Instance.getlistTimelineDetails(id);
            dgv_timelinedetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_timelinedetails.ReadOnly = true;
            dgv_timelinedetails.Columns["idTimeline"].HeaderText = "Tên timeline";
            dgv_timelinedetails.Columns["idEmployee"].HeaderText = "Tên nhân viên";
            dgv_timelinedetails.Columns["idShift"].HeaderText = "Ca";

            DateTime datework = date_dateItimeline.Value;
            dgv_TimeClockRecords.DataSource = TimelineDAO.Instance.getlistTimeClockRecords(datework);
            dgv_TimeClockRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_TimeClockRecords.ReadOnly = true;
            dgv_TimeClockRecords.Columns["idEmployee"].HeaderText = "Tên nhân viên";
            dgv_TimeClockRecords.Columns["idShift"].HeaderText = "Ca làm";
            dgv_TimeClockRecords.Columns["timeIn"].HeaderText = "Giờ vào ca";
            dgv_TimeClockRecords.Columns["timeOutwork"].HeaderText = "Giờ tan ca";
            dgv_TimeClockRecords.Columns["totalHours"].HeaderText = "Tổng giờ";
            dgv_TimeClockRecords.Columns["workDate"].HeaderText = "Ngày làm";
            dgv_TimeClockRecords.Columns["lateDate"].HeaderText = "Đi muộn";
            dgv_TimeClockRecords.Columns["dailySalary"].HeaderText = "Lương ngày";

        }
        private void dgv_timeline_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r  = e.RowIndex;
            if(r>=0)
            {
                txt_id.Text = dgv_timeline.Rows[r].Cells["id"].Value.ToString();
                string dayWork = dgv_timeline.Rows[r].Cells["dayWork"].Value?.ToString();
                if (!string.IsNullOrEmpty(dayWork))
                {
                    if (DateTime.TryParse(dayWork, out DateTime date))
                    {
                        date_dateItimeline.Value = date;
                    }
                    else
                    {
                        MessageBox.Show("Ngày không hợp lệ.");
                    }
                }
                dgv_timelinedetails.DataSource = TimelineDAO.Instance.getlistTimelineDetails(txt_id.Text);
                dgv_TimeClockRecords.DataSource = TimelineDAO.Instance.getlistTimeClockRecords(date_dateItimeline.Value);
            }    
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            DateTime daywork = date_dateItimeline.Value;
            DialogResult result = MessageBox.Show("Bạn có muốn thêm Timeline mới?", "Thông báo!", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                if(TimelineDAO.Instance.setinsertTimeline(daywork).Count > 0)
                {
                    MessageBox.Show("Đã tạo timeline cho ngày " + daywork);
                }
                else
                {
                    if (TimelineDAO.Instance.InsertTimeline(daywork))
                    {
                        MessageBox.Show("Thêm thành công!");
                        dgv_timeline.DataSource = TimelineDAO.Instance.getlistTimeline();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
            }    
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txt_id.Text))
            {
                if(TimelineDAO.Instance.SetdeleteTimeline(txt_id.Text).Count > 0)
                {
                    MessageBox.Show("Không được phép xóa timeline này!");
                }
                else
                {
                    if (TimelineDAO.Instance.DeleteTimeline(txt_id.Text))
                    {
                        dgv_timeline.DataSource = TimelineDAO.Instance.getlistTimeline();
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn timeline bạn muốn xóa!");
            } 
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text;
            string employee = ((DTO.Employee)cmb_employee.SelectedItem).NameEmployee;
            string shift = ((DTO.shiftEmployee)cmb_shift.SelectedItem).NameShift;

            if (!string.IsNullOrEmpty(txt_id.Text))
            {
                if (TimelineDAO.Instance.SetInsertDetails(id, employee, shift).Count > 0)
                {
                    MessageBox.Show("Nhân viên " + employee + " đã đăng ký làm " + shift);
                }
                else
                {
                    if (TimelineDAO.Instance.Fulltime(id, employee).Count > 0)
                    {
                        MessageBox.Show("Nhân viên " + employee + " đã đăng ký làm Fulltime");
                    }
                    else if (shift == "Fulltime")
                    {
                        MessageBox.Show("Nhân viên " + employee + " đã đăng ký ca làm, không thể đăng ký Fulltime");
                    }
                    else
                    {
                        if (TimelineDAO.Instance.InsertTimelineDetails(id, employee, shift))
                        {
                            dgv_timelinedetails.DataSource = TimelineDAO.Instance.getlistTimelineDetails(id);
                            MessageBox.Show("Thêm thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn timeline!");
            }
        }


        private void cmb_employeee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgv_timelinedetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if(r>=0)
            {
                string id = dgv_timelinedetails.Rows[r].Cells["idTimeline"].Value.ToString();
                string employee = dgv_timelinedetails.Rows[r].Cells["idEmployee"].Value.ToString();
                string shift = dgv_timelinedetails.Rows[r].Cells["idShift"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có muốn xóa?", "Thông báo!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (TimelineDAO.Instance.DeleteTimelineDetails(id, employee, shift))
                    {
                        MessageBox.Show("Xóa thành công!");
                        dgv_timelinedetails.DataSource = TimelineDAO.Instance.getlistTimelineDetails(id);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }    
        }
    }
}
