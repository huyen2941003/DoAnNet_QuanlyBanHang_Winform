using DoAnNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DAO
{
    internal class AccountDAO
    {
        static private AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }

        private AccountDAO() { }
        public List<Position> getlistPosition()
        {
            List<Position> list = new List<Position>();
            string query = "select * from Position";
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Position position = new Position(item);
                list.Add(position);
            }
            return list;
        }
        public List<Account> getlistAccount()
        {
            List<Account> list = new List<Account>();
            string query = "Select P.namePosition as idPosition, A.userName, A.pass " +
                "From Account A " +
                "Left join Position P " +
                "On A.idPosition = P.id";
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                list.Add(account);
            }
            return list;
        }
        public List<Account> Login(string userName, string passWord)
        {
            List<Account> list = new List<Account>();
            string query = string.Format("select * from Account where userName = N'{0}' and pass = N'{1}'",
                userName, passWord);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                list.Add(account);
            }
            return list;
        }
        public List<Account> GetPosition(string userName, string passWord)
        {
            List<Account> list = new List<Account>();
            string query = string.Format("select idPosition from Account where userName = N'{0}' and pass = N'{1}'",
                userName, passWord);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                list.Add(account);
            }
            return list;
        }

        public bool InsertAccount(string username, string password, string position)
        {
            string query = string.Format("Insert Account values (N'{0}', N'{1}', (Select id from Position where namePosition = N'{2}'))",
                username, password, position);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        public List<Account> SetInsert(string userName)
        {
            List<Account> list = new List<Account>();
            string query = string.Format("Select * from Account where userName = N'{0}'",
                userName);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                list.Add(account);
            }
            return list;
        }
        public bool UpdatePassWord(string username, string password)
        {
            string query = string.Format("Update Account set pass = '{0}' where userName = N'{1}' ", password, username);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string username)
        {
            string query = string.Format("Delete from Account where userName = N'{0}'", username);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

    }
}
