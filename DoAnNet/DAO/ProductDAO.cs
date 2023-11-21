using System;
using DoAnNet.DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnNet.Views.Products;
using System.Drawing;
using System.ComponentModel;

namespace DoAnNet.DAO
{
    internal class ProductDAO
    {
        static private ProductDAO instance;
        public static ProductDAO Instance
        {
            get { if (instance == null) instance = new ProductDAO(); return instance; }
            private set => instance = value;
        }

        private ProductDAO() { }
        public List<Product> getlistProduct()
        {
            List<Product> list = new List<Product>();
            string query = "SELECT P.iD, P.nameProduct, " +
                "D.nameDistribute AS idDistribute, Pr.nameProvider AS idProvider, " +
                "P.costPrice, P.rate, P.sellingPrice " +
                "FROM Product P " +
                "LEFT JOIN Distribute D ON P.idDistribute = D.iD " +
                "LEFT JOIN Providers Pr ON P.idProvider = Pr.iD ";
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }
            return list;
        }
        public List<Product> getlistProduct_provider(string idProvider)
        {
            List<Product> list = new List<Product>();
            string query = string.Format("SELECT P.iD, P.nameProduct, " +
                "D.nameDistribute AS idDistribute, Pr.nameProvider AS idProvider, " +
                "P.costPrice, P.rate, P.sellingPrice " +
                "FROM Product P " +
                "LEFT JOIN Distribute D ON P.idDistribute = D.iD " +
                "LEFT JOIN Providers Pr ON P.idProvider = Pr.iD " +
                "where idProvider = (Select id from Providers where nameProvider = N'{0}')", idProvider);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }
            return list;
        }
        public List<ProductDetails> getlistProductDetails(string idProduct)
        {
            List<ProductDetails> list = new List<ProductDetails>();
            string query = string.Format("SELECT P.nameProduct AS idProduct, " +
                "S.nameSize AS idSize, C.nameColor AS idColor, " +
                "Pr.image " +
                "FROM ProductDetails Pr " +
                "LEFT JOIN Product P ON Pr.idProduct = P.id " +
                "LEFT JOIN Color C ON Pr.idColor = C.id " +
                "LEFT JOIN Size S ON Pr.idSize = S.id " +
                "where idProduct = '{0}'", idProduct);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductDetails productDetails = new ProductDetails(item);
                list.Add(productDetails);
            }
            return list;
        }
        public List<Product> SearchProduct_nameProduct(string name)
        {
            List<Product> list = new List<Product>();
            string query = string.Format("SELECT P.id, P.nameProduct, " +
                "D.nameDistribute AS idDistribute, Pr.nameProvider AS idProvider, " +
                "P.costPrice, P.rate, P.sellingPrice " +
                "FROM Product P " +
                "LEFT JOIN Distribute D ON P.idDistribute = D.id " +
                "LEFT JOIN Providers Pr ON P.idProvider = Pr.id " + 
                "where P.nameProduct like N'%{0}%'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }
            return list;
        }
        public List<Product> SearchProduct_nameProvider(string name)
        {
            List<Product> list = new List<Product>();
            string query = string.Format("SELECT P.id, P.nameProduct, " +
                "D.nameDistribute AS idDistribute, Pr.nameProvider AS idProvider, " +
                "P.costPrice, P.rate, P.sellingPrice " +
                "FROM Product P " +
                "LEFT JOIN Distribute D ON P.idDistribute = D.id " +
                "LEFT JOIN Providers Pr ON P.idProvider = Pr.id " +
                "where Pr.nameProvider like N'%{0}%'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }
            return list;
        }
        public bool InsertProduct(string iD, string nameProduct, string idDistribute, string idProvider, float costPrice, float rate)
        {
            string query = string.Format("INSERT INTO Product " +
                "VALUES ('{0}', N'{1}', " +
                "(SELECT id FROM Distribute WHERE nameDistribute = N'{2}'), " +
                "(SELECT id FROM Providers WHERE nameProvider = N'{3}')," +
                "{4}, {5}, NULL)",
                iD, nameProduct, idDistribute, idProvider, costPrice, rate);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public List<Product> SetInsert(string id)
        {
            List<Product> list = new List<Product>();
            string query = string.Format("Select * from Product where id = '{0}'", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }
            return list;
        }
        public bool UpdateProduct(string iD, string nameProduct, string idDistribute, string idProvider, float costPrice, float rate)
        {
            string query = string.Format("Update Product set nameProduct = N'{1}', " +
                "idDistribute = (SELECT id FROM Distribute WHERE nameDistribute = N'{2}'), " +
                "idProvider = (SELECT id FROM Providers WHERE nameProvider = N'{3}'), " +
                "costPrice = {4}, " +
                "rate = {5} " +
                "where id = '{0}'",
                iD, nameProduct, idDistribute, idProvider, costPrice, rate);

            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public bool DeleteProduct(string iD)
        {
            string query = string.Format("Delete from Product where id = '{0}'", iD);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }
        public List<DataRow> GetDataForProduct(string productId)
        {
            List<DataRow> result = new List<DataRow>();
            List<DataTable> tables = new List<DataTable>();
            try
            {
                string query1 = string.Format("SELECT * FROM InputInvoicesDetails WHERE idProduct = '{0}'", productId);
                DataTable table1 = Connection.Instance.ExecuteOuery(query1);
                tables.Add(table1);
                string query2 = string.Format("SELECT * FROM SalesOrderDetails WHERE idProduct = '{0}'", productId);
                DataTable table2 = Connection.Instance.ExecuteOuery(query2);
                tables.Add(table2);
                //string query3 = string.Format("SELECT * FROM Inventory WHERE idProduct = '{0}'", productId);
                //DataTable table3 = Connection.Instance.ExecuteOuery(query3);
                //tables.Add(table3);
                string query4 = string.Format("SELECT * FROM productDetails WHERE idProduct = '{0}'", productId);
                DataTable table4 = Connection.Instance.ExecuteOuery(query4);
                tables.Add(table4);
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

        //ProductDetails
        public bool InsertProductDetails(string idProduct, string idSize, string idColor, string image)
        {
            string query = string.Format("INSERT INTO ProductDetails " +
                "VALUES ('{0}', " +
                "(SELECT id FROM Size WHERE nameSize = N'{1}'), " +
                "(SELECT id FROM Color WHERE nameColor = N'{2}')," +
                "'{3}')",
                idProduct, idSize, idColor, image);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public List<ProductDetails> SetInsertProdetails(string idProduct, string idSize, string idColor)
        {
            List<ProductDetails> list = new List<ProductDetails>();
            string query = string.Format("Select * from ProductDetails where idProduct = '{0}' " +
                "and idSize = (SELECT id FROM Size WHERE nameSize = N'{1}') " +
                "and idColor = (SELECT id FROM Color WHERE nameColor = N'{2}')", idProduct, idSize, idColor);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductDetails product = new ProductDetails(item);
                list.Add(product);
            }
            return list;
        }
        public bool DeleteProductDetails(string idProduct, string idSize, string idColor)
        {
            string query = string.Format("Delete from ProductDetails where idProduct = '{0}' " +
                "and idSize = (SELECT id FROM Size WHERE nameSize = N'{1}') " +
                "and idColor = (SELECT id FROM Color WHERE nameColor = N'{2}')", idProduct, idSize, idColor);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
    }
}
