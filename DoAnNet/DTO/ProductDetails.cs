using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class ProductDetails
    {
        private string idProduct;
        private string idSize;
        private string idColor;
        private string image;
        
        public ProductDetails(string idProduct, string idSize, string idColor, string image) 
        {
            this.IdProduct = idProduct;
            this.IdSize = idSize;
            this.IdColor = idColor;
            this.Image = image;
        }
        public ProductDetails(DataRow row)
        {
            this.IdProduct = row["idProduct"].ToString();
            this.IdSize = row["idSize"].ToString();
            this.IdColor = row["idColor"].ToString();
            this.Image = row["image"].ToString();
        }
        public string IdProduct { get => idProduct; set => idProduct = value; }
        public string IdSize { get => idSize; set => idSize = value; }
        public string IdColor { get => idColor; set => idColor = value; }
        public string Image { get => image; set => image = value; }
    }
}
