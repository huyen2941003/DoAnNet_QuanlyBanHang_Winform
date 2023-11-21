using System;
using DoAnNet.DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DAO
{
    internal class ProviderDAO
    {
        static private ProviderDAO instance;

        public static ProviderDAO Instance
        {
            get { if (instance == null) instance = new ProviderDAO(); return instance; }
            private set => instance = value;
        }

        private ProviderDAO() { }

        public List<Provider> getlistProvider()
        {
            List<Provider> list = new List<Provider>();
            string query = "select * from Providers";
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Provider provider = new Provider(item);
                list.Add(provider);
            }
            return list;
        }
        public List<Provider> SearchProvider_nameProduct(string name)
        {
            List<Provider> list = new List<Provider>();
            string query = string.Format("SELECT Pr.id, Pr.nameProvider, Pr.adress, Pr.telephone, Pr.email " +
                "FROM Providers Pr " +
                "LEFT JOIN Product P ON Pr.id = P.idProvider where P.nameProduct like N'%{0}%'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Provider provider = new Provider(item);
                list.Add(provider);
            }
            return list;
        }


        public List<Provider> SearchProvider_nameProvider(string name)
        {
            List<Provider> list = new List<Provider>();
            string query = string.Format("SELECT * FROM Providers where nameProvider like N'%{0}%'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Provider provider = new Provider(item);
                list.Add(provider);
            }
            return list;
        }

        public bool InsertProvider(string id, string nameProvider, string address, string telephone, string email)
        {
            string query = string.Format("Insert into Providers values ('{0}', N'{1}', N'{2}',N'{3}', N'{4}')",
                id, nameProvider, address, telephone, email);

            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }
        public List<Provider> SetInsertId(string id)
        {
            List<Provider> list = new List<Provider>();
            string query = string.Format("SELECT * FROM Providers where id = '{0}'", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Provider provider = new Provider(item);
                list.Add(provider);
            }
            return list;
        }

        public List<Provider> SetInsertName(string name)
        {
            List<Provider> list = new List<Provider>();
            string query = string.Format("SELECT * FROM Providers where nameProvider = '{0}'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Provider provider = new Provider(item);
                list.Add(provider);
            }
            return list;
        }

        public bool UpdateProvider(string id, string nameProvider, string address, string telephone, string email)
        {
            string query = string.Format("Update Providers set nameProvider = N'{1}', adress = N'{2}', telephone = N'{3}', email = N'{4}' where id = '{0}'",
                id, nameProvider, address, telephone, email);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        public bool DeleteProvider(string id)
        {
            string query = string.Format("Delete from Providers where id = '{0}'", id);
            int result = Connection.Instance.ExecuteNonOuery(query);
            return result > 0;
        }

        public List<Product> SetDeleteProduct(string idProvider)
        {
            List<Product> list = new List<Product>();
            string query = string.Format("SELECT * FROM Product where idProvider = '{0}'", idProvider);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }
            return list;
        }
    }
}
