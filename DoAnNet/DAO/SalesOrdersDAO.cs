using DoAnNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DAO
{
    internal class SalesOrdersDAO
    {
        static private SalesOrdersDAO instance;

        public static SalesOrdersDAO Instance
        {
            get { if (instance == null) instance = new SalesOrdersDAO(); return instance; }
            private set => instance = value;
        }

        private SalesOrdersDAO() { }

        public List<SalesOrderDetails> getlistSalesOrderDetails(string idInvoice)
        {
            List<SalesOrderDetails> list = new List<SalesOrderDetails>();
            string query = string.Format("select S.idInvoice, P.nameProduct as idProduct, S.aMount, S.sellingPrice, S.pay " +
                "from SalesOrderDetails S " +
                "Left join Product P on S.idProduct = P.id where S.idInvoice = '{0}'", idInvoice);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                SalesOrderDetails salesOrderDetails = new SalesOrderDetails(item);
                list.Add(salesOrderDetails);
            }
            return list;
        }
        public DataTable getlistSalesOrders()
        {
            return Connection.Instance.ExecuteOuery("Select * from SalesOrders");
        }
        public DataTable Search_SalesOrders(string id)
        {
            return Connection.Instance.ExecuteOuery(string.Format("Select * from SalesOrders where id like '%{0}%'", id));
        }
        public bool InsertSalesOrders(DateTime dateInvoice)
        {
            string query = string.Format("Insert into SalesOrders values ( NULL, '{0}', NULL, NULL)", dateInvoice);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public bool DeleteSalesOrders(string id)
        {
            string query = string.Format("Delete from SalesOrders where id = '{0}'", id);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public int setDeleteSalesOrders(string idInvoice)
        {
            string query = string.Format("SELECT count(*) FROM SalesOrderDetails WHERE idInvoice = '{0}'", idInvoice);
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
            string query = string.Format("Update SalesOrders set orderStatus = 0 where id = '{0}' and pay is not NULL and pay > 0", id);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public int setStatusOrders(string idInvoice)
        {
            string query = string.Format("SELECT COUNT(*) FROM SalesOrders WHERE id = '{0}' and orderStatus = 0", idInvoice);
            object result = Connection.Instance.ExecuteScalar(query);
            if (result != null && result != DBNull.Value)
            {
                int rowCount = Convert.ToInt32(result);
                return rowCount;
            }
            return 0;
        }

        //SalesOrderDetails

        public bool InsertSalesOrderDetails(string idInvoice, string idProduct, int aMount)
        {
            string query = string.Format("Insert into SalesOrderDetails values ('{0}', " +
                "(Select id from Product where nameProduct = N'{1}'), {2}, NULL, NULL)", idInvoice, idProduct, aMount);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        //public bool InsertSalesOrderDetails(string idInvoice, string idProduct, int aMount)
        //{
        //    string query = string.Format("INSERT INTO SalesOrderDetails (idInvoice, idProduct, amount, sellingPrice, pay) " +
        //                   "SELECT N'{0}', (Select id from Product where nameProduct = N'{1}'), {2}, " +
        //                   "p.sellingPrice * (1 - (SELECT ISNULL(MAX(d.percentDiscount), 0) " +
        //                   "FROM Discount d LEFT JOIN ProductDiscount pd ON d.id = pd.idDiscount " +
        //                   "WHERE pd.idProduct = p.id AND d.finishDiscount >= GETDATE()) / 100), " +
        //                   "{2} * (p.sellingPrice * (1 - (SELECT ISNULL(MAX(d.percentDiscount), 0) " +
        //                   "FROM Discount d LEFT JOIN ProductDiscount pd ON d.id = pd.idDiscount " +
        //                   "WHERE pd.idProduct = p.id AND d.finishDiscount >= GETDATE()) / 100)) " +
        //                   "FROM Product p WHERE p.nameProduct = N'{1}'", idInvoice, idProduct, aMount);
        //    int result = Connection.Instance.ExecuteNonOuery(query);
        //    return result > 0;
        //}


        public List<SalesOrderDetails> SetInsertSalesOrderDetails(string idInvoice, string idProduct)
        {
            List<SalesOrderDetails> list = new List<SalesOrderDetails>();
            string query = string.Format("select * from SalesOrderDetails " +
                "where idInvoice = '{0}' and idProduct = (Select id from Product where nameProduct = N'{1}')",
                idInvoice, idProduct);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                SalesOrderDetails salesOrderDetails = new SalesOrderDetails(item);
                list.Add(salesOrderDetails);
            }
            return list;
        }
        public bool DeleteSalesOrderDetails(string idInvoice, string idProduct)
        {
            string query = string.Format("Delete from SalesOrderDetails " +
                "where idInvoice = '{0}' " +
                "and idProduct = (Select id from Product where nameProduct = N'{1}')", idInvoice, idProduct);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }


        public bool UpdateSalesOrderDetails(string idInvoice, string idProduct, int aMount)
        {
            string query = string.Format("Update SalesOrderDetails set aMount = ({0} + aMount) " +
                "where idProduct = (Select id from Product where nameProduct = N'{1}') and idInvoice = '{2}'", aMount, idProduct, idInvoice);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        //Tình trạng hóa đơn
        public DataTable Search_Status0()
        {
            return Connection.Instance.ExecuteOuery("Select * from SalesOrders where orderStatus = 0");
        }
        public DataTable Search_Status1()
        {
            return Connection.Instance.ExecuteOuery("Select * from SalesOrders where orderStatus = 1");
        }

        //Xử lý load giá nhập khi combobox thay đổi giá trị
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
    }
}
