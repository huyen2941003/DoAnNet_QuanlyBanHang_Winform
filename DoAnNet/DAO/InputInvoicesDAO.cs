using DoAnNet.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DAO
{
    internal class InputInvoicesDAO
    {
        static private InputInvoicesDAO instance;

        public static InputInvoicesDAO Instance
        {
            get { if (instance == null) instance = new InputInvoicesDAO(); return instance; }
            private set => instance = value;
        }

        private InputInvoicesDAO() { }

        public List<InputInvoicesDetails> getlistInputInvoicesDetails(string idInvoice)
        {
            List<InputInvoicesDetails> list = new List<InputInvoicesDetails>();
            string query = string.Format("select S.idInvoice, P.nameProduct as idProduct, S.costPrice, S.aMount, S.pay " +
                "from InputInvoicesDetails S " +
                "Left join Product P on S.idProduct = P.id where S.idInvoice = '{0}'", idInvoice);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                InputInvoicesDetails inputInvoicesDetails = new InputInvoicesDetails(item);
                list.Add(inputInvoicesDetails);
            }
            return list;
        }
        public DataTable getlistInputInvoices()
        {
            return Connection.Instance.ExecuteOuery(string.Format("Select I.id, I.dateInvoice, " +
                "P.nameProvider as idProvider, I.pay, I.paidAmount, I.orderStatus from InputInvoices I " +
                "Left join Providers P on I.idProvider = P.id"));
        }
        public DataTable Search_InputInvoices(string id)
        {
            return Connection.Instance.ExecuteOuery(string.Format("Select * from InputInvoices where id like '%{0}%'", id));
        }
        public bool InsertInputInvoices(DateTime dateInvoice, string idProvider)
        {
            string query = string.Format("Insert into InputInvoices values " +
                "( NULL, '{0}', (Select id from Providers where nameProvider = N'{1}'), NULL, NULL, NULL)", dateInvoice, idProvider);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public bool DeleteInputInvoices(string id)
        {
            string query = string.Format("Delete from InputInvoices where id = '{0}'", id);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public List<DataRow> setDeleteInputInvoices(string idInvoice)
        {
            List<DataRow> result = new List<DataRow>();
            List<DataTable> tables = new List<DataTable>();
            try
            {
                string query1 = string.Format("SELECT count(*) FROM InputInvoicesDetails WHERE idInvoice = '{0}'", idInvoice);
                DataTable table1 = Connection.Instance.ExecuteOuery(query1);
                tables.Add(table1); 
                string query2 = string.Format("SELECT count(*) FROM BillPayments WHERE idInputInvoice = '{0}'", idInvoice);
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
        public bool UpdateStatusOrders2(string id)
        {
            string query = string.Format("Update InputInvoices set orderStatus = 1 where id = '{0}'", id);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        public int OutInputInvoices(string idInvoice)
        {
            string query = string.Format("Select count(*) FROM InputInvoicesDetails " +
                "WHERE idInvoice = '{0}'", idInvoice);
            object result = Connection.Instance.ExecuteScalar(query);
            if (result != null && result != DBNull.Value)
            {
                int rowCount = Convert.ToInt32(result);
                return rowCount;
            }
            return 0;
        }

        public int setStatusOrders0(string idInvoice)
        {
            string query = string.Format("Select count(*) FROM InputInvoices WHERE id = '{0}' and orderStatus = 0", idInvoice);
            object result = Connection.Instance.ExecuteScalar(query);
            if (result != null && result != DBNull.Value)
            {
                int rowCount = Convert.ToInt32(result);
                return rowCount;
            }
            return 0;
        }
        public int setStatusOrders1(string idInvoice)
        {
            string query = string.Format("Select count(*) FROM InputInvoices WHERE id = '{0}' and orderStatus = 1", idInvoice);
            object result = Connection.Instance.ExecuteScalar(query);
            if (result != null && result != DBNull.Value)
            {
                int rowCount = Convert.ToInt32(result);
                return rowCount;
            }
            return 0;
        }
        public int setStatusOrders2(string idInvoice)
        {
            string query = string.Format("Select count(*) FROM InputInvoices WHERE id = '{0}' and orderStatus = 2", idInvoice);
            object result = Connection.Instance.ExecuteScalar(query);
            if (result != null && result != DBNull.Value)
            {
                int rowCount = Convert.ToInt32(result);
                return rowCount;
            }
            return 0;
        }

        //InputInvoicesDetails
        public bool InsertInputInvoicesDetails(string idInvoice, string idProduct, int aMount)
        {
            string query = string.Format("Insert into InputInvoicesDetails values ('{0}', " +
                "(Select id from Product where nameProduct = N'{1}'), NULL, {2}, NULL)", idInvoice, idProduct, aMount);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        public List<InputInvoicesDetails> SetInsertInputInvoicesDetails(string idInvoice, string idProduct)
        {
            List<InputInvoicesDetails> list = new List<InputInvoicesDetails>();
            string query = string.Format("select * from InputInvoicesDetails " +
                "where idInvoice = '{0}' and idProduct = (Select id from Product where nameProduct = N'{1}')",
                idInvoice, idProduct);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                InputInvoicesDetails inputInvoicesDetails = new InputInvoicesDetails(item);
                list.Add(inputInvoicesDetails);
            }
            return list;
        }

        public bool DeleteInputInvoicesDetails(string idInvoice, string idProduct)
        {
            string query = string.Format("Delete from InputInvoicesDetails where idInvoice = '{0}' " +
                "and idProduct = (Select id from Product where nameProduct = N'{1}' )", idInvoice, idProduct);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        //Sử lý khi giá nhập bị thay đổi 
        public float getcostPrice(string productName)
        {
            float costPrice = 0.0f;
            string query = string.Format("SELECT costPrice from Product where nameProduct = N'{0}'", productName);
            DataTable data = Connection.Instance.ExecuteQuery(query, new object[] { productName });
            if (data.Rows.Count > 0)
            {
                if (float.TryParse(data.Rows[0]["costPrice"].ToString(), out costPrice))
                {
                    return costPrice;
                }
            }
            return costPrice;
        }
        public bool UpdatecostPrice(string idProduct, float costPrice, int amount)
        {
            string query = string.Format("Update Product set costPrice = (costPrice*(Select amount from Inventory where idProduct = (Select id from Product where nameProduct = N'{0}')) + {1}*{2})/((Select amount from Inventory where idProduct = (Select id from Product where nameProduct = N'{0}')) + {2}) " +
                "where id = (Select id from Product where nameProduct = N'{0}')", idProduct, costPrice, amount);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public bool UpdateAmount(string idInvoice, string idProduct, int amount)
        {
            string query = string.Format("Update InputInvoicesDetails set aMount = ({0} + aMount) " +
                "where idProduct = (Select id from Product where nameProduct = N'{1}') and idInvoice = '{2}'", amount, idProduct, idInvoice);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public DataTable Search_Debt00()
        {
            return Connection.Instance.ExecuteOuery("Select I.id, I.dateInvoice, " +
                "P.nameProvider as idProvider, I.pay, I.paidAmount, I.orderStatus from InputInvoices I " +
                "Left join Providers P on I.idProvider = P.id " +
                "where orderStatus = 0");
        }
        public DataTable Search_Debt11()
        {
            return Connection.Instance.ExecuteOuery("Select I.id, I.dateInvoice, " +
                "P.nameProvider as idProvider, I.pay, I.paidAmount, I.orderStatus from InputInvoices I " +
                "Left join Providers P on I.idProvider = P.id " +
                "where orderStatus = 1");
        }

        //BillPayments
        public DataTable getlistInputInvoicess()
        {
            return Connection.Instance.ExecuteOuery(string.Format("Select I.id, I.dateInvoice, " +
                "P.nameProvider as idProvider, I.pay, I.paidAmount, I.orderStatus from InputInvoices I " +
                "Left join Providers P on I.idProvider = P.id where I.orderStatus = 1"));
        }
        public DataTable getlistBillPayments(string idInvoice)
        {
            return Connection.Instance.ExecuteOuery(string.Format("Select * from BillPayments where idInputInvoice = '{0}'", idInvoice));
        }
        public DataTable paymentStatus(string idInvoice)
        {
            return Connection.Instance.ExecuteOuery(string.Format("Select paidAmount from InputInvoices " +
                "where id = '{0}'", idInvoice));
        }
        public float GetPaidAmount(string idInvoice)
        {
            DataTable dataTable = paymentStatus(idInvoice);

            if (dataTable.Rows.Count > 0)
            {
                string paidAmountStr = dataTable.Rows[0]["paidAmount"].ToString();
                if (float.TryParse(paidAmountStr, out float paidAmount))
                {
                    return paidAmount;
                }
            }
            return 0.0f;
        }
        public bool InsertBillPayments(string idInvoice, DateTime datePayment, float paymentStatus)
        {
            string query = string.Format("Insert into BillPayments values " +
                "('{0}', '{1}', {2})", idInvoice, datePayment, paymentStatus);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public bool DeleteBillPayments(string idInvoice, DateTime datePayment)
        {
            string query = string.Format("Delete from BillPayments " +
                "where idInputInvoice = '{0}' and datePayment = '{1}'", idInvoice, datePayment);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        public int SetInsertBillPayments(string idInvoice, DateTime datePayment)
        {
            string query = string.Format("Select count(*) FROM BillPayments where idInputInvoice = '{0}' and datePayment = '{1}'", idInvoice, datePayment);
            object result = Connection.Instance.ExecuteScalar(query);
            if (result != null && result != DBNull.Value)
            {
                int rowCount = Convert.ToInt32(result);
                return rowCount;
            }
            return 0;
        }

        public bool UpdateStatusOrders(string id)
        {
            string query = string.Format("Update InputInvoices set orderStatus = 0 " +
                "where id = '{0}' and paidAmount = 0", id);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        //Tình trạng nợ
        public DataTable Search_Debt0(string idProvider)
        {
            return Connection.Instance.ExecuteOuery(string.Format("Select I.id, I.dateInvoice, " +
                "P.nameProvider as idProvider, I.pay, I.paidAmount, I.orderStatus from InputInvoices I " +
                "Left join Providers P on I.idProvider = P.id " +
                "where orderStatus = 0 and idProvider = (Select id from Providers where nameProvider = N'{0}')", idProvider));
        }
        public DataTable Search_Debt1(string idProvider)
        {
            return Connection.Instance.ExecuteOuery(string.Format("Select I.id, I.dateInvoice, " +
                "P.nameProvider as idProvider, I.pay, I.paidAmount, I.orderStatus from InputInvoices I " +
                "Left join Providers P on I.idProvider = P.id " +
                "where orderStatus = 1 and idProvider = (Select id from Providers where nameProvider = N'{0}')", idProvider));
        }
    }
}
