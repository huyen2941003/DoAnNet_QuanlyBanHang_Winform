using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DTO
{
    internal class InputInvoicesDetails
    {
        private string idInvoice;
        private string idProduct;
        private float costPrice;
        private int aMount;
        private float pay;
        public InputInvoicesDetails(string idInvoice, string idProduct, float costPrice, int aMount, float pay)
        {
            this.IdInvoice = idInvoice;
            this.IdProduct = idProduct;
            this.CostPrice = costPrice;
            this.AMount = aMount;
            this.Pay = pay;
        }

        public InputInvoicesDetails(DataRow row)
        {
            this.IdInvoice = row["idInvoice"].ToString();
            this.IdProduct = row["idProduct"].ToString();

            string costprice = row["costPrice"].ToString();
            if (float.TryParse(costprice, out float costPrice))
            {
                this.CostPrice = costPrice;
            }
            else
            {
                this.CostPrice = (float)0.0d;
            }

            string amount = row["aMount"].ToString();
            if (int.TryParse(amount, out int aMount))
            {
                this.AMount = aMount;
            }
            else
            {
                this.AMount = (int)0.0d;
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
        public float CostPrice { get => costPrice; set => costPrice = value; }
    }
}
