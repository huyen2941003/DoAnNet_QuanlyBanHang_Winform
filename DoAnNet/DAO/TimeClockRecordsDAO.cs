using DoAnNet.DTO;
using DoAnNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoAnNet.DAO
{
    internal class TimeClockRecordDAO
    {
        static private TimeClockRecordDAO instance;

        public static TimeClockRecordDAO Instance
        {
            get { if (instance == null) instance = new TimeClockRecordDAO(); return instance; }
            private set => instance = value;
        }

        private TimeClockRecordDAO() { }

        public List<TimeClockRecords> getlistTimeClockRecords()
        {
            List<TimeClockRecords> list = new List<TimeClockRecords>();
            string query = "Select E.nameEmployee as idEmployee, S.nameShift as idShift, T.timeIn, " +
                "T.timeOutwork, T.totalHours, T.workDate, T.lateDate, T.dailySalary " +
                "From TimeClockRecords T " +
                "Left join Employee E on T.idEmployee = E.id " +
                "Left join shiftEmployee S on T.idShift = S.id";
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimeClockRecords timeClockRecords = new TimeClockRecords(item);
                list.Add(timeClockRecords);
            }
            return list;
        }

        public List<TimeClockRecords> Search_TimeClockRecords(string name)
        {
            List<TimeClockRecords> list = new List<TimeClockRecords>();
            string query = string.Format("Select E.nameEmployee as idEmployee, " +
                "S.nameShift as idShift, T.timeIn, " +
                "T.timeOutwork, T.totalHours, T.workDate, T.lateDate, T.dailySalary " +
                "From TimeClockRecords T " +
                "Left join Employee E on T.idEmployee = E.id " +
                "Left join shiftEmployee S on T.idShift = S.id " +
                "where E.nameEmployee like N'%{0}%'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimeClockRecords timeClockRecords = new TimeClockRecords(item);
                list.Add(timeClockRecords);
            }
            return list;
        }

        public bool InsertTimeIn(string idEmployee, string idShift, float timeIn, DateTime workDate)
        {
            string query = string.Format("Insert into TimeClockRecords values " +
                "((Select id from Employee where nameEmployee = N'{0}'), " +
                "(Select id from shiftEmployee where nameShift = N'{1}'), " +
                "{2}, 0, 0, '{3}', 0, 0 )",
                idEmployee, idShift, timeIn, workDate);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        public List<TimeClockRecords> SetInsert(string idEmployee, DateTime workDate, string idShift)
        {
            List<TimeClockRecords> list = new List<TimeClockRecords>();
            string query = string.Format("Select * from TimeClockRecords " +
                "where idEmployee = (Select id from Employee where nameEmployee = N'{0}') " +
                "and workDate = '{1}' " +
                "and idShift = (Select id from shiftEmployee where nameShift = N'{2}')", idEmployee, workDate, idShift);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimeClockRecords timeClockRecords = new TimeClockRecords(item);
                list.Add(timeClockRecords);
            }
            return list;
        }


        public bool InsertTimeOut(float timeOut, string idEmployee, DateTime workDate, string idShift)
        {
            string query = string.Format("Update TimeClockRecords set timeOutwork = {0} " +
                "where idEmployee = (Select id from Employee where nameEmployee = N'{1}') " +
                "and workDate = '{2}' " +
                "and idShift = (Select id from shiftEmployee where nameShift = N'{3}')",
                timeOut, idEmployee, workDate, idShift);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        public bool DeleteTimeClockRecords(string idEmployee, DateTime workDate, string idShift)
        {
            string query = string.Format("Delete from TimeClockRecords " +
                "where idEmployee = (Select id from Employee where nameEmployee = N'{0}') " +
                "and workDate = '{1}' " +
                "and idShift = (Select id from shiftEmployee where nameShift = N'{2}')", idEmployee, workDate, idShift);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        public List<TimeClockRecords> LateDate(int year, int month, string idEmployee)
        {
            List<TimeClockRecords> list = new List<TimeClockRecords>();
            string query = string.Format("Select * from TimeClockRecords " +
                "where YEAR(workDate) = {0} and MONTH(workDate) = {1} and lateDate = 1 " +
                "and idEmployee = (Select id from Employee where nameEmployee = N'{2}') ", year, month, idEmployee);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimeClockRecords timeClockRecords = new TimeClockRecords(item);
                list.Add(timeClockRecords);
            }
            return list;
        }

        public List<TimeClockRecords> WorkDate(int year, int month, string idEmployee)
        {
            List<TimeClockRecords> list = new List<TimeClockRecords>();
            string query = string.Format("Select * from TimeClockRecords " +
                "where YEAR(workDate) = {0} and MONTH(workDate) = {1} " +
                "and idEmployee = (Select id from Employee where nameEmployee = N'{2}')", year, month, idEmployee);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimeClockRecords timeClockRecords = new TimeClockRecords(item);
                list.Add(timeClockRecords);
            }
            return list;
        }

        //Shift
        public List<shiftEmployee> shiftEmployee()
        {
            List<shiftEmployee> list = new List<shiftEmployee>();
            string query = "select * from shiftEmployee";
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                shiftEmployee shiftEmployee = new shiftEmployee(item);
                list.Add(shiftEmployee);
            }
            return list;
        }

    }
}
