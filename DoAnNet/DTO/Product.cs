using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class Product
    {
        private string id;
        private string nameProduct;
        private string idDistribute;
        private string idProvider;
        private float costPrice;
        private float rate;
        private float sellingPrice;

        public Product(string id, string nameProduct, string idDistribute, string idProvider, float costPrice, float rate, float sellingPrice)
        {
            this.Id = id;
            this.NameProduct = nameProduct;
            this.IdDistribute = idDistribute;
            this.IdProvider = idProvider;
            this.CostPrice = costPrice;
            this.Rate = rate;
            this.SellingPrice = sellingPrice;
        }

        public Product(DataRow row)
        {
            this.Id = row["id"].ToString();
            this.NameProduct = row["nameProduct"].ToString();
            this.IdDistribute = row["idDistribute"].ToString();
            this.IdProvider = row["idProvider"].ToString();
            float costPrice;
            if (float.TryParse(row["costPrice"].ToString(), out costPrice))
            {
                this.CostPrice = costPrice;
            }
            else
            {
                this.CostPrice = 0.0f;
            }

            float rate;
            if (float.TryParse(row["rate"].ToString(), out rate))
            {
                this.Rate = rate;
            }
            else
            {
                this.Rate = 0.0f;
            }

            float sellingPriceStr;
            if (float.TryParse(row["sellingPrice"].ToString(), out sellingPriceStr))
            {
                this.SellingPrice = sellingPriceStr;
            }
            else
            {
                this.SellingPrice = 0.0f;
            }

        }
        public string Id { get => id; set => id = value; }
        public string NameProduct { get => nameProduct; set => nameProduct = value; }
        public string IdDistribute { get => idDistribute; set => idDistribute = value; }
        public string IdProvider { get => idProvider; set => idProvider = value; }
        public float CostPrice { get => costPrice; set => costPrice = value; }
        public float Rate { get => rate; set => rate = value; }
        public float SellingPrice { get => sellingPrice; set => sellingPrice = value; }
    }
}
