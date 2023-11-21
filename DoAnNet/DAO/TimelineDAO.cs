using DoAnNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DAO
{
    internal class TimelineDAO
    {
        static private TimelineDAO instance;

        public static TimelineDAO Instance
        {
            get { if (instance == null) instance = new TimelineDAO(); return instance; }
            private set => instance = value;
        }

        private TimelineDAO() { }

        public List<TimeLine> getlistTimeline()
        {
            List<TimeLine> list = new List<TimeLine>();
            string query = string.Format("Select * from Timeline");
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimeLine timeLine = new TimeLine(item);
                list.Add(timeLine);
            }
            return list;
        }
        public List<TimelineDetails> getlistTimelineDetails(string id)
        {
            List<TimelineDetails> list = new List<TimelineDetails>();
            string query = string.Format("Select T.nameTimeline as idTimeline, E.nameEmployee as idEmployee, S.nameShift as idShift " +
                "from TimelineDetails TD " +
                "left join shiftEmployee S on TD.idShift = S.id " +
                "left join Employee E on TD.idEmployee = E.id " +
                "left join Timeline T on TD.idTimeline = T.id where idTimeline = N'{0}'", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimelineDetails timelineDetails = new TimelineDetails(item);
                list.Add(timelineDetails);
            }
            return list;
        }
        public List<TimeClockRecords> getlistTimeClockRecords(DateTime work)
        {
            List<TimeClockRecords> list = new List<TimeClockRecords>();
            string query = string.Format("Select E.nameEmployee as idEmployee, S.nameShift as idShift, T.timeIn, " +
                "T.timeOutwork, T.totalHours, T.workDate, T.lateDate, T.dailySalary " +
                "From TimeClockRecords T " +
                "Left join Employee E on T.idEmployee = E.id " +
                "Left join shiftEmployee S on T.idShift = S.id where workDate = '{0}'", work);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimeClockRecords timeClockRecords = new TimeClockRecords(item);
                list.Add(timeClockRecords);
            }
            return list;
        }
        public bool InsertTimeline(DateTime dayWork)
        {
            string query = string.Format("Insert into Timeline values (NULL, N'Ngày {0}', '{1}')", dayWork.ToString("MM/dd/yyyy"), dayWork);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public List<TimeLine> setinsertTimeline(DateTime dayWork)
        {
            List<TimeLine> list = new List<TimeLine>();
            string query = string.Format("Select * from Timeline where dayWork = '{0}'", dayWork);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimeLine timeLine = new TimeLine(item);
                list.Add(timeLine);
            }
            return list;
        }
        public bool DeleteTimeline(string id)
        {
            string query = string.Format("Delete from Timeline where id = '{0}'", id);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public List<DataRow> SetdeleteTimeline(string id)
        {
            List<DataRow> result = new List<DataRow>();
            List<DataTable> tables = new List<DataTable>();
            try
            {
                string query1 = string.Format("SELECT * FROM TimelineDetails WHERE idTimeline = '{0}'", id);
                DataTable table1 = Connection.Instance.ExecuteOuery(query1);
                tables.Add(table1);
                DataTable unionTable = new DataTable();
                if (tables.Count > 0)
                {
                    unionTable = tables[0].Copy();
                    foreach (DataTable table in tables.Skip(1))
                    {
                        unionTable.Merge(table);
                    }
                }
                result = unionTable.AsEnumerable().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            return result;
        }
        public bool InsertTimelineDetails(string id, string employee, string shift)
        {
            string query = string.Format("Insert into TimelineDetails values " +
                "('{0}', " +
                "(Select id from Employee where nameEmployee = N'{1}'), " +
                "(Select id from shiftEmployee where nameShift = N'{2}'))", id, employee, shift);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public List<TimelineDetails> SetInsertDetails(string id, string employee, string shift)
        {
            List<TimelineDetails> list = new List<TimelineDetails>();
            string query = string.Format("SELECT * FROM TimelineDetails " +
                     "WHERE idTimeline = '{0}' " +
                     "and idEmployee = (Select id from Employee where nameEmployee = N'{1}') " +
                     "and idShift = (Select id from shiftEmployee where nameShift = N'{2}')", id, employee, shift);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimelineDetails timelineDetails = new TimelineDetails(item);
                list.Add(timelineDetails);
            }
            return list;
        }
        public List<TimelineDetails> Fulltime(string id, string employee)
        {
            List<TimelineDetails> list = new List<TimelineDetails>();
            string query = string.Format("SELECT * FROM TimelineDetails " +
                     "WHERE idTimeline = '{0}' " +
                     "and idEmployee = (Select id from Employee where nameEmployee = N'{1}') " +
                     "and idShift = (Select id from shiftEmployee where nameShift = N'Fulltime')", id, employee);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimelineDetails timelineDetails = new TimelineDetails(item);
                list.Add(timelineDetails);
            }
            return list;
        }
        public bool DeleteTimelineDetails(string id, string employee, string shift)
        {
            string query = string.Format("Delete from TimelineDetails " +
                "where idTimeline = (Select id from Timeline where nameTimeline = N'{0}') " +
                "and idEmployee = (Select id from Employee where nameEmployee = N'{1}') " +
                "and idShift = (Select id from shiftEmployee where nameShift = N'{2}')", id, employee, shift);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
    }
}
