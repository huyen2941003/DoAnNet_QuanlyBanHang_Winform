using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnNet.DTO;

namespace DoAnNet.DAO
{
    internal class ShiftDAO
    {
        static private ShiftDAO instance;

        public static ShiftDAO Instance
        {
            get { if (instance == null) instance = new ShiftDAO(); return instance; }
            private set => instance = value;
        }

        private ShiftDAO() { }
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
        public List<TimelineDetails> setdelete(string id)
        {
            List<TimelineDetails> list = new List<TimelineDetails>();
            string query = string.Format("select * from TimelineDetails where idShift = N'{0}'", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimelineDetails shiftEmployee = new TimelineDetails(item);
                list.Add(shiftEmployee);
            }
            return list;
        }
        public bool InsertEmployee(string id, string name, float timeInshift, float timeOutWorkshift, float coefficientSalary)
        {
            string query = string.Format("Insert shiftEmployee values (N'{0}', N'{1}', {2}, {3}, {4}))", id, name, timeInshift, timeOutWorkshift, coefficientSalary);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }
        public List<shiftEmployee> GetNameshift(string name)
        {
            List<shiftEmployee> list = new List<shiftEmployee>();
            string query = string.Format("select * from shiftEmployee where nameShift = N'{0}'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                shiftEmployee color = new shiftEmployee(item);
                list.Add(color);
            }
            return list;
        }
        public List<shiftEmployee> GetIdshift(string id)
        {
            List<shiftEmployee> list = new List<shiftEmployee>();
            string query = string.Format("select * from shiftEmployee where id = N'{0}'", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                shiftEmployee color = new shiftEmployee(item);
                list.Add(color);
            }
            return list;
        }
        public bool UpdateshiftEmployee(string id, string name, float timeInshift, float timeOutWorkshift, float coefficientSalary)
        {
            string query = string.Format("Update shiftEmployee set nameShift = N'{1}', " +
                "timeInshift = {2}, timeOutWorkshift = {3}, coefficientSalary = {4} where id = N'{0}'", id, name, timeInshift, timeOutWorkshift, coefficientSalary);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }
        public bool DeleteColor(string id)
        {
            string query = string.Format("Delete from shiftEmployee where id = N'{0}'", id);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }
    }
}
