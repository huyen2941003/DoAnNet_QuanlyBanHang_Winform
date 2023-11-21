using DoAnNet.DTO;
using DoAnNet.Views.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DAO
{
    internal class InventoryDAO
    {
        static private InventoryDAO instance;

        public static InventoryDAO Instance
        {
            get { if (instance == null) instance = new InventoryDAO(); return instance; }
            private set => instance = value;
        }

        private InventoryDAO() { }

        public List<Inventory> getlistInventory()
        {
            List<Inventory> list = new List<Inventory>();
            string query = string.Format("Select P.nameProduct as idProduct, I.amount from Inventory I " +
                "left join Product P on P.id = I.idProduct");
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Inventory inventory = new Inventory(item);
                list.Add(inventory);
            }
            return list;
        }
        public List<Inventory> search(string idProduct)
        {
            List<Inventory> list = new List<Inventory>();
            string query = string.Format("Select P.nameProduct as idProduct, I.amount from Inventory I " +
                "left join Product P on P.id = I.idProduct " +
                "where I.idProduct = (Select id from Product where nameProduct like N'%{0}%')", idProduct);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Inventory inventory = new Inventory(item);
                list.Add(inventory);
            }
            return list;
        }

        public DataTable Inventory(string idProduct)
        {
            return Connection.Instance.ExecuteOuery(string.Format("Select amount from Inventory " +
                "where idProduct = (Select id from Product where nameProduct = N'{0}')", idProduct));
        }
        public int GetInventory(string idProduct)
        {
            DataTable dataTable = Inventory(idProduct);
            if (dataTable.Rows.Count > 0)
            {
                string Inventory = dataTable.Rows[0]["amount"].ToString();
                if (int.TryParse(Inventory, out int inventory))
                {
                    return inventory;
                }
            }
            return (int)0.0d;
        }
    }
}
