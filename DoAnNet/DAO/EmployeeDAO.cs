using System;
using DoAnNet.DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DAO
{
    internal class EmployeeDAO
    {
        static private EmployeeDAO instance;
        public static EmployeeDAO Instance
        {
            get { if (instance == null) instance = new EmployeeDAO(); return instance; }
            private set => instance = value;
        }

        private EmployeeDAO() { }
        public List<shiftEmployee> getlistShift()
        {
            List<shiftEmployee> list = new List<shiftEmployee>();
            string query = "Select * from shiftEmployee";
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                shiftEmployee employee = new shiftEmployee(item);
                list.Add(employee);
            }
            return list;
        }

        public List<Employee> getlistEmployee()
        {
            List<Employee> list = new List<Employee>();
            string query = "Select E.id, P.namePosition as idPosition, E.nameEmployee, " +
                "E.birthday, E.telephone, E.adress, E.employeeImage " +
                "From Employee E " +
                "Left join Position P On E.idPosition = P.id";
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item);
                list.Add(employee);
            }
            return list;
        }
        public List<Employee> SearchPosition(string name)
        {
            List<Employee> list = new List<Employee>();
            string query = string.Format("Select E.id, P.namePosition as idPosition, E.nameEmployee, " +
                "E.birthday, E.telephone, E.adress, E.employeeImage " +
                "From Employee E " +
                "Left join Position P On E.idPosition = P.id where E.nameEmployee like N'%{0}%'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item);
                list.Add(employee);
            }
            return list;
        }
        public List<Employee> SearchEmployee(string name)
        {
            List<Employee> list = new List<Employee>();
            string query = string.Format("Select E.id, P.namePosition as idPosition, E.nameEmployee, " +
                "E.birthday, E.telephone, E.adress, E.employeeImage " +
                "From Employee E " +
                "Left join Position P On E.idPosition = P.id where E.nameEmployee like N'%{0}%'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item);
                list.Add(employee);
            }
            return list;
        }
        public bool InsertEmployee(string iD, string idPosition, string nameEmployee, DateTime birthday, string telephone, string address, string image)
        {
            string query = string.Format("Insert into Employee values ('{0}', (SELECT id FROM Position WHERE namePosition = N'{1}'), N'{2}', '{3}', N'{4}', N'{5}', '{6}')",
                iD, idPosition, nameEmployee, birthday, telephone, address, image);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public List<Employee> SetInsert(string id)
        {
            List<Employee> list = new List<Employee>();
            string query = string.Format("Select * from Employee where id = '{0}' ", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item);
                list.Add(employee);
            }
            return list;
        }

        public bool UpdateEmployee(string iD, string idPosition, string nameEmployee, DateTime birthday, string telephone, string address, string image)
        {
            string query = string.Format("Update Employee set idPosition = (Select id from Position where namePosition = N'{1}') , " +
                "nameEmployee = N'{2}', birthday = '{3}', telephone = N'{4}', " +
                "adress = N'{5}', employeeImage = '{6}' where id = '{0}' ",
                iD, idPosition, nameEmployee, birthday, telephone, address, image);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        public bool DeleteEmployee(string iD)
        {
            string query = string.Format("Delete from Employee where id = '{0}'", iD);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        public List<DataRow> SetDeleteEmployee(string idEmployee)
        {
            List<DataRow> result = new List<DataRow>();
            List<DataTable> tables = new List<DataTable>();
            try
            {
                string query1 = string.Format("SELECT * FROM TimeClockRecords WHERE idEmployee = '{0}'", idEmployee);
                DataTable table1 = Connection.Instance.ExecuteOuery(query1);
                tables.Add(table1);
                string query2 = string.Format("SELECT * FROM Salary WHERE idEmployee = '{0}'", idEmployee);
                DataTable table2 = Connection.Instance.ExecuteOuery(query2);
                tables.Add(table2);
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

        public DataTable getImageEmployee(string name)
        {
            return Connection.Instance.ExecuteOuery(string.Format("Select employeeImage from Employee where nameEmployee = N'{0}'", name));
        }
        public List<TimeLine> getlistTimeline()
        {
            List<TimeLine> list = new List<TimeLine>();
            string query = string.Format("Select T.id, E.idEmployee as nameEmployee, E.idShift as nameShift " +
                "from Timeline " +
                "left join Employee E on ");
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimeLine timeline = new TimeLine(item);
                list.Add(timeline);
            }
            return list;
        }

    }
}
