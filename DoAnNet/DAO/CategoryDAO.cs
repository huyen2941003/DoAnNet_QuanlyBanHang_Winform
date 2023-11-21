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
    internal class CategoryDAO
    {
        static private CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return instance; }
            private set => instance = value;
        }

        private CategoryDAO() { }

        //Color
        public List<Color> getlistColor()
        {
            List<Color> list = new List<Color>();
            string query = "select * from Color";
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Color color = new Color(item);
                list.Add(color);
            }
            return list;
        }

        public bool InsertColor(string id, string name)
        {
            string query = string.Format("Insert Color values (N'{0}', N'{1}')", id, name);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }
        public List<Color> GetNameColor(string name)
        {
            List<Color> list = new List<Color>();
            string query = string.Format("select * from Color where nameColor = N'{0}'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Color color = new Color(item);
                list.Add(color);
            }
            return list;
        }
        public List<Color> GetIdColor(string id)
        {
            List<Color> list = new List<Color>();
            string query = string.Format("select * from Color where id = N'{0}'", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Color color = new Color(item);
                list.Add(color);
            }
            return list;
        }
        public bool UpdateColor(string id, string name)
        {
            string query = string.Format("Update Color set nameColor = N'{1}' where id = N'{0}'", id, name);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }
        public bool DeleteColor(string id)
        {
            string query = string.Format("Delete from Color where id = N'{0}'", id);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }


        //Size
        public List<Size> getlistSize()
        {
            List<Size> list = new List<Size>();
            string query = "select * from Size";
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Size size = new Size(item);
                list.Add(size);
            }
            return list;
        }
        public bool InsertSize(string id, string name)
        {
            string query = string.Format("Insert Size values (N'{0}', N'{1}')", id, name);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }
        public List<Size> GetNameSize(string name)
        {
            List<Size> list = new List<Size>();
            string query = string.Format("select * from Size where nameSize = N'{0}'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Size size = new Size(item);
                list.Add(size);
            }
            return list;
        }
        public List<Size> GetIdSize(string id)
        {
            List<Size> list = new List<Size>();
            string query = string.Format("select * from Size where id = N'{0}'", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Size size = new Size(item);
                list.Add(size);
            }
            return list;
        }

        public bool UpdateSize(string id, string name)
        {
            string query = string.Format("Update Size set nameSize = N'{1}' where id = N'{0}'", id, name);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }
        public bool DeleteSize(string id)
        {
            string query = string.Format("Delete from Size where id = N'{0}'", id);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }

        //Distribute
        public List<Distribute> getlistDistribute()
        {
            List<Distribute> list = new List<Distribute>();
            string query = "select * from Distribute";
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Distribute distribute = new Distribute(item);
                list.Add(distribute);
            }
            return list;
        }
        public bool InsertDistribute(string id, string name)
        {
            string query = string.Format("Insert Distribute values (N'{0}', N'{1}')", id, name);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }
        public List<Distribute> GetNameDistribute(string name)
        {
            List<Distribute> list = new List<Distribute>();
            string query = string.Format("select * from Distribute where nameDistribute = N'{0}'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Distribute distribute = new Distribute(item);
                list.Add(distribute);
            }
            return list;
        }
        public List<Distribute> GetIdDistribute(string id)
        {
            List<Distribute> list = new List<Distribute>();
            string query = string.Format("select * from Distribute where id = N'{0}'", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Distribute distribute = new Distribute(item);
                list.Add(distribute);
            }
            return list;
        }
        public bool UpdateDistribute(string id, string name)
        {
            string query = string.Format("Update Distribute set nameDistribute = N'{1}' where id = N'{0}'", id, name);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }
        public bool DeleteDistribute(string id)
        {
            string query = string.Format("Delete from Distribute where id = N'{0}'", id);
            int result = Connection.Instance.ExecuteNonOuery(query);

            return result > 0;
        }

        //Button search color, size, distribute
        public List<Color> Search_Color(string name)
        {
            List<Color> list = new List<Color>();
            string query = string.Format("Select * from Color where nameColor like N'%{0}%'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Color distribute = new Color(item);
                list.Add(distribute);
            }
            return list;
        }

        public List<Size> Search_Size(string name)
        {
            List<Size> list = new List<Size>();
            string query = string.Format("Select * from Size where nameSize like N'%{0}%'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Size size = new Size(item);
                list.Add(size);
            }
            return list;
        }

        public List<Distribute> Search_Distribute(string name)
        {
            List<Distribute> list = new List<Distribute>();
            string query = string.Format("Select * from Distribute where nameDistribute like N'%{0}%'", name);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                Distribute distribute = new Distribute(item);
                list.Add(distribute);
            }
            return list;
        }

        //Set Delete Size, Color, Distribute
        public List<ProductDetails> SetDeleteColor(string id)
        {
            List<ProductDetails> list = new List<ProductDetails>();
            string query = string.Format("Select * from productDetails where idColor = '{0}'", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductDetails product = new ProductDetails(item);
                list.Add(product);
            }
            return list;
        }
        public List<ProductDetails> SetDeleteSize(string id)
        {
            List<ProductDetails> list = new List<ProductDetails>();
            string query = string.Format("Select * from productDetails where idSize = '{0}'", id);
            DataTable data = Connection.Instance.ExecuteOuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductDetails product = new ProductDetails(item);
                list.Add(product);
            }
            return list;
        }
        public List<Product> SetDeleteDistribute(string id)
        {
            List<Product> list = new List<Product>();
            string query = string.Format("Select * from Product where idDistribute = '{0}'", id);
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
