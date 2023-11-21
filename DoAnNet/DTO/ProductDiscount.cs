using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class ProductDiscount
    {
        private string idProduct;
        private string idDiscount;

        public ProductDiscount(string idProduct, string idDiscount)
        {
            this.IdProduct = idProduct;
            this.IdDiscount = idDiscount;
        }
        public ProductDiscount(DataRow row)
        {
            this.IdProduct = row["idProduct"].ToString();
            this.IdDiscount = row["idDiscount"].ToString();
        }
        public string IdProduct { get => idProduct; set => idProduct = value; }
        public string IdDiscount { get => idDiscount; set => idDiscount = value; }
    }
}
