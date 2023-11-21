using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class SalesOrderDetails
    {
        private string idInvoice;
        private string idProduct;
        private int aMount;
        private float sellingPrice;
        private float pay;

        public SalesOrderDetails(string idInvoice, string idProduct, int aMount, float sellingPrice, float pay)
        {
            this.IdInvoice = idInvoice;
            this.IdProduct = idProduct;
            this.AMount = aMount;
            this.SellingPrice = sellingPrice;
            this.Pay = pay;
        }

        public SalesOrderDetails(DataRow row)
        {
            this.IdInvoice = row["idInvoice"].ToString();
            this.IdProduct = row["idProduct"].ToString();

            string amount = row["aMount"].ToString();
            if (int.TryParse(amount, out int aMount))
            {
                this.AMount = aMount;
            }
            else
            {
                this.AMount = (int)0.0d;
            }

            string sellingPricee = row["sellingPrice"].ToString();
            if (float.TryParse(sellingPricee, out float sellingPrice))
            {
                this.SellingPrice = sellingPrice;
            }
            else
            {
                this.SellingPrice = 0.0f;
            }

            string payy = row["pay"].ToString();
            if (float.TryParse(payy, out float pay))
            {
                this.Pay = pay;
            }
            else
            {
                this.Pay = 0.0f;
            }
        }

        public string IdInvoice { get => idInvoice; set => idInvoice = value; }
        public string IdProduct { get => idProduct; set => idProduct = value; }
        public int AMount { get => aMount; set => aMount = value; }
        public float Pay { get => pay; set => pay = value; }
        public float SellingPrice { get => sellingPrice; set => sellingPrice = value; }

    }
}
