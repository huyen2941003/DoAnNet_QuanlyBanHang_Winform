using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class TimeClockRecords
    {
        private string idEmployee;
        private string idShift;
        private float timeIn;
        private float timeOutwork;
        private float totalHours;
        private DateTime workDate;
        private int lateDate;
        private float dailySalary;

        public TimeClockRecords(string idEmployee, string idShift, float timeIn, float timeOutwork, float totalHours, DateTime workDate, int lateDate, float dailySalary)
        {
            this.IdEmployee = idEmployee;
            this.IdShift = idShift;
            this.TimeIn = timeIn;
            this.TimeOutwork = timeOutwork;
            this.TotalHours = totalHours;
            this.WorkDate = workDate;
            this.LateDate = lateDate;
            this.DailySalary = dailySalary;
        }
        public TimeClockRecords(DataRow row)
        {
            this.IdEmployee = row["idEmployee"].ToString();
            this.IdShift = row["idShift"].ToString();

            float timeIn;
            if (float.TryParse(row["timeIn"].ToString(), out timeIn))
            {
                this.TimeIn = timeIn;
            }
            else
            {
                this.TimeIn = 0.0f;
            }

            float timeOutwork;
            if (float.TryParse(row["timeOutwork"].ToString(), out timeOutwork))
            {
                this.TimeOutwork = timeOutwork;
            }
            else
            {
                this.TimeOutwork = 0.0f;
            }

            float totalHours;
            if (float.TryParse(row["totalHours"].ToString(), out totalHours))
            {
                this.TotalHours = totalHours;
            }
            else
            {
                this.TotalHours = 0.0f;
            }

            var workingDay = row["workDate"];
            if (workingDay != DBNull.Value)
            {
                this.WorkDate = Convert.ToDateTime(workingDay);
            }
            else
            {
                this.WorkDate = DateTime.MinValue;
            }

            int lateDate;
            if (int.TryParse(row["lateDate"].ToString(), out lateDate))
            {
                this.LateDate = lateDate;
            }
            else
            {
                this.LateDate = 0;
            }

            float dailySalary;
            if (float.TryParse(row["dailySalary"].ToString(), out dailySalary))
            {
                this.DailySalary = dailySalary;
            }
            else
            {
                this.DailySalary = 0.0f;
            }
        }

        public string IdEmployee { get => idEmployee; set => idEmployee = value; }
        public string IdShift { get => idShift; set => idShift = value; }
        public float TimeIn { get => timeIn; set => timeIn = value; }
        public float TimeOutwork { get => timeOutwork; set => timeOutwork = value; }
        public float TotalHours { get => totalHours; set => totalHours = value; }
        public DateTime WorkDate { get => workDate; set => workDate = value; }
        public int LateDate { get => lateDate; set => lateDate = value; }
        public float DailySalary { get => dailySalary; set => dailySalary = value; }
    }
}
