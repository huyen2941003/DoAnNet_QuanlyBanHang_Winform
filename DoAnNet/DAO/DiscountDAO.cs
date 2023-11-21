using DoAnNet.Views.Discount;
using System;
using DoAnNet.DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DAO
{
    internal class DiscountDAO
    {
        static private DiscountDAO instance;

        public static DiscountDAO Instance
        {
            get { if (instance == null) instance = new DiscountDAO(); return instance; }
            private set => instance = value;
        }
        private DiscountDAO() { }

        public List<Discount> getlistDiscount()
        {
            List<Discount> list = new List<Discount>();
            string query = "Select * from Discount";
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Discount discount = new Discount(item);
                list.Add(discount);
            }
            return list;
        }
        public List<Discount> search_Product(string name)
        {
            List<Discount> list = new List<Discount>();
            string query = string.Format("select P.nameProduct, D.id, D.nameDiscount, D.startDiscount, D.finishDiscount, D.percentDiscount " +
                "From Discount D " +
                "Left join Product P On P.idDiscount = D.id " +
                "where P.idDiscount = (Select id from Discount where nameDiscount like N'%{0}%')", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Discount discount = new Discount(item);
                list.Add(discount);
            }
            return list;
        }

        public List<Discount> search_Discount(string name)
        {
            List<Discount> list = new List<Discount>();
            string query = string.Format("select * from Discount where nameDiscount like N'%{0}%' ", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Discount discount = new Discount(item);
                list.Add(discount);
            }
            return list;
        }

        public bool InsertDiscount(string iD, string nameDiscount, DateTime startDiscount, DateTime finishDiscount, float percentDiscount)
        {
            string query = string.Format("Insert into Discount values ('{0}', N'{1}', '{2}', '{3}', {4})",
                iD, nameDiscount, startDiscount, finishDiscount, percentDiscount);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public List<Discount> SetInsert(string id)
        {
            List<Discount> list = new List<Discount>();
            string query = string.Format("select * from Discount where id = '{0}'", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Discount discount = new Discount(item);
                list.Add(discount);
            }
            return list;
        }

        public bool UpdateDiscount(string iD, string nameDiscount, DateTime startDiscount, DateTime finishDiscount, float percentDiscount)
        {
            string query = string.Format("Update Discount set nameDiscount = N'{1}', startDiscount = '{2}', finishDiscount = '{3}', " +
                "percentDiscount = {4} where id = '{0}'", iD, nameDiscount, startDiscount, finishDiscount, percentDiscount);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        public bool DeleteDiscount(string id)
        {
            string query = string.Format("Delete from Discount where id = '{0}' ", id);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public List<Product> SetDelete(string id)
        {
            List<Product> list = new List<Product>();
            string query = string.Format("select * from Product where idDiscount = '{0}' ", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }
            return list;
        }

        //ProductDiscount
        public List<ProductDiscount> getlistDiscountDetials(string idProduct)
        {
            List<ProductDiscount> list = new List<ProductDiscount>();
            string query = string.Format("Select P.nameProduct AS idProduct," +
                "D.nameDiscount AS idDiscount " +
                "from ProductDiscount PD " +
                "Left join Product P ON PD.idProduct = P.id " +
                "Left join Discount D ON PD.idDiscount = D.id " +
                "where idProduct = '{0}'", idProduct);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductDiscount discount = new ProductDiscount(item);
                list.Add(discount);
            }
            return list;
        }
        public bool DeleteDiscount(string idProduct, string idDiscount)
        {
            string query = string.Format("Delete from ProductDiscount " +
                "where idProduct = (Select id from Product where nameProduct = N'{0}') " +
                "and idDiscount = (Select id from Discount where nameDiscount = N'{1}')", idProduct, idDiscount);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public bool InsertDiscountDetials(string idProduct, string idDiscount)
        {
            string query = string.Format("Insert ProductDiscount " +
                "values ('{0}', " +
                "(Select id from Discount where nameDiscount = N'{1}'))", idProduct, idDiscount);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public List<ProductDiscount> setInsertDetails(string idProduct, string idDiscount)
        {
            List<ProductDiscount> list = new List<ProductDiscount>();
            string query = string.Format("Select P.nameProduct AS idProduct," +
                "D.nameDiscount AS idDiscount " +
                "from ProductDiscount PD " +
                "Left join Product P ON PD.idProduct = P.id " +
                "Left join Discount D ON PD.idDiscount = D.id " +
                "where idProduct = '{0}' " +
                "and idDiscount = (Select id from Discount where nameDiscount = N'{1}')", idProduct, idDiscount);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductDiscount discount = new ProductDiscount(item);
                list.Add(discount);
            }
            return list;
        }
    }
}
